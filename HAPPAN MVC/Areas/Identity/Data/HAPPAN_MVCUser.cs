using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HAPPAN_MVC.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the HAPPAN_MVCUser class
    public class HAPPAN_MVCUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName ="nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [EnumDataType(typeof(UserType))]
        public UserType Type { get; set; }
    }

    public enum UserType
    {
        Admin = 1,
        Member = 2
    }
}
