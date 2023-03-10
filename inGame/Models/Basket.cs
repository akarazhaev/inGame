namespace inGame.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<Order> Orders { get; set; }
    }
}
