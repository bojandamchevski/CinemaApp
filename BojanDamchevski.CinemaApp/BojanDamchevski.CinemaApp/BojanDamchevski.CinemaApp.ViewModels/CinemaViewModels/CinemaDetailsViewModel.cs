using System.Collections.Generic;

namespace BojanDamchevski.CinemaApp.ViewModels.CinemaViewModels
{
    public class CinemaDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<string> Movies { get; set; }
    }
}
