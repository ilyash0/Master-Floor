using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterFloor.Models
{
    class PartnerType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Partner> PartnerEntities { get; set; }
        public PartnerType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
