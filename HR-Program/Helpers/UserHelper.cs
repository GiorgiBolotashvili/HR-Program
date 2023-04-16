using HR_Program.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Program.Helpers
{
    public static class UserHelper
    {
        public static User  activeUser { get; set; }
        public static bool  isLogIn { get; set; }

    }
}
