using System.ComponentModel.DataAnnotations;

namespace AmazonLite.Models
{
    public class ProdList
    {
        [Key]
        public int ProdId { get; set; }
        public string? ProdName { get; set; }
        public string? ProdInfo { get; set; } 
        public string? ProdType { get; set; }
        public string? ProdImage { get; set; }

        

        //[DataType(DataType.DateTime)]
        //public string? DateOfRegstration { get; set; }

        

    }
}
