using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Futronic.MfAPIHelper;
using System.Threading;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using FASClient.Forms;

namespace FASClient

{
    public partial class FrmcardUtility : Form
    {
        public Employee emp;
        string groupID = "0";
        string workingUserID = "";

        bool isThread = false;
        Thread thread;
        public bool userAdded = false;
        private Device m_hDevice;
        private bool m_bCancelOperation;
        public OperationParameters m_params;
        public ulong UID;
        public bool eraseMode = false;
        public bool editMode = false;
        bool cardRegistered = false;
        string pin = "";
        private delegate void OnShowMessageHandler(String value);
        private delegate void OnCompleteHandler(DeviceSequence ds, bool bResult);
        bool hasError = false;

        public FrmcardUtility()
        {
            InitializeComponent();
            m_params = new OperationParameters();
        }
        public OperationParameters Parameters
        {
            get
            {
                return m_params;
            }
        }
        private void WorkingThread(Object param)
        {
            ThreadParameters parameters = (ThreadParameters)param;

            switch (parameters.currentOperation)
            {
                case Operations.erase_card:
                    Operation_EraseCardThread(parameters.ds, parameters.opParameters);
                    break;
                case Operations.format_card:
                    Operation_FormatCardThread(parameters.ds, parameters.opParameters);
                    break;
                case Operations.add_cou_wo_finger:
                    Operation_Add_Cou_Wo_Finger(parameters.ds, parameters.opParameters);
                    break;
                case Operations.save_cou_to_card:
                    Operation_StoreCoUToCardThread(parameters.ds, parameters.opParameters);
                    break;
                case Operations.show_csn:
                    Operation_ShowCSNThread(parameters.ds, parameters.opParameters);
                    break;
                default:
                    break;
            }
        }

        private void Operation_FormatCardThread(DeviceSequence ds, OperationParameters param)
        {
            bool bResult = false;
            uint memSize = 0;

            try
            {
                WaitCard(ds, "Put card ...");

                this.ShowMessage("Please KEEP card on reader");

                ds.FormatCard(ref memSize);
                this.ShowMessage(String.Format("Card format successfull, {0} bytes free", memSize));

                bResult = true;
            }
            catch (MfAPIException ex)
            {
                MessageBox.Show(String.Format("Format card operation failed. {0}", Globals.MfAPIException2ErrorMessage(ex)));
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Format card operation failed. Unknown error: {0}", ex.Message));
            }
            this.OnComplete(ds, bResult);
        }

        private void Operation_EraseCardThread(DeviceSequence ds, OperationParameters param)
        {
            bool bResult = false;
            uint memSize = 0;

            try
            {
                WaitCard(ds, "Put card ...");

                this.ShowMessage("Please KEEP card on reader");

                ds.EraseDataFromCard(param.masterPIN, ref memSize);
                this.ShowMessage(String.Format("Erase card successfull, {0} bytes free", memSize));

                bResult = true;
            }
            catch (MfAPIException ex)
            {
                MessageBox.Show(String.Format("Erase card operation failed. {0}", Globals.MfAPIException2ErrorMessage(ex)));
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Erase card operation failed. Unknown error: {0}", ex.Message));
            }
            this.OnComplete(ds, bResult);
        }
        private void Operation_ShowCSNThread(DeviceSequence ds, OperationParameters param)
        {
            bool bResult = false;
            byte cardType = 0;
            UInt64 cardSN = 0;
            //UInt64 cardSNa = 0;

            try
            {
                WaitCard(ds, "Put card ...");
                //
                // get card information
                //
                if (!ds.ActivateIdle8bSN(ref cardType, ref cardSN))
                    throw new ApplicationException("No card present");// work to do here
                string cardSNa = String.Format(cardSN.ToString("X8"));
                string query = "update Employee set uid = '"+cardSNa+"' where Code = '"+emp.Code+"'";
                int result = SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, query);
                this.ShowMessage(String.Format("Card SN : {0}", cardSN.ToString("X8")));
                Globals.ShowMessage("Template saved successfully ...");
                bResult = true;
                frmRestrictedMachines frmRestricted = new frmRestrictedMachines(emp);
                frmRestricted.ShowDialog(); 
            }
            catch (MfAPIException ex)
            {
               // MessageBox.Show(String.Format("Get card SN operation failed. {0}", MfAPIException2ErrorMessage(ex)));
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Get card SN operation failed. Unknown error: {0}", ex.Message));
            }
            ds.Close(); //usama
       //     this.OnComplete(ds, bResult);
        }

        private void Operation_StoreCoUToCardThread(DeviceSequence ds, OperationParameters param)
        {
            bool bResult = false;
            hasError = false;

            try
            {
                WaitCard(ds, "Please put master card ...");
                this.ShowMessage("Please KEEP card on reader");
                ds.LoadKeysFromMasterCard(param.masterPIN);
                RemoveCard(ds, "Please remove master card ...");


                WaitCard(ds, "Please put empty card ...");
                this.ShowMessage("Please KEEP card on reader");

                ds.SaveUserToCard(param.UserID);
                this.ShowMessage("Write user to card successfully");
                UID = param.UserID;
                bResult = true;
                cardRegistered = true;
                userAdded = false;
                
            }
            catch (MfAPIException ex)
            {
                //MessageBox.Show("Put Valid Card");
                Globals.ShowException(String.Format("Write user to card operation failed. {0}\n{1}", Globals.MfAPIException2ErrorMessage(ex),"PUT VALID CARD"));
                //m_hDevice.Close();
                //m_hDevice.Dispose();
                hasError = true;

            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Write user to card operation failed. Unknown error: {0}", ex.Message));
            }
            this.OnComplete(ds, bResult);
        }
        private void RemoveCard(DeviceSequence ds, String message)
        {
            this.ShowMessage(message);
            while (!this.m_bCancelOperation && ds.IsCardPresent()) ;
            if (this.m_bCancelOperation)
                throw new ApplicationException("Operation canceled by user.");
        }
        private void WaitCard(DeviceSequence ds, String message)
        {
            this.ShowMessage(message);
            while (!this.m_bCancelOperation && !ds.IsCardPresent()) ;
            if (this.m_bCancelOperation)
                throw new ApplicationException("Operation canceled by user.");
        }
        void SaveTemplateFile(ulong uid)
        {
            //
            // try getting exclusive lock to the device
            //
            DeviceSequence ds = null;
            byte[] template = null;


            if (m_hDevice.TryToStartSequence(ref ds))
            {
                List<UserInformation> userlist = ds.GetUsersInformation().ToList();
                UserInformation ui = userlist.Find(x => x.UserID == uid);
                UInt64 userID = ui.UserID | ((UInt64)ui.FingerID << 48) | ((UInt64)ui.FingerID << 56);

                try
                {
                    template = ds.GetTemplate(userID);
                }
                catch (MfAPIException ex)
                {
                    Globals.ShowException(String.Format("Delete user operation failed. {0}", Globals.MfAPIException2ErrorMessage(ex)));
                }
                catch (Exception ex)
                {
                    Globals.ShowException(String.Format("Delete user operation failed. Unknown error: {0}", ex.Message));
                }

                ds.Close();
                if (template != null)
                {
                    String szFileName;
                    string userName = UID.ToString() + "_0.tml";
                    
                    szFileName = Path.Combine(Globals.templateFolder, userName);
                    #region oldCode
                    //File.Create(szFileName).Close();
                    
                    ////SaveFileDialog sfd = new SaveFileDialog();
                    ////sfd.DefaultExt = ".tml";
                    ////sfd.Filter = "Template files|*.tml|All files|*.*";
                    ////sfd.FileName = userID.ToString("X12");
                    ////sfd.OverwritePrompt = true;
                    ////sfd.CreatePrompt = false;
                    ////sfd.CheckPathExists = true;
                    ////sfd.ValidateNames = true;
                    ////sfd.Title = "Select file to save template";
                    ////if (sfd.ShowDialog() == DialogResult.OK)
                    ////{
                    //Stream writer;
                    //writer = File.OpenWrite(szFileName);
                    //if (writer != null)
                    //{
                    //    try
                    //    {
                    //        writer.Write(template, 0, template.Length);
                    //        MessageBox.Show(String.Format("Template saved successfully into file {0}.", szFileName), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //    catch (IOException)
                    //    {
                    //        MessageBox.Show(String.Format("Can not write data into file {0}.", szFileName), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //    writer.Close();
                    //}
                    //else
                    //{
                    //    MessageBox.Show(String.Format("Can not create file {0}.", szFileName), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    ////}
                    #endregion

                    SaveTemplate(szFileName, template, userName);
                    int ret = Synchronize(szFileName);

                    lblMessage.Text = "Result : " + ExtendErr.GetErrorMessage(ret);
                }
            }
            else
            {
                Globals.ShowMessage("Access denied. Can not get exclusive lock to the device.");
            }
        }

        private int intializeFAS()
        {
            string connstring = Globals.GetConnectionString();
            string[] cstr = connstring.Split(';');
            string[] newstr = cstr[0].Split('=');
            string serverstr = newstr[1].ToUpper();
            serverstr = serverstr.Replace("\\SQLEXPRESS", "").Trim();
            int ret = ExtendApi.FasInitializeWithPassword(serverstr, 4900, "welcome");
            return ret;
        }

        public int nLength { get; set; }
        public int Synchronize(string fileName)
        {
            return FASHelper.AddCardUser(fileName, emp.CardID, emp.Name,groupID);
        }
        
        private bool SaveTemplate(String szFileName, byte[] m_Template, string m_UserName)
        {
            if (m_Template == null || m_UserName == String.Empty)
                throw new InvalidOperationException();

            Stream writer;
            writer = File.OpenWrite(szFileName);
            if (writer != null)
            {
                try
                {
                    writer.Write(m_Template, 0, m_Template.Length);
                    return true;
                }
                catch (IOException ex)
                {
                    Globals.ShowException(ex.Message);
                    return false;
                }
                finally
                {
                    writer.Close();
                }
            }
            else
            {
                Globals.ShowMessage("File Cant be Accessed");
                return false;
            }            
        }

        private void OnComplete(DeviceSequence ds, bool bResult)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new OnCompleteHandler(this.OnComplete), new Object[] { ds, bResult });
            }
            else
            {
                ds.Close();
                // OnOperationStart(false);
                //GetUser();
                if (cardRegistered)
                {
                    // save template file

                   
                    SaveTemplateFile(UID);
                    OnCardAdmin_ShowCSN();
                    //Globals.fpTemplates.Add(User);
                    //string query = "insert into registration (uid,fingerno,registeredOn,registeredby,synchronized,synchronizedOn,synchronizedBy) values('" + UID.ToString() + "', " + 0 + ",'" + DateTime.Now + "','" + Globals.User.LoginID + "'," + 0 + ",'" + null + "','" + null + "')";
                    //if (SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, query) >= 1)
                    //{
                    //    //Futronic.SDK.WorkedEx.DbRecord User = new Futronic.SDK.WorkedEx.DbRecord();

                    //   // Globals.fpTemplates.Add(User);
                    //}
                }
                if(hasError)
                {
                    btnReg.Enabled = true;
                    hasError = false;
                    return;
                }
                if (userAdded == true)
                    Enroll();
                //OnCardAdmin_ShowCSN();
            }
        }

        void GetUser()
        {
            //
            // Check User ID value
            //
            //UInt64 userID;
            //if (!UInt64.TryParse(txtUID.Text, out userID))
            //{
            //    MessageBox.Show("Invalid user ID", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtUID.Focus();
            //    return;
            //}
            //if (userID > 0xFFFFFFFFFFFF)
            //{
            //    MessageBox.Show("Invalid User ID", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtUID.Focus();
            //    return;
            //}
            //m_params.UserID = userID;


            //m_params.Flag = (byte)UserFlags.CardOnlyUser;
            //m_params.bits = ParameterFields.pf_userID | ParameterFields.pf_Flag;
            // with master storing now

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void ShowMessage(String szMessage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new OnShowMessageHandler(this.ShowMessage), new Object[] { szMessage });
            }
            else
            {
                lblMessage.Text = szMessage;
            }
        }
        private void Operation_Add_Cou_Wo_Finger(DeviceSequence ds, OperationParameters param)
        {
            bool bResult = false;
            try
            {
                this.ShowMessage("Adding user ...");
                try
                {
                    ds.DeleteUser(param.UserID);
                }
                catch (MfAPIException ex)
                {
                    //if(!ex.ErrorCode.Equals(FTR_ERROR_CODES.MF_UNKNOW_USER.ToString()))
                    //    MessageBox.Show(String.Format("Card only user without finger without PIN operation failed.\n{0}", Globals.MfAPIException2ErrorMessage(ex)));
                }
                
                ds.AddUser(param.UserID, param.Flag);
                //this.ShowMessage("Card only user without finger without PIN saved successfully");
                bResult = true;
            }
            catch (MfAPIException ex)
            {
                MessageBox.Show(String.Format("Card only user without finger without PIN operation failed.\n{0}", Globals.MfAPIException2ErrorMessage(ex)));
                if (ex.ErrorCode.Equals(FTR_ERROR_CODES.MF_USER_ID_ALREADY_EXIST.ToString())) {

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Card only user without finger without PIN operation failed. Unknown error: {0}", ex.Message));
            }
            userAdded = true;
            this.OnComplete(ds, bResult);
        }
        private void ShowError(MfAPIException ex)
        {
            String szMessage = Globals.MfAPIException2ErrorMessage(ex);
            MessageBox.Show(szMessage);
        }

        string GetGroupID(string category)
        {
            switch (category)
            {
                case Constant.Student:
                    return "12";
                case Constant.Staff:
                    return "22";
                case Constant.Resident:
                    return "32";
                case Constant.Visitor:
                    return "42";

                default:
                    return "0";
            }
        }

        private void FrmcardUtility_Load(object sender, EventArgs e)
        {
            this.Visible = true;
            lblName.Text = emp.Name;
            lblID.Text = emp.Code;
            txtpin.Text = Globals.MasterPIN;

            if (!string.IsNullOrEmpty(emp.CardID))
            {
                User user = new User(emp.CardID);
                if (!string.IsNullOrEmpty(user.UID))
                {
                    editMode = true;
                    workingUserID = user.UID;
                    groupID = user.GID.ToString();
                }
                else
                {
                    editMode = false;
                    workingUserID = emp.CardID;
                    groupID = Constant.getCardUserGID(emp.Section);
                }
            }

            //OPen device
            try
            {
                m_hDevice = new Device();
                m_hDevice.Open();

                // gets devce parameters
                VersionInfo version = m_hDevice.VersionInformation;



                // Enable menu items
                //
                //btnStart.Enabled = true;
            }
            catch (MfAPIException ex)
            {
                if (m_hDevice != null)
                {
                    m_hDevice.Dispose();
                    m_hDevice = null;
                }
                new frmMessageBox(MessageBoxType.Alert, "Device Not Connected..." + Environment.NewLine + "Please replug device").ShowDialog();
                this.Close();
            }
            //.Device Open end here

           
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnErase_Click(object sender, EventArgs e)
        {

        }

        private void FrmcardUtility_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isThread)
            {
                if (thread.IsAlive)
                    thread.Suspend();
            }

            if (m_hDevice != null)
                m_hDevice.Close();
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtpin.Text))
            {
                new frmMessageBox(MessageBoxType.Alert, "Enter Master Pin #").ShowDialog();
                return;
            }
            //btnErase.Enabled = false;
            pin = txtpin.Text;
            ///aDDING USER
            UInt64 userID;
            if (!UInt64.TryParse(workingUserID, out userID))
            {
                new frmMessageBox(MessageBoxType.Alert, "Invalid User ID").ShowDialog();
                return;
            }
            if (userID > 0xFFFFFFFFFFFF)
            {
                new frmMessageBox(MessageBoxType.Alert, "Invalid User ID").ShowDialog();
                return;
            }

            // start process
            btnReg.Enabled = false;

            m_params.UserID = userID;


            m_params.Flag = (byte)UserFlags.CardOnlyUser;
            m_params.bits = ParameterFields.pf_userID | ParameterFields.pf_Flag;

            if (editMode)
            {
                User user = new User(workingUserID);
                if (!string.IsNullOrEmpty(user.UID))
                {
                    int ret = FASHelper.DeleteCardUser(workingUserID);
                    if (ret == 0 || ret == 2007)
                    {
                        //// update employee
                        //emp.CardID = "";
                        //emp.Update(false);
                    }
                    string result = ExtendErr.GetErrorMessage(ret);
                }
            }
            //OnCardAdmin_ShowCSN();

            #region card
            DeviceSequence ds = null;
            if (m_hDevice.TryToStartSequence(ref ds))
            {
                //
                // Disable all controls
                //
                //OnOperationStart(true);
                //m_bCancelOperation = false;

                //ds.DeletAllUsers();

                //UserInformation[] info = ds.GetUsersInformation();

                ThreadParameters tp = new ThreadParameters();
                tp.ds = ds;
                tp.currentOperation = Operations.add_cou_wo_finger;
                tp.opParameters = this.Parameters;
                thread = new Thread(this.WorkingThread);
                isThread = true;
                thread.IsBackground = true;
                thread.Start(tp);
             
            }
            else
            {
                new frmMessageBox(MessageBoxType.Alert, "Access Denied").ShowDialog();
            }
           
            #endregion
        }
        private void OnCardAdmin_ShowCSN()
        {
            //
            // try getting exclusive lock to the device
            //
            DeviceSequence ds = null;
            if (m_hDevice.TryToStartSequence(ref ds))
            {
                //
                // Disable all controls
                //
                //OnOperationStart(true);
                m_bCancelOperation = false;

                ThreadParameters tp = new ThreadParameters();
                tp.ds = ds;
                tp.currentOperation = Operations.show_csn;

                tp.opParameters = new OperationParameters();
                Thread thread = new Thread(this.WorkingThread);
                thread.IsBackground = true;
                thread.Start(tp);
            }
            else
            {
                MessageBox.Show("Access denied. Can not get exclusive lock to the device.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Enroll()
        {
            m_params.masterPIN = pin;
            m_params.bits = ParameterFields.pf_masterPIN | ParameterFields.pf_userID;
            DeviceSequence ds = null;
            if (m_hDevice.TryToStartSequence(ref ds))
            {
                //
                // Disable all controls
                //

                m_bCancelOperation = false;

                ThreadParameters tp2 = new ThreadParameters();
                tp2.ds = ds;
                tp2.currentOperation = Operations.save_cou_to_card;

                tp2.opParameters = this.Parameters;

                thread = new Thread(this.WorkingThread);
                thread.IsBackground = true;
                thread.Start(tp2);
            }
            else
            {
                new frmMessageBox(MessageBoxType.Alert, "Access Denied").ShowDialog();
            }
        }

        private void utilityBtn_Click(object sender, EventArgs e)
        {
            FrmCardMaster f = new FrmCardMaster();
            f.ShowDialog();
        }
    }
}
