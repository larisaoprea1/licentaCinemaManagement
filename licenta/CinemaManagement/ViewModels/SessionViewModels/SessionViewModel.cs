﻿using CinemaManagement.ViewModels.MovieViewModels;
using CinemaManagement.ViewModels.ReservedSeatViewModels;
using CinemaManagement.ViewModels.RoomViewModels;

namespace CinemaManagement.ViewModels.SessionViewModels
{
    public class SessionViewModel
    {
        public Guid Id { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }
        public MovieViewModel Movie { get; set; }
        public Guid MovieId { get; set; }
        public RoomViewModel Room { get; set; }
        public Guid RoomId { get; set; }
        public List<ReservedSeatViewModel> ReservedSeats { get; set; }
    }
}
