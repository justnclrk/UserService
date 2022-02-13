namespace UserService.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public bool IsSysAdmin { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? ExpiresIn { get; set; }
        public long? ExpiresOn { get; set; }
        public bool Deleted { get; set; }
        /*
        public void Login(long ts)
        {
            AccessToken = Guid.NewGuid().ToString();
            RefreshToken = Guid.NewGuid().ToString();
            ExpiresIn = Constants.ONE_DAY_IN_SECONDS;
            ExpiresOn = ts + ExpiresIn;
            LastLogin = DateTime.Now;
        }

        public void Logout()
        {
            AccessToken = null;
            RefreshToken = null;
            ExpiresIn = null;
            ExpiresOn = null;
        }
        */
    }
}
