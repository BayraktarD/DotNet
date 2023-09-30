using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOnline_ClassLibrary.EntityModels
{
    public class Address
    {

        /// <summary>
        /// Id-ul adresei
        /// </summary>
        [Key]
        public int Id { get; set; }

        [ForeignKey("Students")]
        public int? StudentId { get; set; }

        [ForeignKey("Teachers")]
        public int? TeacherId { get; set; }


        /// <summary>
        /// Orasul
        /// </summary>
        public string City { get; set; }


        /// <summary>
        /// Strada
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Numar strada
        /// </summary>
        public string StreetNo { get; set; }
    }
}
