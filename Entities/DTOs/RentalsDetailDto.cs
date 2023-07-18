using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalsDetailDto:IDto
    {
        public int RentalId { get; set; }
        public string CarName { get; set; }
        public string CarDescription { get; set; }
        public string ModelYear { get; set; }
        public int DailyPrice{ get; set; }
        public string CustomerName { get; set; }
    }
}
