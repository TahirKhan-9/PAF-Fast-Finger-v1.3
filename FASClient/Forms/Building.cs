using FASClient.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UsmanCodeBlocks.Data.Sql;

namespace FASClient.Forms
{
    public partial class Building : Form
    {
        public List<tbl_Building> BuildingList;
        private int a;
        private List<tbl_MachineBind> tempList;
        string macStatus ="";
        public Building()
        {
            InitializeComponent();
        }

        private void btn_AddBuilding(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtName.Text))
                {
                    result.ForeColor = Color.Red;
                    result.Text = "Status: Enter Building Name";
                    return;
                }
                if (String.IsNullOrEmpty(txtDescription.Text))
                {
                    result.ForeColor = Color.Red;
                    result.Text = "Status: Enter Building Description";
                    return;
                }
                string name = txtName.Text;
                string builDes = txtDescription.Text;
                string insQuer = "insert into  [dbo].[tbl_Building] ([Building_Name],[Description])" + "values('" + name + "','" + builDes + "')";
                int resu = DBFactory.Insert(Globals.GetConnectionString(), insQuer);
                if (resu == 1)
                {
                    showBuildData();
                    result.ForeColor = Color.Green;
                    result.Text = "Status : Success";

                }
                else
                {
                    result.ForeColor = Color.Red;
                    result.Text = "Status : Failed";
                }
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        public void showBuildData()
        {
            BuildingList = Globals.ConvertDataTable<tbl_Building>(tbl_Building.GetAll());
            cboSeries.DataSource = BuildingList;
            cboSeries.DisplayMember = "Building_Name";
            cboSeries.ValueMember = "ID";
            DataTable buildData = DBFactory.GetAllByQuery(Globals.GetConnectionString(), "select * from [dbo].[tbl_Building]");
            dgvBuilding.DataSource = buildData;

        }
        public void showMacBindData(int ID)
        {
            DataTable macBindTab = DBFactory.GetAllByQuery(Globals.GetConnectionString(), "select * from [dbo].[tbl_MachineBind] where BID = "+ID);
            macBindTab.Columns.Remove("BID");
            macBindTab.Columns.Remove("FacID");
            dgvBinding.DataSource = macBindTab;
            tempList = Globals.ConvertDataTable<tbl_MachineBind>(macBindTab);

        }
        public void showDevList()
        {
            comboBox1.DataSource = Cache.facList;
            comboBox1.ValueMember = "FacID";
            comboBox1.DisplayMember = "Description";
        }
        private void Building_Load(object sender, EventArgs e)
        {
            showDevList();
            showBuildData();

        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBuilding.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dgvBuilding.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvBuilding.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["ID"].Value);
                    string delQuer = "delete from [dbo].[tbl_Building] where ID = '" + cellValue + "'";
                    bool resul = DBFactory.Delete(Globals.GetConnectionString(), delQuer);
                    if (resul)
                    {
                        showBuildData();
                        result.ForeColor = Color.Green;
                        result.Text = "Status : Success";
                    }
                    else
                    {
                        result.ForeColor = Color.Red;
                        result.Text = "Status : Failed";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cboSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            a++;
            if (a > 2)
            {
                string BID = cboSeries.SelectedValue.ToString();

                showMacBindData(Int32.Parse(BID));
            }
        }
        private void macBind_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(cboSeries.SelectedValue.ToString()))
                {
                    result.ForeColor = Color.Red;
                    result.Text = "Status: Select Building Name";
                    return;
                }
                if (String.IsNullOrEmpty(comboBox1.SelectedValue.ToString()))
                {
                    result.ForeColor = Color.Red;
                    result.Text = "Status: Select Building Device";
                    return;
                }
                if (String.IsNullOrEmpty(macStatus))
                {
                    result.ForeColor = Color.Red;
                    result.Text = "Status: Select Device IN/OUT Status";
                    return;
                }
                string BID = cboSeries.SelectedValue.ToString();
                string FacID = comboBox1.SelectedValue.ToString();
                string DevName = comboBox1.Text;
                foreach (var item in tempList)
                {
                    if (item.Machine_Name == DevName)
                    {
                        result.ForeColor = Color.Red;
                        result.Text="Status: Device Already Added to this Building";
                        return;
                    }
                }
                int resul =0;
                if (rdoIN.Checked == true)
                {
                    string insQuer = "insert into  [dbo].[tbl_MachineBind] ([BID],[FacID],[Machine_Name],[Type])" + "values('" + BID + "','" + FacID + "','" + DevName + "','"+macStatus+"')"; ;
                     resul = DBFactory.Insert(Globals.GetConnectionString(), insQuer);
                }
                if (rdoOUT.Checked == true)
                {
                    string insQuer = "insert into  [dbo].[tbl_MachineBind] ([BID],[FacID],[Machine_Name],[Type])" + "values('" + BID + "','" + FacID + "','" + DevName + "','" + macStatus + "')"; ;
                     resul = DBFactory.Insert(Globals.GetConnectionString(), insQuer);
                }

                if (resul == 1)
                {
                    
                    showMacBindData(Int32.Parse(BID));
                    result.ForeColor = Color.Green;
                    result.Text = "Status : Success";
                }
                else
                {
                    result.ForeColor = Color.Red;
                    result.Text = "Status : Failed";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBinding.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dgvBinding.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvBinding.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["ID"].Value);
                    string delQuer = "delete from [dbo].[tbl_MachineBind] where ID = '" + cellValue + "'";
                    bool resul = DBFactory.Delete(Globals.GetConnectionString(), delQuer);
                    if (resul)
                    {
                        
                        showMacBindData(Int32.Parse(cboSeries.SelectedValue.ToString()));
                        result.ForeColor = Color.Green;
                        result.Text = "Status : Success";
                    }
                    else
                    {
                        result.ForeColor = Color.Red;
                        result.Text = "Status : Failed";
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            macStatus = "OUT";
        }

        private void rdoIN_CheckedChanged(object sender, EventArgs e)
        {
            macStatus = "IN";
        }
    }
}
