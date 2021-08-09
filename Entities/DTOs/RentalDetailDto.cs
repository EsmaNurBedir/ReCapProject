using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int CarModelYear { get; set; }
        public decimal CarDailyPrice { get; set; }
        public string CarDescrition { get; set; }
        public string CompanyName { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
