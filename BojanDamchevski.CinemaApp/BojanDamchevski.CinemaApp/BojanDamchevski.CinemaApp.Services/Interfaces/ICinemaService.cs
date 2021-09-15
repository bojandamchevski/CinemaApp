using BojanDamchevski.CinemaApp.ViewModels.CinemaViewModels;
using System.Collections.Generic;

namespace BojanDamchevski.CinemaApp.Services.Interfaces
{
    public interface ICinemaService
    {
        List<CinemaListViewModel> GetAllCinemas();
        CinemaDetailsViewModel GetCinemaDetails(int id);
        void CreateCinema(CreateCinemaViewModel insertCinemaViewModel);
    }
}
