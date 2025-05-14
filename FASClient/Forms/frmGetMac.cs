using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using Usman.CodeBlocks.Crypto;

namespace FASClient
{
    public partial class frmGetMac : Form
    {
        int counter=0;
        string commKey = "";
        bool editMode = false;

        public frmGetMac()
        {
            InitializeComponent();
        }
        public void refreshList()
        {
            lvDetail.Items.Clear();
            foreach (FacDefinition f in Cache.facList )
            {
                ListViewItem item = new ListViewItem(f.FacID.ToString());
                item.SubItems.Add(f.Description);
                item.SubItems.Add(f.FacIP);
                lvDetail.Items.Add(item);
            }
        }
        private void GetMac_Load(object sender, EventArgs e)
        {
            Globals.MakeTransparent(this, lvDetail, lvDetail.Location.X, lvDetail.Location.Y);
            refreshList();
            //btnSave.Enabled = false;
            //button1.Enabled = false;
      
        }



        private void btnMac_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIp.Text))
            {
                Globals.ShowAlert("Enter Ip Address First");
                txtIp.Focus();
                return;
            }
            lblMac.Text = Globals.GetMacAddress(txtIp.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(commKey))
            //{
            //    MessageBox.Show("Key
            //}

            bool flag=true;
            byte idFac;
            int ret;
            if (string.IsNullOrEmpty(txtIp.Text))
            {
                Globals.ShowAlert("Enter IP Address First");
                txtIp.Focus();
                return;
            }

            //try
            //{
                //string MacAdd = GetMacAddress(txtIp.Text);
                idFac = byte.Parse(txtID.Text);
                if (!editMode)
                    ret = ExtendApi.FasSetFac(flag, idFac, txtIp.Text, true);
                else
                    ret = ExtendApi.FasSetFac(flag, idFac, txtIp.Text, false);

                if (ret == (int)ErrorCode.ERR_SUCCESS || ret == (int)ErrorCode.ERR_FAC_ID_EXIST)
                {
                    FacDefinition device = new FacDefinition(Convert.ToInt16(txtID.Text));
                    string mac = Globals.GetMacAddress(txtIp.Text);
                    mac = mac.Replace("-", "").Trim();
                    mac = mac.Replace(":", "").Trim();
                    device.Mac = mac;
                    device.Description = txtDescription.Text;
                    device.FacComm = StringCipher.Encrypt(mac);
                    if (checkBoxRestricted.Checked)
                        device.Restricted = 1;
                    else
                        device.Restricted = 0;
                    device.Update();

                    if (!editMode)
                    {                        
                        //device.FacID = Convert.ToInt16(txtID.Text);
                        //device.FacIP = txtIp.Text;
                        //device.Description = txtDescription.Text;
                        //device.FacComm = commKey;
                        //device.Flag = Convert.ToInt16(flag);
                        //device.Port_C = 5001;
                        //device.Port_S = 4900;

                        Cache.facList.Add(device);
                        //Cache.RestrictedDevices.Add(device);
                        Globals.ShowMessage("Device Added Successfully.\n\rReturn Code : " + ret.ToString());
                    }
                    else
                    {
                        device = Cache.facList.Where(x => x.FacID == byte.Parse(txtID.Text)).FirstOrDefault();
                        if (device != null)
                        {
                            device.FacIP = txtIp.Text;
                            device.Description = txtDescription.Text;
                            device.Mac = mac;
                            device.FacComm = commKey;
                            if (checkBoxRestricted.Checked)
                                device.Restricted = 1;
                            else
                                device.Restricted = 0;
                            Globals.ShowMessage("Device Updated Successfully.\n\rReturn Code : " + ret.ToString());
                        }
                    }

                    //device.Update();
                    //string query = "update facdefinition set Description='" + txtDescription.Text + "', faccomm = '" + commKey + "' where FacID=" + idFac + "";
                    //int i = SqlHelper.ExecuteNonQuery(Globals.GetConnectionString(), CommandType.Text, query);
                        
                }
                else
                {
                    if (!editMode)
                        Globals.ShowAlert("Device Not Added.\n\rReturn Code : " + ret.ToString());
                    else
                        Globals.ShowAlert("Device Not Updated.\n\rReturn Code : " + ret.ToString());
                }

                refreshList();
            //}
            //catch (Exception ex)
            //{
            //    Globals.ShowException("Device Saving Failed\n\rPossible Cause: " + ex.Message);
            //}
            //lblMac.Text = ExtendErr.GetErrorMessage(ret);
            //EnableControls(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
                return;

            int ret;
            byte idFac = byte.Parse(txtID.Text);

            try
            {
                ret = ExtendApi.FasInitFac(idFac, true);
                if (ret == (int)ErrorCode.ERR_SUCCESS)
                    Globals.ShowMessage("Machine Initialized Successfully ...");
                else
                    Globals.ShowMessage(ExtendErr.GetErrorMessage(ret) + "\n\rReturn Code: " + ret.ToString());
            }
            catch (Exception ex)
            {
                Globals.ShowException("Device Initialization Failed\n\rPossible Cause: " + ex.Message);
            }
        }

        private void lvDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDetail.SelectedItems.Count <= 0)
                return;

            lblMac.Text = "";
            var item = lvDetail.SelectedItems[0];
            FacDefinition device = Cache.facList.Find(x => x.FacID == byte.Parse(item.Text));
            txtID.Text = device.FacID.ToString();
            txtDescription.Text = device.Description;
            txtIp.Text = device.FacIP;
            if (device.Restricted == 1)
                checkBoxRestricted.Checked = true;
            else
                checkBoxRestricted.Checked = false;
            //btnSave.Enabled = true;
            editMode = true;
            button1.Enabled = true;
        }

        private void lblMac_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtIp.Text = "";
            txtDescription.Text = "";
            txtKey.Text = "";
            commKey = "";
            editMode = false;
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {

        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIp.Text))
            {
                Globals.ShowAlert("Please input IP Address first.");
                txtIp.Focus();
                return;
            }

            fileDialog.FileName = "";
            fileDialog.Filter = "DDS Key File (*.key) | *.key";
            fileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(fileDialog.FileName))
            {
                String enkey = System.IO.File.ReadAllText(fileDialog.FileName);
                string key = Usman.CodeBlocks.Crypto.StringCipher.Decrypt(enkey).Replace("-", "").Trim().Replace(":", "").Trim();
                //string mac = Usman.CodeBlocks.Networking.NetworkHelper.GetMac(txtIp.Text.Trim());
                string mac = Globals.GetMacAddress(txtIp.Text);
                mac = mac.Replace("-", "").Trim().Replace(":", "").Trim();
                //while (string.IsNullOrEmpty(mac))
                //{
                //    mac = Globals.GetMacAddress(txtIp.Text);
                //}

                if (mac == key)
                {
                    txtKey.Text = "Validated Successfully";
                    commKey = enkey;
                    btnSave.Enabled = true;
                }
                else
                {
                    txtKey.Text = "Not Validated. Try Again";
                    commKey = "";
                    btnSave.Enabled = false;
                }
            }
        }
    }
}
