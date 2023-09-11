namespace Movie.DAL.Entity
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
        public string Poster { get; set; } = string.Empty;
        public int Year { get; set; }
        public double Rate { get; set; }
        [ForeignKey("Gener")]
        public int GenerId {get; set;}
        public Gener Gener { get; set;}

    }
}
