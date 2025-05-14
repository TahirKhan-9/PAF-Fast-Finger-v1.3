using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Windows.Forms;
using FASClient;

namespace Excel2SQL.Reports
{
    public class AttendanceData
    {
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpUnit { get; set; }
        public string EmpStation { get; set; }
        public DateTime UsrDate { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string WorkTime { get; set; }
        public string TotalWork { get; set; }
        public string Status { get; set; }

        void clear()
        {
            this.TimeOut = "";
            this.EmpID = "";
            this.EmpName = "";
            this.EmpStation = "";
            this.EmpUnit = "";
            this.TimeIn = "";
            this.WorkTime = "";
            Status = "";

        }
        public List<AttendanceData> GetAttendanceData(string station, string unit, string empid, DateTime startDate, DateTime EndDate)
        {
            string empQuery = "";
            if (empid != "All")
            {
                empQuery = "select [user].id as id,ralog.name,[user].station as station,[user].department,ralog.Time as Time,Ralog.Date as Date from ralog,[user] where ralog.uid = [user].uid and [user].id =  '" + empid + "' and ralog.Date > '" + startDate.Date.Date + "' and ralog.Date < '" + EndDate.Date.Date + "' order by ralog.Date ";
            }

            else
            {
                //if (station == "All")
                //{
                //    if (unit == "All")
                //    {
                //        empQuery = "select distinct id, name, station,department from [user] order by id";
                //    }
                //    else
                //        empQuery = "select distinct id, name, station,department from [user] where department = '" + unit + "' order by id";
                //}
                //else
                //{
                if (unit == "All")
                {
                    empQuery = "select [user].id as id,[user].station as station,[user].department,ralog.name,ralog.Time as Time,Ralog.Date as Date from ralog,[user] where ralog.uid = [user].uid  and ralog.Date > '" + startDate.Date.Date + "' and [user].station = '" + station + "' and ralog.Date < '" + EndDate.Date.Date + "' order by id, ralog.Date ";
                    //empQuery = "select distinct id, name from ralog where station = '" + station + "'  and Date > '" + startDate.Date.Date + "' and Date < '" + EndDate.Date.Date + "' order by id";
                }
                else
                    empQuery = "select [user].id as id,[user].station as station,[user].department,ralog.name,ralog.Time as Time,Ralog.Date as Date from ralog,[user] where ralog.uid = [user].uid  and ralog.Date > '" + startDate.Date.Date + "' and [user].station = '" + station + "' and [user].department = '" + unit + "' and ralog.Date < '" + EndDate.Date.Date + "' order by id,ralog.Date ";
                   // empQuery = "select distinct id, name from ralog where station = '" + station + "'and department = '" + unit + "' Date > '" + startDate.Date.Date + "' and Date < '" + EndDate.Date.Date + "' order by id";
                //}
            }
            bool worked = false;
            int counter=0;
            DateTime ddate =  new DateTime();
            DateTime Tin = new DateTime();
            DateTime chkTimein = new DateTime();
            List<AttendanceData> list = new List<AttendanceData>();
            DataTable dtEmp = new DataTable();
            AttendanceData ad = new AttendanceData();
            TimeSpan Twork = new TimeSpan();
            string employeeID = "";
            
            dtEmp = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, empQuery).Tables[0];
            foreach (DataRow row in dtEmp.Rows)
            {
                

                if (employeeID != row["id"].ToString())
                {
                    Twork = new TimeSpan();
                    employeeID = row["id"].ToString();

                    //if (counter != 0)
                    //{
                        
                    //    ad.TimeOut = Tin.ToString("hh:mm:ss");
                    //    ad.WorkTime = (Tin - chkTimein).ToString();
                    //    list.Add(ad);
                    //}
                    counter = 0;
                }
               
                    DateTime newDate = Convert.ToDateTime(row["Date"].ToString());
                    Tin = Convert.ToDateTime(row["Time"].ToString());
                    if (ddate.Date.Date != newDate.Date.Date)
                    {
                        ddate = newDate.Date.Date;
                        chkTimein = Tin;
                        counter++;

                        if (counter > 1)
                        {
                            if(!string.IsNullOrEmpty(ad.WorkTime))
                            Twork +=TimeSpan.Parse(ad.WorkTime);
                            ad.TotalWork = Twork.ToString();
                            list.Add(ad);
                            employeeID = row["id"].ToString();
                            counter = 1;
                            ad = new AttendanceData();
                        }
                        // worked = false;
                        //ad.EmpID = empid;
                        //ad.EmpName = this.EmpName;
                        //ad.EmpStation = station;
                        //ad.EmpUnit = unit;
                        //ad.UsrDate = ddate.Date.Date;
                        ad.EmpID = row["id"].ToString();
                        ad.EmpName = row["Name"].ToString();
                        ad.EmpStation = row["station"].ToString();
                        ad.EmpUnit = unit;
                        ad.UsrDate = ddate.Date.Date;
                      //  ad.TotalWork = totalWork;
                        ad.TimeIn = Tin.ToString("hh:mm:ss");
                    }
                    else
                    {
                        
                        //worked = true;
                        ad.TimeOut = Tin.ToString("hh:mm:ss");
                        ad.WorkTime = (Tin - chkTimein).ToString();
                        //workMins += (TimeSpan.Parse(ad.WorkTime).Hours * 60) + TimeSpan.Parse(ad.WorkTime).Minutes;
                        //int a = workMins;
                        //int hrs = 0;
                        //int mins = 0;
                        //while (a > 60)
                        //{
                        //    hrs++;
                        //    a = a - 60;
                        //}

                        //totalWork = hrs.ToString() + ":" + a.ToString();
                        //ad.TotalWork = totalWork;
                    }

            
            }
            
                //ad.TimeOut = Tin.ToString("hh:mm:ss");
                //ad.WorkTime = (Tin - chkTimein).ToString();
            if (!string.IsNullOrEmpty(ad.WorkTime))
            {
                Twork += TimeSpan.Parse(ad.WorkTime);
                DateTime add = new DateTime();
                string a = (Twork.Days * 24 + Twork.Hours).ToString();
                ad.TotalWork = a + ":" + Twork.Minutes + ":" + Twork.Seconds;
                list.Add(ad);
            }
           
            return list;
        }
        public List<AttendanceData> GetAttendanceShift(string station, string unit, string empid, DateTime startDate, DateTime EndDate)
        {
            string empQuery = "";
            if (empid != "All")
            {
                empQuery = "select [user].id as id,ralog.name,[user].station as station,[user].department,ralog.Time as Time,Ralog.Date as usrDate from ralog,[user] where ralog.uid = [user].uid and [user].id =  '" + empid + "' and ralog.Date > '" + startDate.Date.Date + "' and ralog.Date < '" + EndDate.Date.Date + "' order by ralog.Date ";
            }

            else
            {
                if (unit == "All")
                {
                    empQuery = "select [user].id as id,[user].station as station,[user].department,ralog.name,ralog.Time as Time,Ralog.Date as usrDate from ralog,[user] where ralog.uid = [user].uid  and ralog.Date > '" + startDate.Date.Date + "' and [user].station = '" + station + "' and ralog.Date < '" + EndDate.Date.Date + "' order by id, ralog.Date ";
                }
                else
                    empQuery = "select [user].id as id,[user].station as station,[user].department,ralog.name,ralog.Time as Time,Ralog.Date as usrDate from ralog,[user] where ralog.uid = [user].uid  and ralog.Date > '" + startDate.Date.Date + "' and [user].station = '" + station + "' and [user].department = '" + unit + "' and ralog.Date < '" + EndDate.Date.Date + "' order by id,ralog.Date ";
            }
            List<AttendanceData> list = new List<AttendanceData>();
            DataTable dtEmp = new DataTable();
            AttendanceData ad = new AttendanceData();
            dtEmp = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, empQuery).Tables[0];
            DataView view = new DataView(dtEmp);
            DataTable distinctdt = view.ToTable(true, "id");
            foreach (DataRow row in distinctdt.Rows)
            {
                DateTime dateCounter = startDate;
                while (dateCounter.Date <= EndDate.Date)
                {
                    DataTable dt = new DataTable();
                    string query = "SELECT s.MinStartTime,s.MaxStartTime , s.MinEndTime , s.MaxEndTime  FROM ShiftSchedule AS ss INNER JOIN Shifts AS s ON ss.ShiftID = s.ShiftID WHERE (ss.UserID = '" + row[0] + "') AND (ss.UsrDate = '" + dateCounter.Date + "')";
                    dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
                    DateTime minStartTime=Convert.ToDateTime(dt.Rows[0][0].ToString());
                    DateTime maxStartTime=Convert.ToDateTime(dt.Rows[0][1].ToString());
                    DateTime minEndTime=Convert.ToDateTime(dt.Rows[0][2].ToString());
                    DateTime maxEndTime=Convert.ToDateTime(dt.Rows[0][3].ToString());
                    string ss = "id=" + row[0].ToString() + " and CONVERT(usrDate,date)='" + dateCounter.ToString("dd-MMM-yyyy") + "' ";
                    DataRow[] arr = dtEmp.Select(ss);
                    dateCounter= dateCounter.AddDays(1);
                }
            }
            return list;
        }
        public static List<AttendanceData> GetAttendance(string empQuery, DateTime startDate, DateTime endDate)
        {
            List<AttendanceData> attendance = new List<AttendanceData>();
            DataTable dtEmp = new DataTable();
            dtEmp = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, empQuery).Tables[0];
            if (dtEmp.Rows.Count >= 1)
            {
                
                foreach (DataRow emp in dtEmp.Rows)
                {
                    TimeSpan totalTime = new TimeSpan();
                    DateTime dateCounter = startDate;
                    while (dateCounter <= endDate)
                    {
                        AttendanceData ad = new AttendanceData();
                        ad.EmpID = emp["id"].ToString();
                        ad.EmpName = emp["name"].ToString();
                        ad.EmpStation = emp["station"].ToString();
                        ad.EmpUnit = emp["department"].ToString();
                        ad.UsrDate = dateCounter;

                        // find attendance of a day
                        Clock _clock = FindInOut(emp["id"].ToString(), dateCounter);
                        if (!string.IsNullOrEmpty(_clock.TimeIn) || !string.IsNullOrEmpty(_clock.TimeOut))
                        {
                            ad.TimeIn = _clock.TimeIn;
                            ad.TimeOut = _clock.TimeOut;

                            if (!string.IsNullOrEmpty(_clock.TimeIn) && !string.IsNullOrEmpty(_clock.TimeOut))
                            {
                                TimeSpan diff = TimeSpan.Parse(_clock.TimeOut).Subtract(TimeSpan.Parse(_clock.TimeIn));
                                ad.WorkTime = diff.ToString();
                                totalTime = totalTime.Add(diff);
                            }
                            ad.Status = "Present";
                            
                        }
                        else
                        {
                            if (_clock.IsOff)
                                ad.Status = "Off";
                            else
                                ad.Status = "Absent";
                            
                        }
                        ad.TotalWork = totalTime.ToString();
                        attendance.Add(ad);
                        dateCounter = dateCounter.AddDays(1);
                    }
                }

            }

            return attendance;
        }
        public static List<AttendanceData> DailyAttendance(string empQuery, DateTime startDate, DateTime endDate)
        {
            List<AttendanceData> attendance = new List<AttendanceData>();
            DataTable dtEmp = new DataTable();
            dtEmp = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, empQuery).Tables[0];
            if (dtEmp.Rows.Count >= 1)
            {

                foreach (DataRow emp in dtEmp.Rows)
                { 
                    TimeSpan totalTime = new TimeSpan();
                    DateTime dateCounter = startDate;
                    while (dateCounter <= endDate)
                    {
                        AttendanceData ad = new AttendanceData();
                        ad.EmpID = emp["id"].ToString();
                        ad.EmpName = emp["name"].ToString();
                        ad.EmpStation = emp["station"].ToString();
                        ad.EmpUnit = emp["department"].ToString();
                        ad.UsrDate = dateCounter;

                        // find attendance of a day
                        Clock _clock = FindInOut(emp["id"].ToString(), dateCounter);
                        if (!string.IsNullOrEmpty(_clock.TimeIn) || !string.IsNullOrEmpty(_clock.TimeOut))
                        {
                            ad.TimeIn = _clock.TimeIn;
                             ad.TimeOut = _clock.TimeOut;

                            if (!string.IsNullOrEmpty(_clock.TimeIn) && !string.IsNullOrEmpty(_clock.TimeOut))
                            {
                                TimeSpan diff = TimeSpan.Parse(_clock.TimeOut).Subtract(TimeSpan.Parse(_clock.TimeIn));
                                ad.WorkTime = diff.ToString();
                                totalTime = totalTime.Add(diff);
                            }
                            ad.Status = "Present";

                        }
                        else
                        {
                            if (_clock.IsOff)
                                ad.Status = "Off";
                            else
                                ad.Status = "Absent";

                        }
                        ad.TotalWork = totalTime.ToString();
                        attendance.Add(ad);
                        dateCounter = dateCounter.AddDays(1);
                    }
                }

            }

            return attendance;
        }
        public static Clock FindInOut(string empID, DateTime usrDate)
        {
            Clock c = new Clock();
            // find schedule
            ShiftSchedule ss = ShiftSchedule.Get(empID, usrDate);
            if (ss != null)
            {
                
                string query = "SELECT u.id, r.Date, r.Time FROM [User] AS u INNER JOIN RALog AS r ON u.UID = r.UID WHERE (u.id = '" + empID + "') AND (CONVERT(date, r.Date) = '" + usrDate.ToString("dd-MMM-yyyy") + "') ORDER BY r.Time ";
                DataTable dt = new DataTable();
                dt = SqlHelper.ExecuteDataset(Globals.GetConnectionString(), CommandType.Text, query).Tables[0];
                if (dt.Rows.Count >= 1)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string usrTime = row["time"].ToString();
                        if (TimeSpan.Parse(usrTime) >= TimeSpan.Parse(ss.MinStartTime.ToString("HH:mm:ss")) && TimeSpan.Parse(usrTime) <= TimeSpan.Parse(ss.MaxStartTime.ToString("HH:mm:ss")))
                        {
                            if (string.IsNullOrEmpty(c.TimeIn)) 
                                c.TimeIn = usrTime;
                        }
                        else if (TimeSpan.Parse(usrTime) >= TimeSpan.Parse(ss.MinEndTime.ToString("HH:mm:ss")) && TimeSpan.Parse(usrTime) <= TimeSpan.Parse(ss.MaxEndTime.ToString("HH:mm:ss")))
                        {
                            if (string.IsNullOrEmpty(c.TimeOut))
                            {
                                c.TimeOut = usrTime;
                            }
                            else
                            {
                                if (TimeSpan.Parse(c.TimeOut) < TimeSpan.Parse(usrTime))
                                    c.TimeOut = usrTime;
                            }
                        }
                        c.IsOff = ss.IsODShift;
                    }
                }
            }

            return c;
        }
    }

    public class Clock
    {
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public bool IsOff { get; set; }
    }
}
