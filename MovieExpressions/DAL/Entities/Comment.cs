using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Comment
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }

        [Required]
        [StringLength(1000)]
        public string Text { get; set; }

        public virtual Film Film { get; set; }
    }
}
