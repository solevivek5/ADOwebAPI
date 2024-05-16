using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Core.Dtos.HR
{
    public class HrDto
    {
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(45, MinimumLength = 5)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Company name is required.")]
        [StringLength(75, MinimumLength = 5)]
        public string Company { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mobile number is required.")]
        [StringLength(10)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(15)]
        public string Password { get; set; } = string.Empty;
    }
}
