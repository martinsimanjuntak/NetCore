using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore1.Models
{
    [Table("tb_m_persons")]
    public class Person
    {
        [Key]
        public string NIK { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual Account Account { get; set; }

       
       
    }
}
