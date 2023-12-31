﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lab12Ex1.Models
{
    public class Address
    {

        /// <summary>
        /// Id-ul adresei
        /// </summary>
        [Key]
        public int Id { get; set; }

        [ForeignKey("Students")]
        public int StudentId { get; set; }


        /// <summary>
        /// Orasul
        /// </summary>
        public string City  { get; set; }


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
