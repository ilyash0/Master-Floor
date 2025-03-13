using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterFloor.Models
{
    public partial class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Coeficent { get; set; }
        public List<Product> ProductEntities { get; set; }
        public ProductType(int id, string name, int coeficent)
        {
            Id = id;
            Name = name;
            Coeficent = coeficent;
        }
    }
}
