﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MegaDesk.Models
{
    public class Quote
    {
        public int ID { get; set; }
        [Display(Name = "Date"), DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public int Width { get; set; }
        public int Depth { get; set; }
        public int CountDrawer { get; set; }
        public string SurfaceMaterial { get; set; }
        public string CustomerName { get; set; }
        public string BuildOption { get; set; }
        public string FinalCost { get; set; }

        //Surface material enum
        public enum SurfaceMaterials { Oak, Laminate, Pine, Rosewood, Veneer }

    }
}