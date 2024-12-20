using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling_System.Classes
{
    internal static class UserLogin
    {
        private static int userId;

        public static int UserId
        {
            get => userId;
            set => userId = value;
        }
    }
}
