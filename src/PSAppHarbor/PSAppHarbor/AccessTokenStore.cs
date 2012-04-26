namespace PSAppHarbor
{
    class AccessTokenStore
    {
        public static readonly AccessTokenStore Instance = new AccessTokenStore();

        public string AccessToken { get; set; }
    }
}
