using ISIP424_Shornikova.WPF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP424_Shornikova.WPF
{
    public static class Core
    {
        public static CinemaBDEntities Context = new CinemaBDEntities();
        public static User CurrentUser = new User();
        public static bool IsAuthorized = false;
        public static void Logout()
        {
            CurrentUser = new User();
            IsAuthorized = false;
        }
    }
}
