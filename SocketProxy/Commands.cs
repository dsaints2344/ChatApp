using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketProxy
{
    public static class Commands
    {
        public static string connect { get =>nameof(connect); }
        public static string user_list { get =>nameof(user_list); }
        public static string send { get =>nameof(send); }
        public static string send_all { get =>nameof(send_all); }
        public static string message { get =>nameof(message); }
        public static string confirmed { get =>nameof(confirmed); }
        public static string exit { get =>nameof(exit); }
        public static string push_user_list { get =>nameof(push_user_list); }
    }
}
