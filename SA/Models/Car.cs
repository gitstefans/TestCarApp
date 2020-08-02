using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SA.Models
{
    public partial class Car
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "CarNameRequired")]
        public string Make { get; set; }
        [Required(ErrorMessage ="CarModelRequired")]
        public string Model { get; set; }
        public int? Year { get; set; }
        public decimal? Engine_Size { get; set; }
        public int? Power_Kw { get; set; }
        public string Fuel_Type { get; set; }
        public string Body_Type { get; set; }
        public decimal? Price { get; set; }

        public string Image { get; set; }
        public string OriginalImageName { get; set; }
        public string Contact { get; set; }
        public int? Is_Deleted { get; set; }
        [NotMapped]
        public IFormFile ImageUpload { get; set; }
    }
}
