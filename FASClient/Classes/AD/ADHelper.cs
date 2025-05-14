using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADService.Helper.AD
{
    public class ADHelper
    {
        #region AuthenticateUser Method
        /// <summary>
        /// Authenticates user name and password on the specified domain
        /// </summary>
        /// <param name="domainName">Domain Name</param>
        /// <param name="userName">User Name</param>
        /// <param name="password">User Password</param>
        /// <returns>True if user name and password are valid on domain</returns>
        public bool AuthenticateUser(string domainName, string userName, string password)
        {
            bool ret = false;
            string domain = LDAP(domainName);
            try
            {
                DirectoryEntry de = new DirectoryEntry(domain, userName, password);
                DirectorySearcher dsearch = new DirectorySearcher(de);
                SearchResult results = null;

                results = dsearch.FindOne();

                ret = true;
            }
            catch (Exception e)
            {
                ret = false;
            }

            return ret;
        }

        public static string LDAP(string domainName)
        {
            string r = "LDAP://" + domainName;
            var dcs = domainName.Split('.');
            string restOfArray = "DC=" + string.Join(",DC=", dcs.Skip(0));
            return r + "/" + restOfArray;
        }
        #endregion

        /// <summary>
        /// Gets Child OUs
        /// </summary>
        /// <param name="directoryEntries"></param>
        /// <returns></returns>

    }
}
