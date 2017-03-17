using CommunityWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite
{
    public static class Helper
    {
        public static string currentRole = "";
        public static bool LoginSuccess { get; set; }
        public static bool RegisterSuccess { get; set; }
        public static Member CurrentUser { get; set; }
        public static string CurrentRole { get; set; }
        public static string AdminSuccess { get; set; }
    }
}
