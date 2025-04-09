using System.ComponentModel.DataAnnotations;

namespace AmazonLite.Models
{
    public class BrandList
    {
        [Key]
        public int BrandID { get; set; }
        public string BrandName { get; set; }

         
    }
}
