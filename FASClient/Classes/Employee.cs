using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using UsmanCodeBlocks.Data.Sql.Local;
using Microsoft.ApplicationBlocks.Data;

namespace FASClient
{

    public class Employee
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string FingerID { get; set; }
        public string CardID { get; set; }
        public string Name { get; set; }
        public bool Suspend { get; set; }
        public bool Denial { get; set; }
        public string FatherName { get; set; }
        public string NIC { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public bool Hostel { get; set; }
        public string HostelName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool ReportingPerson { get; set; }
        public bool KioskAdmin { get; set; }
        public DateTime Date { get; set; }
        public int BID { get; set; }


        public bool Save()
        {
            this.CreatedBy = Globals.User.LoginID;
            this.CreatedOn = DateTime.Now;
            this.Date = DateTime.Now; 
            string query = DBFactory.GetInsertString(Globals.GetConnectionString(), this, true);
            try
            {
                this.ID = Convert.ToInt32(DBFactory.Insert(Globals.GetConnectionString(), this, true));
                if (this.ID >= 1)
                {
                    //if (this.Photo != null)
                    //{
                    //    DBFactory.AddPhoto(Globals.GetConnectionString(), "Employee", "Photo",this.Photo,"ID",this.ID);
                    //}
                }
                Cache.employeeList.Add(this);
                return true;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failed.\r\n" + ex.Message);
                return false;
            }
        }

        public bool UserExist()
        {

            this.FingerID = "1" + this.Code.Replace("-", "").Trim();
            this.CardID = "2" + this.Code.Replace("-", "").Trim();

            string query = "select Count(*) from [User] where [UID] = '" + this.FingerID + "' OR [UID] = '" + this.CardID + "'";
            var result = SqlHelper.ExecuteScalar(Globals.GetConnectionString(), CommandType.Text, query);
            if (Convert.ToInt32(result) > 0)
                return true;

            return false;
        }
        public bool Update(bool photoChanged)
        {
            this.ModifiedBy = Globals.User.LoginID;
            this.ModifiedOn = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
            if (this.Date.Year == 1)
            {
                this.Date = DateTime.Now;
            }
            //string query = UsmanCodeBlocks.Data.Sql.Local.DBFactory.GetUpdateString(Globals.GetConnectionString(), this);
            string query;
            if (this.ReportingPerson && this.KioskAdmin)
            {
                query = "UPDATE Employee SET[Code] = '" + this.Code + "',[Name] = '" + this.Name + "',[FatherName] = '" + this.FatherName + "',[NIC] = '" + this.NIC + "',[Designation] = '" + this.Designation + "',[Department] = '" + this.Department + "',[Section] = '" + this.Section + "',[Address] = '" + this.Address + "',[Email] = '" + this.Email + "',[ContactNo] = '" + this.ContactNo + "',[ReportingPerson] = " + 1 + ",[KioskAdmin] = " + 1 + ", [BID] = " + this.BID + "  WHERE code = '" + this.Code + "' ;";
            }
            else
            if (this.ReportingPerson )
            {
                query = "UPDATE Employee SET[Code] = '" + this.Code + "',[Name] = '" + this.Name + "',[FatherName] = '" + this.FatherName + "',[NIC] = '" + this.NIC + "',[Designation] = '" + this.Designation + "',[Department] = '" + this.Department + "',[Section] = '" + this.Section + "',[Address] = '" + this.Address + "',[Email] = '" + this.Email + "',[ContactNo] = '" + this.ContactNo + "',[ReportingPerson] = " + 1 + ",[KioskAdmin] = " + 0 +", [BID] = " + this.BID + "  WHERE code = '" + this.Code + "' ;";
            }
            else
            if (this.KioskAdmin)
            {
                query = "UPDATE Employee SET[Code] = '" + this.Code + "',[Name] = '" + this.Name + "',[FatherName] = '" + this.FatherName + "',[NIC] = '" + this.NIC + "',[Designation] = '" + this.Designation + "',[Department] = '" + this.Department + "',[Section] = '" + this.Section + "',[Address] = '" + this.Address + "',[Email] = '" + this.Email + "',[ContactNo] = '" + this.ContactNo + "',[ReportingPerson] = " + 0 + ",[KioskAdmin] = " + 1 + ", [BID] = " + this.BID + "  WHERE code = '" + this.Code + "' ;";
            }
            else
            {
                query = "UPDATE Employee SET[Code] = '" + this.Code + "',[Name] = '" + this.Name + "',[FatherName] = '" + this.FatherName + "',[NIC] = '" + this.NIC + "',[Designation] = '" + this.Designation + "',[Department] = '" + this.Department + "',[Section] = '" + this.Section + "',[Address] = '" + this.Address + "',[Email] = '" + this.Email + "',[ContactNo] = '" + this.ContactNo + "',[ReportingPerson] = " + 0 + ",[KioskAdmin] = " + 0 + ", [BID] = " + this.BID + " WHERE code = '" + this.Code + "' ;";
            }
            try
            {
                
                bool updated = DBFactory.Update(Globals.GetConnectionString(), query);
                if (updated)
                {
                    //if (photoChanged && this.Photo != null)
                    //{
                    //    DBFactory.AddPhoto(Globals.GetConnectionString(), "Employee", "Photo", this.Photo,"ID",this.ID);
                    //}

                    var a = Cache.employeeList.Where(x => x.ID == this.ID).FirstOrDefault();
                    if (a != null)
                    {
                        a.ID = this.ID;
                        a.Code = this.Code;
                        a.FingerID = this.FingerID;
                        a.CardID = this.CardID;
                        a.Name = this.Name;
                        a.FatherName = this.FatherName;
                        a.NIC = this.NIC;
                        a.Designation = this.Designation;
                        a.Department = this.Department;
                        a.Section = this.Section;
                        a.Suspend = this.Suspend;
                        a.Address = this.Address;
                        a.Email = this.Email;
                        //a.Photo = this.Photo;
                        a.ContactNo = this.ContactNo;
                        a.CreatedOn = this.CreatedOn;
                        a.CreatedBy = this.CreatedBy;
                        a.ModifiedOn = this.ModifiedOn;
                        a.ModifiedBy = this.ModifiedBy;
                        a.ReportingPerson = this.ReportingPerson;
                        a.Date = this.Date;
                        a.BID = this.BID;
                    }
                }
                

                return updated;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failed.\r\n" + ex.Message);
                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                var result = DBFactory.Delete(Globals.GetConnectionString(), this);
                Cache.employeeList.Remove(this);
                return true;
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return false;
            }
        }

        public DataTable GetAll()
        {
            try
            {
                List<string> exCols = new List<string>();
                exCols.Add("Photo");
                return DBFactory.GetAll(Globals.GetConnectionString(), "Employee",exCols);
            }
            catch (Exception ex)
            {
                Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }

        public Image GetImage()
        {
            //this.Photo = DBFactory.GetPhoto(Globals.GetConnectionString(), "Employee", "Photo", "ID", this.ID);
            //return Globals.ByteToImage(this.Photo);
            string fileName = Globals.photosFolder + "//" + this.Code + ".jpg";
            if (File.Exists(fileName))
                return Image.FromFile(fileName);
            else
                return Globals.GetDefaultProfilePhoto();

        }

        //public bool ClearImage()
        //{
        //    return Convert.ToBoolean(DBFactory.ClearPhoto(Globals.GetConnectionString(), "Employee", "Photo","ID",this.ID));
        //}
    }
}