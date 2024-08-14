using System.ComponentModel.DataAnnotations;

namespace WebApiDemo2.Areas.Suppliers.Models
{
    public class SuppModel
    {
        [Key]
        public int SupplierID { get; set; }

        [StringLength(50)]
        [Required]
        public string CompanyName { get; set; }

        public string City { get; set; }
    }
}
