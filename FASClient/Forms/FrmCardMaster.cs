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
using FASClient.Forms;
using System.IO;

namespace FASClient
{
    public partial class FrmCardMaster : Form
    {
        public string sValue="";
       // public string masterCardSR="";
        public bool isThread = false;
        public OperationParameters m_params;
        private Device m_hDevice;
        private bool m_bCancelOperation;
        private delegate void OnShowMessageHandler(String value);
        private delegate void OnCompleteHandler(DeviceSequence ds, bool bResult);
        Thread thread;
        
        
        public FrmCardMaster()
        {
            InitializeComponent();
        }
        public OperationParameters Parameters
        {
            get
            {
                return m_params;
            }
        }

        public string masterCardSR { get;  set; }

        static public String MfAPIException2ErrorMessage(MfAPIException ex)
        {
            String szMessage;
            switch ((FTR_ERROR_CODES)ex.ErrorCode)
            {
                case FTR_ERROR_CODES.MF_CARD_TYPE_INVALID:
                    szMessage = "Invalid card type.";
                    break;

                case FTR_ERROR_CODES.MF_NO_CARD:
                    szMessage = "No card in reader field.";
                    break;

                case FTR_ERROR_CODES.MF_INVALID_CARD_KEY:
                    szMessage = "Invalid card key.";
                    break;

                case FTR_ERROR_CODES.MF_CARD_NOT_EMPTY:
                    szMessage = "Card is not empty.";
                    break;

                case FTR_ERROR_CODES.MF_CARD_WRITE_ERROR:
                    szMessage = "Can not write data into the card.";
                    break;

                case FTR_ERROR_CODES.MF_CARD_READ_ERROR:
                    szMessage = "Can not read data from the card.";
                    break;

                case FTR_ERROR_CODES.MF_CARD_INVALID_FORMAT:
                    szMessage = "The card has invalid format.";
                    break;

                case FTR_ERROR_CODES.MF_NO_IMAGE:
                    szMessage = "No image.";
                    break;

                case FTR_ERROR_CODES.MF_BAD_QUALITY:
                    szMessage = "Bad quality.";
                    break;

                case FTR_ERROR_CODES.MF_EMPTY_BASE:
                    szMessage = "No any templates in local database";
                    break;

                case FTR_ERROR_CODES.MF_UNKNOW_USER:
                    szMessage = "Compare sample with local database unsuccessfull";
                    break;

                case FTR_ERROR_CODES.MF_BAD_ARGUMENT:
                    szMessage = "Bad parameters.";
                    break;

                case FTR_ERROR_CODES.MF_FAKE_FINGER:
                    szMessage = "Fake finger detected.";
                    break;

                case FTR_ERROR_CODES.MF_CRC_ERROR:
                    szMessage = "CRC error.";
                    break;

                case FTR_ERROR_CODES.MF_RXD_TIMEOUT:
                    szMessage = "Timeout error.";
                    break;

                case FTR_ERROR_CODES.MF_RECORD_EMPTY:
                    szMessage = "The record is empty.";
                    break;

                case FTR_ERROR_CODES.MF_RECORD_INVALID:
                    szMessage = "The record is invalid.";
                    break;

                case FTR_ERROR_CODES.MF_USER_ID_IS_ABSENT:
                    szMessage = "Template with requested UserID not exist in database";
                    break;

                case FTR_ERROR_CODES.MF_USER_ID_ALREADY_EXIST:
                    szMessage = "The UserID already exists.";
                    break;

                case FTR_ERROR_CODES.MF_SRXD_TIMEOUT:
                    szMessage = "SRXD timeout error.";
                    break;

                case FTR_ERROR_CODES.MF_USER_SUSPENDET:
                    szMessage = "The user is suspended.";
                    break;

                case FTR_ERROR_CODES.MF_UNKNOWN_COMMAND:
                    szMessage = "Unknown command.";
                    break;

                case FTR_ERROR_CODES.MF_IMAGE_MOVED:
                    szMessage = "Finger image is moved.";
                    break;

                case FTR_ERROR_CODES.MF_HARDWARE_ERROR:
                    szMessage = "Hardware error.";
                    break;

                case FTR_ERROR_CODES.MF_BAD_FLASH:
                    szMessage = "Bad flash.";
                    break;

                case FTR_ERROR_CODES.MF_RESULT_TOO_MANY_VIP:
                    szMessage = "Limit for VIP users exceed";
                    break;

                case FTR_ERROR_CODES.MF_TOO_BIG_GROUP:
                    szMessage = "Limit for users in one group exceed";
                    break;

                case FTR_ERROR_CODES.MF_WRITE_ERROR:
                    szMessage = "Write error.";
                    break;

                case FTR_ERROR_CODES.MF_RESULT_COMPARE_ERROR:
                    szMessage = "Result compare error.";
                    break;

                case FTR_ERROR_CODES.MF_RESULT_NO_SPACE:
                    szMessage = "No free space.";
                    break;

                default:
                    szMessage = String.Format("Unknown error code: {0}", ex.ErrorCode);
                    break;
            }

            return szMessage;
        }

        void UpdateConfigFile(string pin)
        {
            // save in textfile
            string configFile = Application.StartupPath + "\\config.dds";
            string[] text = File.ReadAllLines(configFile);
            string newValue = "";
            foreach(string line in text)
            {
                if (line.Contains("MasterPIN"))
                    newValue = newValue + "MasterPIN=" + pin + "\n";
                else
                    newValue = newValue + line + "\n";
            }

            File.WriteAllText(configFile, newValue);

        }

        private void Operation_MakeMasterCardThread(DeviceSequence ds, OperationParameters param)
        {
            bool bResult = false;

            try
            {
                ds.MakeCardKeys();

                WaitCard(ds, "Put empty card ...");

                this.ShowMessage("Please KEEP card on reader");

                ds.StoreKeysToMasterCard(param.masterPIN);
                UpdateConfigFile(param.masterPIN);
                this.ShowMessage("Master Card Made Successfully\nMaster PIN : " + param.masterPIN);
                
                bResult = true;
            }
            catch (MfAPIException ex)
            {
               // lblMessage.Text = "Operation Failed";
                MessageBox.Show(String.Format("Make master card operation failed. {0}", MfAPIException2ErrorMessage(ex)));
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Make master card operation failed. Unknown error: {0}", ex.Message));
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
                    throw new ApplicationException("No card present");
                string cardSNa = String.Format("Card SN : {0}", cardSN.ToString("X8"));
                this.ShowMessage(String.Format("Card SN : {0}", cardSN.ToString("X8")));
                bResult = true;
            }
            catch (MfAPIException ex)
            {
                MessageBox.Show(String.Format("Get card SN operation failed. {0}", MfAPIException2ErrorMessage(ex)));
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Get card SN operation failed. Unknown error: {0}", ex.Message));
            }
            this.OnComplete(ds, bResult);
        }

        private string Operation_ShowCSNThread(DeviceSequence ds, OperationParameters param , bool status)
        {
            bool bResult = false;
            byte cardType = 0;
            UInt64 cardSN = 0;
            string cardSNa = "";
            //UInt64 cardSNa = 0;

            try
            {
                WaitCard(ds, "Put card ...");
                //
                // get card information
                //
                if (!ds.ActivateIdle8bSN(ref cardType, ref cardSN))
                    throw new ApplicationException("No card present");
                cardSNa = String.Format(cardSN.ToString("X8"));
                bResult = true;
            }
            catch (MfAPIException ex)
            {
                MessageBox.Show(String.Format("Get card SN operation failed. {0}", MfAPIException2ErrorMessage(ex)));
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Get card SN operation failed. Unknown error: {0}", ex.Message));
            }
            ds.Close();
            foreach (var item in Cache.MasterCards)
            {
                if (item == cardSNa)
                {
                    if (btnErase.InvokeRequired)
                    {
                        btnErase.Invoke(new MethodInvoker(delegate 
                        {
                            btnErase.Enabled = false;
                        }
                        ));
                    }
                    else
                    {
                        btnErase.Enabled = false;
                    }
                    if (btnFormat.InvokeRequired)
                    {
                        btnFormat.Invoke(new MethodInvoker(delegate { btnFormat.Enabled = false; }));
                    }
                    else
                    {
                        btnFormat.Enabled = false;
                    }
                    frmMessageBox message = new frmMessageBox(MessageBoxType.Alert, "Master Card Detected.\nOperations Can't be performed.");
                    message.ShowDialog();
                    break;

                }
                else
                {
                   // lblinfo.Text = "Ready ...";

                }
            }
            return cardSNa;
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
                MessageBox.Show(String.Format("Erase card operation failed. {0}", MfAPIException2ErrorMessage(ex)));
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
        private void WaitCard(DeviceSequence ds, String message)
        {
            this.ShowMessage(message);
            while (!this.m_bCancelOperation && !ds.IsCardPresent()) ;
            if (this.m_bCancelOperation)
                throw new ApplicationException("Operation cancelled by user.");
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

                //OnOperationStart(false);
            }
        }
        
       private void RemoveCard(DeviceSequence ds, String message)
        {
            this.ShowMessage(message);
            while (!this.m_bCancelOperation && ds.IsCardPresent()) ;
            if (this.m_bCancelOperation)
                throw new ApplicationException("Operation canceled by user.");
        }
        private void ShowMessage(String szMessage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new OnShowMessageHandler(this.ShowMessage), new Object[] { szMessage });
            }
            else
            {
                lblinfo.Visible = true;
                lblinfo.Text = szMessage;
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
                MessageBox.Show(String.Format("Format card operation failed. {0}", MfAPIException2ErrorMessage(ex)));
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
        private void WorkingThread(Object param)
        {
            ThreadParameters parameters = (ThreadParameters)param;

            switch (parameters.currentOperation)
            {
                case Operations.show_csn:
                    Operation_ShowCSNThread(parameters.ds, parameters.opParameters);
                    break;
                case Operations.show_csn_masterCard:
                    masterCardSR=Operation_ShowCSNThread(parameters.ds, parameters.opParameters,true);
                    break;
                case Operations.erase_card:
                    Operation_EraseCardThread(parameters.ds, parameters.opParameters);
                    break;
                case Operations.make_mastercard:
                    Operation_MakeMasterCardThread(parameters.ds, parameters.opParameters);
                    break;
                case Operations.format_card:
                    Operation_FormatCardThread(parameters.ds, parameters.opParameters);
                    break;
                default:
                    break;
            }
        }
        private void btnErase_Click(object sender, EventArgs e)
        {
            //
            // get operation parameters
            //
            String sValue = "123456";
            
            m_params.masterPIN = sValue;
            m_params.bits = ParameterFields.pf_masterPIN;
            //
            // try getting exclusive lock to the device
            //
            DeviceSequence ds = null;
            if (m_hDevice.TryToStartSequence(ref ds))
            {
                //
                // Disable all controls
                //
                // OnOperationStart(true);
                m_bCancelOperation = false;

                ThreadParameters tp = new ThreadParameters();
                tp.ds = ds;
                tp.currentOperation = Operations.erase_card;

                tp.opParameters = this.Parameters;

                thread = new Thread(this.WorkingThread);
                isThread = true;
                thread.IsBackground = true;
                thread.Start(tp);
            }
            else
            {
                MessageBox.Show("Access denied. Can not get exclusive lock to the device.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
           

            DeviceSequence ds = null;
            if (m_hDevice.TryToStartSequence(ref ds))
            {
                //
                // Disable all controls
                //
                m_bCancelOperation = false;

                ThreadParameters tp = new ThreadParameters();
                tp.ds = ds;
                tp.currentOperation = Operations.format_card;

                tp.opParameters = new OperationParameters();

                thread = new Thread(this.WorkingThread);
                isThread = true;
                thread.IsBackground = true;
                thread.Start(tp);
            }
            else
            {
                MessageBox.Show("Access denied. Can not get exclusive lock to the device.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCardMaster_Load(object sender, EventArgs e)
        {
            try
            {
                lblinfo.Text = "Ready ...";
                m_hDevice = new Device();
                m_hDevice.Open();
                m_params = new OperationParameters();
                checkmaster_card();
                //foreach (var item in Cache.MasterCards)
                //{
                //    if(item == masterCardSR)
                //    {
                //        btnErase.Enabled = false;
                //        btnFormat.Enabled = false;
                //        frmMessageBox message = new frmMessageBox(MessageBoxType.Alert, "Master Card Detected.\nOperations Can't be performed.");
                //        message.ShowDialog();
                //        break;
                //    }
                //}
                //lblinfo.Text = "Ready ...";

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
        }

        private void btnMaster_Click(object sender, EventArgs e)
        {
            frmMasterPin f = new frmMasterPin();
            f.pin = Globals.MasterPIN;
            f.ShowDialog();
            if (f.isCancelled)
                return;

            Globals.MasterPIN = f.pin;
            sValue = f.pin;
            
            if (string.IsNullOrEmpty(sValue))
                return;
            m_params.masterPIN = sValue;

            m_params.bits = ParameterFields.pf_masterPIN;

            DeviceSequence ds = null;
            if (m_hDevice.TryToStartSequence(ref ds))
            {
                //
                // Disable all controls
                //
               // OnOperationStart(true);
                m_bCancelOperation = false;

                ThreadParameters tp = new ThreadParameters();
                tp.ds = ds;
                tp.currentOperation = Operations.make_mastercard;

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
        }
        void checkmaster_card()
        {
            DeviceSequence ds = null;
            if (m_hDevice.TryToStartSequence(ref ds))
            {
                //
                // Disable all controls
                //
                // OnOperationStart(true);
                m_bCancelOperation = false;

                ThreadParameters tp = new ThreadParameters();
                tp.ds = ds;
                tp.currentOperation = Operations.show_csn_masterCard;

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

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCardMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isThread)
            {
                if (thread.IsAlive)
                    thread.Suspend();
            }
            //ds.Close();
            if (m_hDevice != null)
                m_hDevice.Close(); 
        }

       
    }
}
