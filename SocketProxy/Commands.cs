using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketProxy
{
    public class Commands
    {
        public string connect { get =>nameof(connect); }
        public string user_list { get =>nameof(user_list); }
        public string send { get =>nameof(send); }
        public string send_all { get =>nameof(send_all); }
        public string message { get =>nameof(message); }
        public string confirmed { get =>nameof(confirmed); }
        public string exit { get =>nameof(exit); }
        public string push_user_list { get =>nameof(push_user_list); }
    }
}
