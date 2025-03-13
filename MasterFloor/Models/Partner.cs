using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterFloor.Models
{
    public partial class Partner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Inn { get; set; }
        public int Rating { get; set; }
        public int PartnerTypeId { get; set; }
        public PartnerType PartnerTypeEntity { get; set; }
        public List<PartnerProduct> PartnerProductEntities { get; set; }

        public double Discount
        {
            get
            {
                if (PartnerProductEntities == null || PartnerProductEntities.Count == 0)
                {
                    return 0;
                }

                int totalSales = PartnerProductEntities.Sum(p => p.Quanity);

                return totalSales > 300_000 ? .15 :
                    totalSales > 50_000 ? .10 :
                    totalSales > 10_000 ? .05 :
                    0;
            }
        }
        public Partner()
        { }
        public Partner(int id, string name, string director, string email, string phone, string address, string inn, int rating, int partnerTypeId)
        {
            Id = id;
            Name = name;
            Director = director;
            Email = email;
            Phone = phone;
            Address = address;
            Inn = inn;
            Rating = rating;
            PartnerTypeId = partnerTypeId;
        }
    }
}
