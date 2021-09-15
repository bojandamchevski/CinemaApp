namespace BojanDamchevski.CinemaApp.Domain.Models
{
    public class CinemaMovie : BaseEntity
    {
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}