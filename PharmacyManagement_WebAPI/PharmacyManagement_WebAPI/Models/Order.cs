using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PharmacyManagement_WebAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPickedUp { get; set; } = false;
        public int Amount { get; set; }
        public int Count { get; set; }
        public int DoctorId { get; set; }
        public int AdminId { get; set; }
        public int MedicineId { get; set; }

        [ValidateNever]
        public Doctor Doctor { get; set; }
        [ValidateNever]
        public Admin Admin { get; set; }
        [ValidateNever]
        public Medicine Medicine { get; set; }
    }
}
