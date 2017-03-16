using CommunityWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite
{
    public static class Helper
    {
        public static List<string> currentRoles = new List<string>();
        public static bool LoginSuccess { get; set; }
        public static bool RegisterSuccess { get; set; }
        public static Member CurrentUser { get; set; }
        public static List<string> CurrentRoles { get; set; }

    }
}
