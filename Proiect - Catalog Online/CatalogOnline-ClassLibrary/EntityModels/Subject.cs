using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOnline_ClassLibrary.EntityModels
{
    public class Subject
    {
        /// <summary>
        /// Id-ul cursului
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Denumirea cursului
        /// </summary>
        public string Name { get; set; }

        [ForeignKey("Teachers")]
        public int? TeacherId { get; set; }
    }
}
