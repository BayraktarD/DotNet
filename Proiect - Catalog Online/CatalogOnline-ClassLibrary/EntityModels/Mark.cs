using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOnline_ClassLibrary.EntityModels
{
    public class Mark
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Students")]
        public int StudentId { get; set; }

        [ForeignKey("Subjects")]
        public int SubjectId { get; set; }
        public DateTime Date { get; set; }

        [Range(1, 10, ErrorMessage = "Nota poate fi intre 1 si 10 inclusiv")]
        public int Value { get; set; }


        public virtual Student? Student { get; set; }
        public virtual Subject? Subject { get; set; }


    }
}
