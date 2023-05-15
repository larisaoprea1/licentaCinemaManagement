namespace CinemaManagement.ViewModels.SessionViewModels
{
    public class SessionForCreateViewModel
    {
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }
        public Guid MovieId { get; set; }
        public Guid RoomId { get; set; }
    }
}
