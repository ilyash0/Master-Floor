using MasterFloor.Models;
using Microsoft.EntityFrameworkCore;
using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace MasterFloor.ViewModels
{
    static class ViewModel
    {
        public static List<Partner> GetPartnersForView()
        {
            using DbAppContext ctx = new();
            return ctx.Partners
                .Include(p => p.PartnerTypeEntity)
                .Include(p => p.PartnerProductEntities)
                .ToList();
        }
        public static List<PartnerProduct> GetPartnersProductsForView(int partnerId)
        {
            using DbAppContext ctx = new();
            return ctx.PartnersProducts
                    .Include(pp => pp.ProductEntity)
                    .Where(pp => pp.PartnerId == partnerId)
                    .OrderByDescending(pp => pp.SaleDate)
                    .ToList();
        }

        public static List<PartnerType> GetPartnerTypesForView()
        {
            using DbAppContext ctx = new();
            return ctx.PartnerTypes.ToList();
        }

        public static void CreateNewPartner(Partner partner)
        {
            if (partner.Id != 0)
            {
                return;
            }

            using DbAppContext ctx = new();
            ctx.Partners.Add(partner);
            ctx.SaveChanges();
        }

        public static void UpdatePartner(Partner partner)
        {
            if (partner.Id == 0)
            {
                return;
            }

            using DbAppContext ctx = new();
            ctx.Partners.Update(partner);
            ctx.SaveChanges();
        }

        public static ProductType GetProductTypeById(int productId)
        {
            using DbAppContext ctx = new();
            return ctx.ProductTypes
                      .FirstOrDefault(p => p.Id == productId);
        }

        public static MaterialType GetMaterialTypeById(int productId)
        {
            using DbAppContext ctx = new();
            return ctx.MaterialTypes
                      .FirstOrDefault(p => p.Id == productId);
        }
        public static List<ProductType> GetProductTypesForView()
        {
            using DbAppContext ctx = new();
            return ctx.ProductTypes
                      .ToList();
        }

        public static List<MaterialType> GetMaterialTypesForView()
        {
            using DbAppContext ctx = new();
            return ctx.MaterialTypes
                      .ToList();
        }
    }
}
