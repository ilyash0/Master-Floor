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
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Partners
                    .Include(p => p.PartnerTypeEntity)
                    .Include(p => p.PartnerProductEntities)
                    .ToList();
            }
        }
    }
}
