using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserMgtApp.Models
{ 
    [Table("nationalities")]
    public class Nationalities
    {
        [Column("nationality_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NationalityId { get; set; }

        [Column("country_code")]       
        [MaxLength(10)]
        public string CountryCode { get; set; }

        [Column("country")]       
        [MaxLength(50)]
        public string Country { get; set; }

        [Column("nationality")]       
        [MaxLength(50)]
        public string Nationality { get; set; }
    }
}
