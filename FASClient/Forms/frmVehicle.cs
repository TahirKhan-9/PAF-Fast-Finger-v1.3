using FASClient.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FASClient.Forms
{
    public partial class frmVehicle : Form
    {
        p_person p_Person = new p_person();
        private string veh_type;

        public frmVehicle()
        {
            InitializeComponent();
        }

        private void frmVehicle_Load(object sender, EventArgs e)
        {
            txtempID.Enabled = true;
            txtempname.Enabled = false;
            txtvehicleno.Enabled = true;

        }

        private void txttagID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                string query = "SELECT [work_no],[id_no],[id_name],[first_name],[last_name],[title_no],[card_no] FROM [rms_a].[dbo].[p_person] where work_no = '"+txttagID.Text.Trim()+"'";
                List<p_person> TagUID = Globals.ConvertDataTable<p_person>(new p_person().GetAllByquery(query));
                p_person tag = TagUID.Find(x => x.work_no == txttagID.Text.Trim());
                               
                if (tag != null)
                {
                    if (!string.IsNullOrEmpty(tag.card_no))
                    {
                        if (!string.IsNullOrEmpty(tag.first_name))
                            txttagUID.Text = tag.first_name;
                        if (!string.IsNullOrEmpty(tag.last_name))
                            txtempname.Text = tag.last_name;
                        if (!string.IsNullOrEmpty(tag.id_name))
                            txtvehicleno.Text = tag.id_name;
                        if (!string.IsNullOrEmpty(tag.id_no))
                            txtempID.Text = tag.id_no;
                        if (!string.IsNullOrEmpty(tag.title_no))
                        {
                            if (tag.title_no == "Car/Jeep")
                                rbCar.Checked = true;
                            else if (tag.title_no == "Bus/Van")
                                rbBus.Checked = true;
                            btnSave.Text = "Edit";
                        }

                    }
                    else
                    {
                        Globals.ShowMessage("Tag Not Found.");
                    }
                }
                else
                {
                    Globals.ShowMessage("Tag Not Found.");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txttagUID.Text))
            {
                if (!string.IsNullOrEmpty(txtempID.Text))
                {
                    if (!string.IsNullOrEmpty(txtempname.Text))
                    {
                        if (!string.IsNullOrEmpty(txtvehicleno.Text))
                        {
                            if (rbCar.Checked || rbBus.Checked)
                            {
                                update();
                            }
                            else
                            {
                                Globals.ShowMessage("Enter Vehicle Type.");
                            }
                        }
                        else
                        {
                            Globals.ShowMessage("Enter Vehicle Registration No.");
                        }
                    }
                    else
                    {
                        Globals.ShowMessage("Enter Employee Details.");
                    }
                }
                else
                {
                    Globals.ShowMessage("Enter Employee Details.");
                }
            }
            else
            {
                Globals.ShowMessage("Enter Tag No.");
            }
        }
        void update()
        {
            if (rbBus.Checked)
            {
                veh_type = "Bus/Van";
            }
            else if (rbCar.Checked)
            {
                veh_type = "Car/Jeep";
            }
            if(p_Person.Update(txtempID.Text, txtvehicleno.Text, txtempname.Text, veh_type, txttagID.Text))
            {
                Globals.ShowMessage(txtempID.Text+"\n"+ txtempname.Text + "\n" + txtvehicleno.Text+"\n"+txttagID.Text+"\nOperation Successfull");
            }
            else
            {
                Globals.ShowMessage("Operation Failed");
            }
        }
        private void txtempID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 || (txtempID.Focused == false))
            {
                Employee emp = Cache.employeeList.Find(x => x.Code == txtempID.Text );
                if (emp != null)
                {
                    txtempname.Text = emp.Name;
                }
                else
                {
                    txtempname.Text = "";
                    Globals.ShowMessage("User Not Found.");
                }
                   
            }
        }

        private void txtempID_Leave(object sender, EventArgs e)
        {
            Employee emp = Cache.employeeList.Find(x => x.Code == txtempID.Text);
            if (emp != null)
            {
                txtempname.Text = emp.Name;
            }
            else
            {
                Globals.ShowMessage("User Not Found.");
                txtempname.Text = "";
            }
        }

        private void txttagUID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                string query = "SELECT [work_no],[id_no],[id_name],[first_name],[last_name],[title_no],[card_no] FROM [rms_a].[dbo].[p_person] where first_name = '" + txttagUID.Text.Trim() + "'";
                List<p_person> TagUID = Globals.ConvertDataTable<p_person>(new p_person().GetAllByquery(query));
                p_person tag = TagUID.Find(x => x.work_no == txttagID.Text.Trim());

                if (tag != null)
                {
                    if (!string.IsNullOrEmpty(tag.card_no))
                    {
                        if (!string.IsNullOrEmpty(tag.first_name))
                            txttagUID.Text = tag.first_name;
                        if (!string.IsNullOrEmpty(tag.last_name))
                            txtempname.Text = tag.last_name;
                        if (!string.IsNullOrEmpty(tag.id_name))
                            txtvehicleno.Text = tag.id_name;
                        if (!string.IsNullOrEmpty(tag.id_no))
                            txtempID.Text = tag.id_no;
                        if (!string.IsNullOrEmpty(tag.title_no))
                        {
                            if (tag.title_no == "Car/Jeep")
                                rbCar.Checked = true;
                            else if (tag.title_no == "Bus/Van")
                                rbBus.Checked = true;
                            btnSave.Text = "Edit";
                        }

                    }
                    else
                    {
                        Globals.ShowMessage("Tag Not Found.");
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
