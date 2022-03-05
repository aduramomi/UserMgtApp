using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserMgtApp.Models
{
    [Table("users")]
    public class User
    {
        [Column("user_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Column("first_name")]
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Column("email")]
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Column("phone_no")]
        [Required]
        [MaxLength(50)]
        public string PhoneNo { get; set; }

        [Column("gender")]
        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Column("dob")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Column("nationality_id")]
        [Required]
        public int NationalityId { get; set; }

        [Column("user_type_id")]
        [Required]
        public int UserTypeId { get; set; }
    }
}
