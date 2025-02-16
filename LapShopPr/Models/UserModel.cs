using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LapShopPr.Models
{
    public class UserModel
    {

        [Required]
public string FirstName {  get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Please Enter a Valid Email")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [ValidateNever]

        public string ReturnUrl { get; set; }

    }
}
