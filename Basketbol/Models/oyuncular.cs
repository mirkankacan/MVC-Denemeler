

namespace Basketbol.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class oyuncular
    {
        [Key]
        public short ID { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string Adı { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2)]
        public string Numarası { get; set; }
    }
}
