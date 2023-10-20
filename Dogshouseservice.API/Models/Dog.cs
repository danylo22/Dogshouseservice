using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Dogshouseservice.API.Models
{
    public class Dog : BaseModel
    {
        public Dog(string name, string color, int tailLength, int weight)
        {
            Name = name;
            Color = color;
            TailLength = tailLength;
            Weight = weight;
        }
        public string Name { get; set; }
        public string Color { get; set; }
        public int TailLength { get; set; }
        public int Weight { get; set; }
    }
}
