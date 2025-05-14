using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Futronic.SDKHelper;
using System.IO;
//using Futronic.SDK.WorkedEx;
using Microsoft.ApplicationBlocks.Data;
using FASClient.Forms;

namespace FASClient
{
    public partial class frmFingerRegistration : Form
    {
        public int nLength { get; set; }
        string uid;

        public bool exist = true;
        public Employee emp;
        bool existing = false;
        //public User _user;
        private Object m_listObj;

        delegate void SetTextCallback(string text);
        delegate void SetComboboxCallback();
        delegate void SetImageCallback(Bitmap hBitmap);

        private bool m_bExit;
        int fingerCount = 0;
        public bool isregister = false;
        delegate void EnableControlsCallback(bool bEnable);
        private FutronicSdkBase enrollOperation;
        private FutronicSdkBase identifyOperation;

        delegate void SetIdentificationLimitCallback(int limit);
        private bool m_bInitializationSuccess;
        private Object m_OperationObj;
        bool fasConnected = false;
        bool duplicateFound = false;
        bool enrollMode = false;
        string fingerno = "";
        string finalString = "";



        public frmFingerRegistration()
        {
            InitializeComponent();
            m_bInitializationSuccess = false;
            FutronicEnrollment dummy = new FutronicEnrollment();

            m_bInitializationSuccess = true;


        }

        void OnFingerEnrolled()
        {
            if (this.cboFingerNo.InvokeRequired)
            {
                SetComboboxCallback d = new SetComboboxCallback(this.OnFingerEnrolled);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.cboFingerNo.Items.Remove(cboFingerNo.SelectedItem);
                this.Update();
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            fingerCount = 0;
            btnReg.Enabled = false;
            enrollMode = true;
            duplicateFound = false;

            User _user = new User(emp.FingerID);
            uid = emp.FingerID;
            if (_user.UID == null)
                existing = false;
            else
                existing = true;


            if (cboFingerNo.Text == "Finger 1")
                fingerno = "6";
            if (cboFingerNo.Text == "Finger 2")
                fingerno = "3";
            if (cboFingerNo.Text == "Finger 3")
                fingerno = "5";
            finalString = string.Format("{0}_{1}", uid, fingerno);
            btnStop.Enabled = true;

            Identify();
            //Enroll();

        }

        void Enroll()
        {

            /// Registration starts here
            DbRecord user = new DbRecord();

            user.UserName = finalString;
            //CreateFile(finalString);



            m_OperationObj = user;
            //enrollOperation = null;
            FutronicSdkBase dummy = new FutronicEnrollment();
            if (enrollOperation != null)
            {
                enrollOperation.Dispose();
                enrollOperation = null;
            }
            enrollOperation = dummy;

            // Set control properties
            enrollOperation.FakeDetection = false;
            enrollOperation.FFDControl = true;
            enrollOperation.FARN = 166;
            enrollOperation.Version = VersionCompatible.ftr_version_current;
            enrollOperation.FastMode = false;
            ((FutronicEnrollment)enrollOperation).MIOTControlOff = false;
            ((FutronicEnrollment)enrollOperation).MaxModels = 2;

            // register events
            enrollOperation.OnPutOn += new OnPutOnHandler(this.OnPutOn);
            enrollOperation.OnTakeOff += new OnTakeOffHandler(this.OnTakeOff);
            enrollOperation.UpdateScreenImage += new UpdateScreenImageHandler(this.UpdateScreenImage);
            ((FutronicEnrollment)enrollOperation).OnEnrollmentComplete += new OnEnrollmentCompleteHandler(this.OnEnrollmentComplete);

            // start enrollment 

            ((FutronicEnrollment)enrollOperation).Enrollment();
        }

        protected void CreateFile(String UserName)
        {
            String szFileName;
            szFileName = Path.Combine(Globals.templateFolder, UserName);
            //szFileName = Path.Combine(Application.StartupPath + "\\Templates\\", UserName);
            File.Create(szFileName).Close();
            File.Delete(szFileName);
        }


        public int Synchronize(string fileName)
        {
            int ret;

            bool bSorC = true;
            Byte idFac = byte.Parse("0");
            byte idGroup = byte.Parse("0");
            byte[] templateFP = null;

            Byte typeUser = byte.Parse("023");
            string str = Path.GetFileName(fileName);
            string[] strid = str.Split('_');
            string str1 = strid[0];
            string str2 = strid[1];
            Byte fingerid = byte.Parse(strid[1]);
            //Byte fingerid = byte.Parse(emp.FingerID);
            string gid = Constant.getFingerUserGID(emp.Section);
            idGroup = byte.Parse(gid);

            //if (emp.Section.ToLower().Trim().Equals(Constant.Student.ToLower().Trim()))
            //    idGroup = byte.Parse("11");
            //else if (emp.Section.ToLower().Trim().Contains(Constant.Staff.ToLower().Trim()))
            //    idGroup = byte.Parse("21");
            //else if (emp.Section.ToLower().Trim().Equals(Constant.Resident.ToLower().Trim()))
            //    idGroup = byte.Parse("31");
            //else if (emp.Section.ToLower().Trim().Equals(Constant.Visitor.ToLower().Trim()))
            //    idGroup = byte.Parse("41");


            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                //UTF8Encoding utfEncoder = new UTF8Encoding();
                byte[] Data = null;
                //string nameUser;

                // Read user name length and user name in UTF8
                if (fileStream.Length < 2)
                    throw new InvalidDataException(String.Format("Bad file {0}", fileStream.Name));
                nLength = (fileStream.ReadByte() << 8) | fileStream.ReadByte();
                Data = new byte[nLength];

                if (nLength != fileStream.Read(Data, 0, nLength))
                    throw new InvalidDataException(String.Format("Bad file {0}", fileStream.Name));
                //nameUser = utfEncoder.GetString(Data);

                // Read user unique ID
                byte[] key = new byte[16];
                if (fileStream.Read(key, 0, 16) != 16)
                    throw new InvalidDataException(String.Format("Bad file {0}", fileStream.Name));

                // Read template length and template data
                if ((fileStream.Length - fileStream.Position) < 2)
                    throw new InvalidDataException(String.Format("Bad file {0}", fileStream.Name));
                nLength = (fileStream.ReadByte() << 8) | fileStream.ReadByte();
                templateFP = new byte[nLength];
                if (fileStream.Read(templateFP, 0, nLength) != nLength)
                    throw new InvalidDataException(String.Format("Bad file {0}", fileStream.Name));

                if (!existing)
                    ret = ExtendApi.FasAddFpUser(bSorC, idFac, nLength, templateFP, emp.Name.ToString(), uid, idGroup, fingerid, typeUser, true);
                else
                    ret = ExtendApi.FasAddFpUser(bSorC, idFac, nLength, templateFP, emp.Name.ToString(), uid, idGroup, fingerid, typeUser, false);

                if (ret == 2007 || ret == 0)
                {

                    new frmMessageBox(MessageBoxType.Info, "Finger Saved Successfully with Return Code " + ret.ToString()).ShowDialog();



                    //frmFingerRegistration_Load(null, null);
                    OnFingerEnrolled();

                }
                else
                    new frmMessageBox(MessageBoxType.Error, ExtendErr.GetErrorMessage(ret)).ShowDialog();

                return ret;
            }
        }

        private void OnEnrollmentComplete(bool bSuccess, int nRetCode)
        {
            StringBuilder szMessage = new StringBuilder();
            if (bSuccess)
            {
                // set status string
                //szMessage.Append("Caputre process finished successfully.\n\r");
                //szMessage.Append("Figner Captured. Quality: ");
                //szMessage.Append(((FutronicEnrollment)enrollOperation).Quality.ToString());
                //SetStatusText(szMessage.ToString());

                // Set template into user's information and save it
                DbRecord User = (DbRecord)m_OperationObj;
                User.Template = ((FutronicEnrollment)enrollOperation).Template;

                String szFileName = Path.Combine(Globals.templateFolder, User.UserName);
                if (!User.Save(szFileName))
                {
                    //MessageBox.Show("Can not save users's information to file " + szFileName,
                    //                 "DDS FAS Client v2",
                    //                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    new frmMessageBox(MessageBoxType.Alert, "Can not save users's information to file " + szFileName).ShowDialog();
                }
                else
                {
                    // Add User in FAS
                    //AddFPUser(User.UserName, userName, szFileName);
                    SetStatusText("Finger Captured... Saving. Please Wait...");
                    Synchronize(szFileName);
                    SetStatusText("Process Completed");
                }

            }
            else
            {
                szMessage.Append("Enrollment process failed.");
                szMessage.Append("Error description: ");
                szMessage.Append(FutronicSdkBase.SdkRetCode2Message(nRetCode));
                this.SetStatusText(szMessage.ToString());
            }

            // unregister events
            enrollOperation.OnPutOn -= new OnPutOnHandler(this.OnPutOn);
            enrollOperation.OnTakeOff -= new OnTakeOffHandler(this.OnTakeOff);
            enrollOperation.UpdateScreenImage -= new UpdateScreenImageHandler(this.UpdateScreenImage);
            //enrollOperation.OnFakeSource -= new OnFakeSourceHandler(this.OnFakeSource);
            ((FutronicEnrollment)enrollOperation).OnEnrollmentComplete -= new OnEnrollmentCompleteHandler(this.OnEnrollmentComplete);

            m_OperationObj = null;
            EnableControls(true);
        }

        private void Identify()
        {
            EnableControls(false);

            if (identifyOperation != null)
            {
                identifyOperation.Dispose();
                identifyOperation = null;
            }
            identifyOperation = new FutronicIdentification();

            // Set control property
            identifyOperation.FakeDetection = false;
            identifyOperation.FFDControl = true;
            /**********************************************************************
            // FAS work with sdk 3.0 version template.
            // for the sdk 3.5 or above, please set the following parameter
            //
            // m_Operation.Version = VersionCompatible.ftr_version_previous;
            // 
            ************************************************************************/
            // register events
            identifyOperation.OnPutOn += new OnPutOnHandler(this.OnPutOn);
            identifyOperation.OnTakeOff += new OnTakeOffHandler(this.OnTakeOff);
            identifyOperation.UpdateScreenImage += new UpdateScreenImageHandler(this.UpdateScreenImage);
            ((FutronicIdentification)identifyOperation).OnGetBaseTemplateComplete +=
                    new OnGetBaseTemplateCompleteHandler(this.OnGetBaseTemplateComplete);

            // start identification process
            ((FutronicIdentification)identifyOperation).GetBaseTemplate();
        }

        private void OnGetBaseTemplateComplete(bool bSuccess, int nRetCode)
        {
            if (bSuccess)
            {
                int ret;
                byte[] idRet = new byte[13];
                ret = ExtendApi.FasIdentifyUser("all", (uint)((FutronicIdentification)identifyOperation).BaseTemplate.Length,
                    ((FutronicIdentification)identifyOperation).BaseTemplate, idRet);
                if (ret == 0)
                {
                    duplicateFound = true;

                    //{
                    UTF8Encoding utfEncoder = new UTF8Encoding();
                    string szUser = utfEncoder.GetString(idRet);
                    string userID = Globals.ConvertToString(szUser);
                    Employee emp2 = Cache.employeeList.Find(x => x.FingerID == userID);
                    string szMessage = "You are " + szUser;
                    if (emp.FingerID == userID)
                    {
                        if (!enrollMode)
                        {
                            Globals.ShowMessage("Finger Verified Successfully ...");
                        }
                    }
                    else
                    {
                        if (!enrollMode)
                        {
                            Globals.ShowMessage("Finger Not Verified Against Current User.");
                        }

                        SetStatusText("Finger Match Found Against " + emp2.Code + " - " + emp2.Name);
                    }
                    //}
                }
                else
                {
                    duplicateFound = false;
                    if (!enrollMode)
                        SetStatusText(ExtendErr.GetErrorMessage(ret));
                }


            }
            else
            {
                string szMessage = "Can not retrieve base template. Error : " + FutronicSdkBase.SdkRetCode2Message(nRetCode);
                SetStatusText(szMessage);
            }

            // unregister events
            identifyOperation.OnPutOn -= new OnPutOnHandler(this.OnPutOn);
            identifyOperation.OnTakeOff -= new OnTakeOffHandler(this.OnTakeOff);
            identifyOperation.UpdateScreenImage -= new UpdateScreenImageHandler(this.UpdateScreenImage);
            //identifyOperation.OnFakeSource -= new OnFakeSourceHandler(this.OnFakeSource);
            ((FutronicIdentification)identifyOperation).OnGetBaseTemplateComplete -= new OnGetBaseTemplateCompleteHandler(this.OnGetBaseTemplateComplete); ;

            if (enrollMode)
            {
                if (!duplicateFound)
                {
                    Enroll();
                    enrollMode = false;
                }
                else
                {
                    // MessageBox.Show("");
                    //SetStatus("Duplicate Found. Enrollment Stopped.");
                }
            }


            EnableControls(true);
        }

        private void Unregister()
        {
            // unregister events
            enrollOperation.OnPutOn -= new OnPutOnHandler(this.OnPutOn);
            enrollOperation.OnTakeOff -= new OnTakeOffHandler(this.OnTakeOff);
            enrollOperation.UpdateScreenImage -= new UpdateScreenImageHandler(this.UpdateScreenImage);
            // m_Operation.OnFakeSource -= new OnFakeSourceHandler(this.OnFakeSource);
            ((FutronicEnrollment)enrollOperation).OnEnrollmentComplete -= new OnEnrollmentCompleteHandler(this.OnEnrollmentComplete);


            identifyOperation.OnPutOn -= new OnPutOnHandler(this.OnPutOn);
            identifyOperation.OnTakeOff -= new OnTakeOffHandler(this.OnTakeOff);
            identifyOperation.UpdateScreenImage -= new UpdateScreenImageHandler(this.UpdateScreenImage);
            // m_Operation.OnFakeSource -= new OnFakeSourceHandler(this.OnFakeSource);
            ((FutronicIdentification)identifyOperation).OnGetBaseTemplateComplete -= new OnGetBaseTemplateCompleteHandler(OnGetBaseTemplateComplete);

        }

        private void OnPutOn(FTR_PROGRESS Progress)
        {
            if (isregister == true)
            {
                fingerCount++;
                this.SetStatusText("Put finger into device, please for frame" + fingerCount);
                System.Threading.Thread.Sleep(500);
                Application.DoEvents();
            }
            else
                this.SetStatusText("Put finger into device, please");
        }

        private void OnTakeOff(FTR_PROGRESS Progress)
        {
            this.SetStatusText("Take off finger from device, please ...");
            System.Threading.Thread.Sleep(500);
            Application.DoEvents();
        }

        private void UpdateScreenImage(Bitmap hBitmap)
        {
            // Do not change the state control during application closing.
            if (m_bExit)
                return;
            if (PictureFingerPrint.InvokeRequired)
            {
                SetImageCallback d = new SetImageCallback(this.UpdateScreenImage);
                this.Invoke(d, new object[] { hBitmap });
            }
            else
            {
                PictureFingerPrint.Image = hBitmap;
            }
        }
        private void SetStatusText(String text)
        {
            // Do not change the state control during application closing.
            if (m_bExit)
                return;
            if (this.txtMessage.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(this.SetStatusText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtMessage.Text = text;
                this.Update();
            }
        }

        private void frmFingerRegistration_Load(object sender, EventArgs e)
        {
            //btnStop.Enabled = false;
            btnDelete.Enabled = false;
            if (!string.IsNullOrEmpty(emp.FingerID))
            {
                existing = true;
                User _user = new User(emp.FingerID);

                if (!string.IsNullOrEmpty(_user.UID))
                {
                    btnDelete.Enabled = true;
                    //btnReg.Enabled = false;
                }

                if (string.IsNullOrEmpty(_user.Finger1))
                    cboFingerNo.Items.Add("Finger 1");
                else
                    cboRegisteredFingers.Items.Add("Finger 1");

                if (string.IsNullOrEmpty(_user.Finger2))
                    cboFingerNo.Items.Add("Finger 2");
                else
                    cboRegisteredFingers.Items.Add("Finger 2");

                if (string.IsNullOrEmpty(_user.Finger3))
                    cboFingerNo.Items.Add("Finger 3");
                else
                    cboRegisteredFingers.Items.Add("Finger 3");
            }
            else
            {
                existing = false;
                cboFingerNo.Items.Add("Finger 1");
                cboFingerNo.Items.Add("Finger 2");
                cboFingerNo.Items.Add("Finger 3");
            }


            lblId.Text = emp.Code;
            lblName.Text = emp.Name;
            if (cboFingerNo.SelectedIndex > -1)
                btnReg.Enabled = true;
            else
                btnReg.Enabled = false;

        }

        private void EnableControls(bool bEnable)
        {
            // Do not change the state control during application closing.
            if (m_bExit)
                return;
            if (this.InvokeRequired)
            {
                EnableControlsCallback d = new EnableControlsCallback(this.EnableControls);
                this.Invoke(d, new object[] { bEnable });
            }
            else
            {
                btnReg.Enabled = bEnable;
                btnVerify.Enabled = bEnable;
                cboFingerNo.Enabled = bEnable;
                btnStop.Enabled = !bEnable;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            if (enrollOperation != null)
                enrollOperation.OnCalcel();

            if (identifyOperation != null)
                identifyOperation.OnCalcel();

            EnableControls(true);
        }

        //private void SetIdentificationLimit(int nLimit)
        //{
        //    if (this.m_lblIdentificationsLimit.InvokeRequired)
        //    {
        //        SetIdentificationLimitCallback d = new SetIdentificationLimitCallback(this.SetIdentificationLimit);
        //        this.Invoke(d, new object[] { nLimit });
        //    }
        //    else
        //    {
        //        if (nLimit == Int32.MaxValue)
        //        {
        //            m_lblIdentificationsLimit.Text = "Identification limit: No limits";
        //        }
        //        else
        //        {
        //            m_lblIdentificationsLimit.Text = String.Format("Identification limit: {0}", nLimit);
        //        }
        //    }
        //}
        //private void OnGetBaseTemplateComplete(bool bSuccess, int nRetCode)
        //{
        //    //exist = false;
        //    //isregister = true;
        //    StringBuilder szMessage = new StringBuilder();
        //    if (bSuccess)
        //    {
        //        //this.SetStatusText("Starting identification...");
        //        this.SetStatusText(szMessage.ToString());

        //        // unregister events
        //        m_Operation.OnPutOn -= new OnPutOnHandler(this.OnPutOn);
        //        m_Operation.OnTakeOff -= new OnTakeOffHandler(this.OnTakeOff);
        //        m_Operation.UpdateScreenImage -= new UpdateScreenImageHandler(this.UpdateScreenImage);
        //        //  m_Operation.OnFakeSource -= new OnFakeSourceHandler(this.OnFakeSource);
        //        ((FutronicIdentification)m_Operation).OnGetBaseTemplateComplete -=
        //                new OnGetBaseTemplateCompleteHandler(this.OnGetBaseTemplateComplete);

        //        m_OperationObj = null;
        //        EnableControls(true);

        //        //if (exist == false)
        //        //    if (isregister == true)
        //        //        btnReg_Click(null, null);

        //    }
        //}

        private void cboFingerNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFingerNo.SelectedIndex > -1)
                btnReg.Enabled = true;
            else
                btnReg.Enabled = false;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            isregister = false;
            btnReg.Enabled = false;
            enrollMode = false;
            duplicateFound = false;

            Identify();
        }

        private void btnDeleteFinger_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ret = FASHelper.DeleteFpUser(emp.FingerID);
            if (ret == 0 || ret == 2007)
                Globals.ShowMessage("Fingerprint User Deleted Successfully ...");

            frmFingerRegistration_Load(null, null);
        }
    }

}
