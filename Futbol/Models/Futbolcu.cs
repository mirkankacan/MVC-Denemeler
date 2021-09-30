using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Futbol.Models
{
    public class Futbolcu
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string FutbolcuAdı { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2)]
        public string FutbolcuNumarası { get; set; }
    }
}