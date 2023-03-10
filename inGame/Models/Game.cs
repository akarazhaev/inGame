namespace inGame.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public float Raking { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
