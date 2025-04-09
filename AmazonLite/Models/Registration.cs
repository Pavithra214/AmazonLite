using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AmazonLite.Models
{
    public class Registration
    {
        [ValidateNever]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter your fulll name")]
        [Display(Name ="Full Name")]
        [StringLength(40)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Please enter the valid email ID")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Password doesnt match")]
        public string ConfirmPassword { get; set; }

        [Range(8,40)]
        public int Age { get; set; }
    }
}
