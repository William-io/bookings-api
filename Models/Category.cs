using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Bookings.Models
{ 
    public class Category 
    {
        
        //Inicializador
        public Category()
        {
            Hotels = new Collection<Hotel>();
            Cars = new Collection<Car>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Title { get; set; }
        public ICollection<Hotel> Hotels {get; set;}
        public ICollection<Car> Cars {get; set;}
    }
    
}