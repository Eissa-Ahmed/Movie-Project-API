namespace Movie.DAL.Entity
{
    public class Gener
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Movies> Movies { get; set; }
    }
}
