using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterFloor.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinCost { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductTypeEntity { get; set; }
        public List<PartnerProduct> PartnerProductEntities { get; set; }
        public Product(int id, string name, int minCost, int productTypeId)
        {
            Id = id;
            Name = name;
            MinCost = minCost;
            ProductTypeId = productTypeId;
        }
    }
}
