using Core.Entities;

namespace Entities.DTOs
{
    public class RentalsDetailDto:IDto
    {
        public int RentalId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string CarName { get; set; }
        public string CompanyName { get; set; }
        public string CarDescription { get; set; }
        public string ModelYear { get; set; }
        public int DailyPrice{ get; set; }
        public bool IsActive { get; set; }
    }
}
