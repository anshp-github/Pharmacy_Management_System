namespace PharmacyManagement_WebAPI.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string MedName { get; set; }
        public int MedPrice { get; set; }
        public DateTime MedExpDate { get; set; }
        public int MedStock { get; set; }
        public string MedImage { get; set; }
    }
}
