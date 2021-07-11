using Bookings.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bookings.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        [Required]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [TitleAttribute]
        public string Name { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public int Rooms { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }
        [Required]
        public bool Gym { get; set; }
        [Required]
        public bool Pool { get; set; }
        public DateTime Date { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }

}