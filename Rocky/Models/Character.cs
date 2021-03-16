using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Character Name")]
        public string Name { get; set; }
    }
}
