using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using FASClient.Forms;
using FASClient.Properties;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using FASClient.Classes;

namespace FASClient
{
    public partial class frmUserInfo : Form
    {
        bool newImage = false;
        public bool editMode = false;
        public Employee employee;

        public List<tbl_Building> BuildingList { get; set; }

        public frmUserInfo()
        {
            InitializeComponent();
        }

        
        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            this.Text = Globals.GetAppTitle() + " v" + Application.ProductVersion;
            btnClear_Click(null, null);
            fill_cbobuilding();
            fillCboSection();

            List<string> depts = Cache.employeeList.Select(x => x.Department).Distinct().ToList().Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            depts.Sort();
            cboDepartment.DataSource = depts;

            List<string> desigs = Cache.employeeList.Select(x => x.Designation).Distinct().ToList().Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            //desigs.Sort();
            cboDesignation.DataSource = desigs;

            //List<string> secs = Cache.employeeList.Select(x => x.Section).Distinct().ToList();
           // cboSection.DataSource = secs;

            btnPrintVerification.Enabled = false;
            
            if (editMode)
            {
                TextBoxFill(employee);
            }

            
        }
        void fill_cbobuilding()
        {
            tbl_Building _Building = new tbl_Building();
            _Building.Building_Name = "-Select Value-";
            _Building.Description = "0 Index";
            _Building.ID = 0;
            BuildingList = Globals.ConvertDataTable<tbl_Building>(tbl_Building.GetAll());
            BuildingList.Add(_Building);
            BuildingList[BuildingList.Count-1] = BuildingList[0];
            BuildingList[0]=_Building;

            cboSeries.DataSource = BuildingList;
            cboSeries.DisplayMember = "Building_Name";
            cboSeries.ValueMember = "ID";

        }
        void fillCboSection()
        {
            cboSection.Items.Add(Constant.Student);
            cboSection.Items.Add(Constant.Staff);
            cboSection.Items.Add(Constant.Visitor);
            cboSection.Items.Add(Constant.Resident);
            cboSection.Items.Add(Constant.Alumni);
            cboSection.Items.Add(Constant.T6);
            cboSection.Items.Add(Constant.T7);
            cboSection.Items.Add(Constant.T8);
        }

        void TextBoxFill(Employee emp)
        {
            if (emp != null)
            {
                txtID.Text = emp.Code;
                chkReportingPerson.Checked = emp.ReportingPerson;
                txtName.Text = emp.Name;
                txtFatherName.Text = emp.FatherName;
                txtCNIC.Text = emp.NIC;
                cboDepartment.Text = emp.Department;
                cboDesignation.Text = emp.Designation;
               // cboSection.Text = emp.Section;
                switch (emp.Section.Trim())
                {
                    case Constant.Student:
                        {
                            cboSection.Text = Constant.Student;
                            break;
                        }
                        //case Constant.Staff:
                        //    {
                        //        lblDate.Text = "Issue Date :";
                        //        cboSection.Text = Constant.Staff;
                        //        break;
                    case Constant.Staff:
                        lblDate.Text = "Issue Date :";
                        cboSection.Text = Constant.Staff;
                        break;

                    case Constant.Resident:
                        {
                            cboSection.Text = Constant.Resident;
                            break;
                        }
                    case Constant.Visitor:
                        {
                            cboSection.Text = Constant.Visitor;
                            break;
                        }
                    case Constant.Alumni:
                        {
                            cboSection.Text = Constant.Alumni;
                            break;
                        }
                }
                if (emp.BID != 0)
                {
                    cboSeries.SelectedValue = emp.BID;
                }
                else
                {
                    cboSeries.SelectedIndex = 0;
                }
                txtAddress.Text = emp.Address;
                txtContactNo.Text = emp.ContactNo;
                chkHostel.Checked = emp.Hostel;
                txtHostel.Text = emp.HostelName;
                chkKioskPerson.Checked = emp.KioskAdmin;
                //dtpValidity.Value = emp.Validity;
                txtEmail.Text = emp.Email;
                lblStatus.Text = emp.Suspend ? "SUSPENDED" : "ACTIVE";
                if (lblStatus.Text.ToLower().Equals("active"))
                    lblStatus.BackColor = Color.SeaGreen;
                else
                    lblStatus.BackColor = Color.DarkRed;

                picUser.Image = Properties.Resources._283;
                picWorker.RunWorkerAsync(emp);

                btnPrintVerification.Enabled = true;
                //Image img = emp.GetImage();
                //if (img != null)
                //    picUser.Image = img;

                User user = new User(emp.FingerID);
                if (user.UID != null) {
                    txtFingerID.Text = user.UID.ToString();
                    cboSection.Enabled = false;
                    txtID.Enabled = false;
                }
                else
                    txtFingerID.Text = "NOT REGISTERED";
                User user1 = new User(emp.CardID);
                if (user1.UID != null)
                {
                    txtCardID.Text = user1.UID.ToString();
                    cboSection.Enabled = false;
                    txtID.Enabled = false;
                }
                else
                    txtCardID.Text = "NOT REGISTERED";

                try
                {
                    dtpValidity.Value = emp.Date;

                }
                catch (Exception e) {
                }
                
            }
        }

        void ResetFields()
        {
            txtName.Text = "";
            txtFatherName.Text = "";
            txtCNIC.Text = "";
            cboDepartment.Text = "";
            cboDesignation.Text = "";
           // cboSection.Text = "";
            chkHostel.Checked = false;
            txtHostel.Text = "";
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtEmail.Text = "";
            dtpValidity.Value = DateTime.Today;
            picUser.Image = null;
            lblStatus.Text = "";
            cboSection.Text = Constant.Student;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ResetFields();
                Employee emp = Cache.employeeList.Find(x => x.Code == txtID.Text);
                if (emp != null)
                    TextBoxFill(emp);
                else
                    Globals.ShowMessage("User Not Found.");
            }
        }       

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtName.Text = txtName.Text.ToUpper();
        }
        

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "PNG files (*.png)|*.png|Jpeg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picUser.Image = new Bitmap(dlg.FileName);
                picUser.Tag = dlg.FileName;
                //imagePath = dlg.FileName;
                newImage = true;
            }
            else
                newImage = false;

            dlg.Dispose();
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            if (picUser.Image == null)
                return;
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                if (MessageBox.Show("Do you want to Remove image??", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    newImage = false;
                    //if (employee.ClearImage())
                    //    Globals.ShowMessage("User Image Cleared Successfully ...");
                    //else
                    //    Globals.ShowMessage("User Image Cleared Successfully.\n\rTry Again Later");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                Globals.ShowMessage("Please Enter ID First.");
                txtID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                Globals.ShowAlert("Please Enter Name Also.");
                txtName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cboDepartment.Text))
            {
                Globals.ShowAlert("Please Enter/Select Department Also.");
                cboDepartment.Focus();
                return;
            }
            /*
            if (string.IsNullOrEmpty(cboSection.Text))
            {
                Globals.ShowAlert("Please Enter/Select Category Also.");
                cboSection.Focus();
                return;
            }*/
            if (string.IsNullOrEmpty(cboSection.Text))
            {
                Globals.ShowAlert("Please Check Category Also.");
                //cboSection.Focus();
                return;
            }

            string cnic = txtCNIC.Text.Replace("-", "").Trim();
            if (!string.IsNullOrEmpty(cnic) && cnic.Length < 13)
            {
                Globals.ShowAlert("Invalid CNIC.\n\rPlease Enter Valid CNIC");
                return;
            }

            if (Globals.User == null || Globals.User.LoginID == null)
            {
                new frmMessageBox(MessageBoxType.Info, "Please Login with Authentic User to Change Employee").ShowDialog();
                return;
            }

            Employee emp = new Employee();
            if (!editMode)
                emp = new Employee();
            else
                emp = employee;

            string nic = txtCNIC.Text.Replace("-","").Trim();
            string fingerID = "";
            string cardID = "";

            emp.Code = txtID.Text;
            emp.Name = txtName.Text;
            emp.FatherName = txtFatherName.Text;
            emp.Department = cboDepartment.Text;
            emp.Designation = cboDesignation.Text;
            //emp.Section = cboSection.Text;
            
            emp.Section = cboSection.Text;
            fingerID = "1" + txtID.Text.Replace("-", "").Trim();
            cardID = "2" + txtID.Text.Replace("-", "").Trim();

            emp.NIC = nic;
            emp.Hostel = chkHostel.Checked;
            //emp.KioskAdmin = 1;
            emp.KioskAdmin = chkKioskPerson.Checked;
            emp.HostelName = txtHostel.Text;
            emp.Address = txtAddress.Text;
            emp.Email = txtEmail.Text;
            emp.ContactNo = txtContactNo.Text;
            emp.ReportingPerson = chkReportingPerson.Checked;
            //emp.Photo = picUser.Image != null ? Globals.ImageToByteArray(picUser.Image) : null;

            // create finger and cardi
            emp.BID = Int32.Parse( cboSeries.SelectedValue.ToString());
            emp.FingerID = fingerID;
            emp.CardID = cardID;

            emp.Date = dtpValidity.Value;

            if (!editMode)
            {
                if (emp.Save())
                {
                    
                    // ask to print verification form
                    if (Globals.ConfirmAction("New User Created Successfully. Do you want to print Verification Form?") == DialogResult.Yes)
                    {
                        // open verification form
                        btnPrintVerification_Click(null, null);
                    }
                    if (Globals.ConfirmAction("Do you want to Add Another User?") == DialogResult.Yes)
                        btnClear_Click(null, null);
                    else
                        this.Close();
                }
                else
                {
                    Globals.ShowMessage("User Not Saved, Try Again Later.");
                }
            }
            else
            {
                // update code
                //emp.ID = employee.ID;
                bool r = emp.Update(newImage);
                if (r)
                {
                    Globals.ShowMessage("User Information Updated Successfully.");
                    this.Close();
                }
                else
                {
                    Globals.ShowMessage("User Information Not Updated Try Again Later.");
                    this.Close();
                }
            }
        }

        private void txtFatherName_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFatherName.Text))
                txtFatherName.Text = txtFatherName.Text.ToUpper();
        }

        private void picWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Employee emp = e.Argument as Employee;
            e.Result = emp.GetImage();

        }

        private void picWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Image img = (Image)e.Result;
            picUser.Image = img;
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblStatus.Text))
                lblStatus.Visible = false;
            else
                lblStatus.Visible = true;
        }

        private void btnPrintVerification_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Settings.Default.rptVFFooter))
            {
                string msg = "Verification Form Footer not set.You Can Set it under General Settings. \nDo You want to proceed with empty Footer?  ";
                frmMessageBox frm = new frmMessageBox(MessageBoxType.Confirm, msg);
                frm.ShowDialog();
                if (frm.result == DialogResult.No)
                    return;
            }

            Reports.Verification_Form rpt = new Reports.Verification_Form();

            List<UserInfoForPrint> dataSet = new List<UserInfoForPrint>();

            UserInfoForPrint userData = new FASClient.UserInfoForPrint();
            // assign values
            Employee emp = Cache.employeeList.Find(x => x.Code == txtID.Text);
            var aa = (from em in Cache.employeeList
                      where em.Code == txtID.Text
                      select em).FirstOrDefault();

            userData.ID = txtID.Text;
            userData.FULLNAME = txtName.Text;
            userData.FATHERNAME = txtFatherName.Text;
            userData.DEPARTMENT = cboDepartment.Text;
            
            userData.DESIGNATION = cboDesignation.Text;
            userData.CNIC = txtCNIC.Text;
            userData.ADDRESS = txtAddress.Text;
            userData.CONTACT = txtContactNo.Text;

            userData.FINGERID = emp.FingerID;
            userData.CARDID = emp.CardID;


           
            dataSet.Add(userData);
            
            // set to datasource
            rpt.SetDataSource(dataSet);

            
            for (int i = 0; i < rpt.DataDefinition.FormulaFields.Count; i++)
                if (rpt.DataDefinition.FormulaFields[i].FormulaName ==
                                "{" + "@footer" + "}")
                    rpt.DataDefinition.FormulaFields[i].Text = "\"" + Settings.Default.rptVFFooter + "\"";


            frmReportViewer f = new frmReportViewer();
            f.rpt = rpt;
            f.ShowDialog();

        }

        private void SetParamValue(string paramName, string paramValue)
        {
            
        }

        private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSection.Text.Equals(Constant.Staff))
            {
                lblDate.Text = "Issue Date :";
            }
            else {
                lblDate.Text = "Valid Upto :";
            }
        }

        
    }



    public class UserInfoForPrint
    {
        public string ID { get; set; }
        public string FULLNAME { get; set; }
        public string FATHERNAME { get; set; }
        public string DEPARTMENT { get; set; }
        public string Hostel { get; set; }
        public string DESIGNATION { get; set; }
        public string CNIC { get; set; }
        public string ADDRESS { get; set; }
        public string CONTACT { get; set; }
        public string FINGERID { get; set; }
        public string CARDID { get; set; }
        public int TotalFingers { get; set; }
        public int Card { get; set; }
        public string Section { get; set; }
        public string CardVerify { get; set; }
        public string FingerVerify { get; set; }
        public DateTime CardCreatedDate { get; set; }
        public DateTime FingerCreatedDate { get; set; }
    }
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}