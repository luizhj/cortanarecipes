using System;
using System.Collections.Generic;
using System.Text;

namespace cortanarecipes.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public double Quantity { get; set; }
        public string Measures { get; set; }
        public string Name { get; set; }
    }
}
