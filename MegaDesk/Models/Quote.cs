using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MegaDesk.Models
{
    public class Quote
    {
        public int ID { get; set; }

        [Display(Name = "Date"), DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Range(24, 96, ErrorMessage = "Width must be between 24 inches and 96 inches"), Required]
        public int Width { get; set; }

        [Range(12, 24, ErrorMessage = "Depth must be between 12 inches and 24 inches"), Required]
        public int Depth { get; set; }

        [Range(0, 7, ErrorMessage = "Number of Drawers must be between 0 and 7"), Required]
        [Display(Name = "Number of Drawers")]
        public int CountDrawer { get; set; }

        [Display(Name = "Build Time"), Required]
        public int BuildOption { get; set; }

        [Display(Name = "Material"), Required]
        public string SurfaceMaterial { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Final Cost")]
        public int FinalCost { get; set; }

        //Surface material enum
        public enum SurfaceMaterials { Oak, Laminate, Pine, Rosewood, Veneer }




    }
}