﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lab12Ex1.Models
{
    public class Student
    {

        /// <summary>
        /// Id-ul studentului
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Id-ul Adresei studentului din tabela Addresses
        /// </summary>
        [JsonIgnore]
        [ForeignKey("Addresses")]
        public int? AddressId { get; set; }

        /// <summary>
        /// Prenumele studentului
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Numele studentului
        /// </summary>
        public string LastName{ get; set; }



        /// <summary>
        /// Varsta studentului (nu poate fi mai mica decat 0 si mai mare decat 130)
        /// </summary>
        [Range(1, 130, ErrorMessage = "Varsta trebuie sa fie mai mare decat 0")]
        [DefaultValue(1)]
        public int Age { get; set; }


        /// <summary>
        /// Adresa studentului
        /// </summary>
        public Address? Address { get; set; }

    }
}
