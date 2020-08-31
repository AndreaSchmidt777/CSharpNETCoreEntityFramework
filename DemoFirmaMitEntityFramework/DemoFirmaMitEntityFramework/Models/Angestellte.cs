using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoFirmaMitEntityFramework.Models
{
    public class Angestellte
    {
        [Key]
        public int MitarbeiterID { get; set; }
        [Required,StringLength(50)]
        public string Vorname { get; set; }
        [Required,StringLength(50)]
        public string Nachname { get; set; }
    }
}
