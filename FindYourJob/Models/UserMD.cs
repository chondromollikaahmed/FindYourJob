using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindYourJob.Models
{
    public class UserMD
    {
        public UserMD()
        {
            MyProperty = new CompanyMD();
        }

        public int UserID { get; set; }
        public Nullable<int> UserTypeID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public Nullable<int> AccountStatusID { get; set; }

        public CompanyMD MyProperty { get; set; }
    }
}