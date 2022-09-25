namespace CinemaManagement.Domain.Models
{
    public class BaseModel: Entity
    {
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
