using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterFloor.Models
{
    class PartnerProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PartnerId { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quanity { get; set; }
        public Partner PartnerEntity { get; set; }
        public Product ProductEntity { get; set; }
        public PartnerProduct(int id, int productId, int partnerId, DateTime saleDate, int quanity)
        {
            Id = id;
            ProductId = productId;
            PartnerId = partnerId;
            SaleDate = saleDate;
            Quanity = quanity;
        }
    }
}
