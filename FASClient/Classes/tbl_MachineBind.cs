using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsmanCodeBlocks.Data.Sql;

namespace FASClient.Classes
{
    public class tbl_MachineBind
    {
        public int ID { get; set; }
        public int BID { get; set; }
        public int FacID { get; set; }
        public string Machine_Name { get; set; }
        public string Type { get; set; }

    }
}
