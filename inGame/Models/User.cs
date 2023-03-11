namespace inGame.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; } = "User";
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Basket? Basket { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime TokenCreated { get; set; } = DateTime.Now;
        public DateTime TokenExpires { get; set; }
    }
}
