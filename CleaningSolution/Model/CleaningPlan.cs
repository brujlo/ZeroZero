
using System;
using System.ComponentModel.DataAnnotations;

namespace CleaningSolution.Model
{
    public class CleaningPlan
    {
        [Key, Required(ErrorMessage = "Id cant be empty")] // ovo je cak i nepotrebno jer on kuizi da je id id
        public Guid id { get; set; }


        [MaxLength(256, ErrorMessage = "Title is to long"), Required(ErrorMessage = "Title cant be empty")]
        public string title { get; set; }


        [Required(ErrorMessage = "CustomerID cant be empty")]
        public int customerId { get; set; }


        [Required(ErrorMessage = "CreationDate cant be empty")]
        public DateTime createdAt { get; set; }


        [MaxLength(512, ErrorMessage = "description has to many letters")]
        public string description { get; set; }
    }
}
