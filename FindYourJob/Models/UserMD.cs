using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage ="Required*")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Required*")]
        public string Password { get; set; }



        [Required(ErrorMessage = "Required*")]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage = "Required*")]
        public string ContactNo { get; set; }
        public Nullable<int> AccountStatusID { get; set; }

        public CompanyMD MyProperty { get; set; }
    }
}