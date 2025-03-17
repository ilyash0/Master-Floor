using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterFloor.Models
{
    public partial class MaterialType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double ScrapRate { get; set; }
        public MaterialType(int id, string name, double scrapRate)
        {
            Id = id;
            Name = name;
            ScrapRate = scrapRate;
        }
    }
}
