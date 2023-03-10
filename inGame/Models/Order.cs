namespace inGame.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int BasketId { get; set; }
        public Basket? Basket { get; set; }
    }
}
