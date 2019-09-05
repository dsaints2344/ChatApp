namespace SocketProxy
{
    public static class Commands
    {
        public static string connect { get => nameof(connect); }
        public static string user_list { get => nameof(user_list); }
        public static string send { get => nameof(send); }
        public static string send_all { get => nameof(send_all); }
        public static string message { get => nameof(message); }
        public static string confirmed { get => nameof(confirmed); }
        public static string exit { get => nameof(exit); }
        public static string push_user_list { get => nameof(push_user_list); }
        public static string login { get => nameof(login); }
        public static string logout { get => nameof(logout); }

    }

    public static class Symbols
    {
        public static char CommandSeparator { get => ':'; }
        public static char ParameterSeparator { get => '?'; }
    }

    public enum eResponses { Connected, NoConnected }
}
