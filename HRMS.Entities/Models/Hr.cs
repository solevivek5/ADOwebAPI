using System;
using System.Collections.Generic;

namespace HRMS.Entities.Models
{
    public partial class Hr
    {
        public int HrId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Company { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
