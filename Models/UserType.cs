using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserMgtApp.Models
{ 
    [Table("user_type")]
    public class UserType
    {
        [Column("user_type_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTypeId { get; set; }

        [Column("user_type_name")]       
        [MaxLength(20)]
        public string UserTypeName { get; set; }

       
    }
}
