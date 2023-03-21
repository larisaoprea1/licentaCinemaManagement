﻿using CinemaManagement.ViewModels.ActorViewModels;
using CinemaManagement.ViewModels.GenreViewModels;
using CinemaManagement.ViewModels.ProductionViewModels;

namespace CinemaManagement.ViewModels.MovieViewModels
{
    public class MovieForCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Format { get; set; }
        public string Director { get; set; }
        public bool IsAdult { get; set; }
        public string ImdbLink { get; set; }
        public string TrailerLink { get; set; }
        public string Poster { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string RunTime { get; set; }
        public DateTime RunDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MovieBudget { get; set; }
        public ICollection<ActorViewModel> Actors { get; set; }
        public ICollection<GenreViewModel> Genres { get; set; }
        public ICollection<ProductionViewModel> Productions { get; set; }

    }
}
