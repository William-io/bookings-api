using System;
using System.ComponentModel.DataAnnotations;

namespace Bookings.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Make { get; set; }    
        public double CurrentSpeed { get; set; }
        public string Color { get; set; }
        public string Fuel { get; set; } 

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
    
}