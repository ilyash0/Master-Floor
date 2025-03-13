using MasterFloor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterFloor.ViewModels
{
    static class PartnerViewModel
    {
        public static List<Partner> GetPartnersForView()
        {
            using DbAppContext ctx = new();
            return ctx.Partners
                .Include(p => p.PartnerTypeEntity)
                .Include(p => p.PartnerProductEntities)
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
    }
}
