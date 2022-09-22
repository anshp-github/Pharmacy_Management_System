using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PharmacyManagement_WebAPI.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierEmail { get; set; }
        public double SupplierPhnNum { get; set; }
        public int MedicineId { get; set; }
        [ValidateNever]
        public Medicine Medicine { get; set; }
    }
}
