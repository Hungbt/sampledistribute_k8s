namespace core.Settings
{
    public class AppSettings
    {
        public JwtOption JWT { get; set; }
        public StateStoreOption StateStore { get; set; }

        public class JwtOption
        {
            public string Secret { get; set; }
            public string ValidIssuer { get; set; }
            public string ValidAudience { get; set; }
            public double ExpiredHours { get; set; }
            public double ExpireRefreshTokenHours { get; set; }
        }
        public class StateStoreOption
        {
            public string TTLInSeconds { get; set; }
            public bool Disabled { get; set; }
        }
    }
}
