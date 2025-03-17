using MasterFloor.Models;
using MasterFloor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MasterFloor
{
    internal class Utils
    {
        public static int CalculateRequiredMaterial(int productTypeId, int materialTypeId, int quantity, double width, double length)
        {

            ProductType? productType = ViewModel.GetProductTypeById(productTypeId);
            if (productType == null)
            {
                return -1;
            }

            MaterialType? materialType = ViewModel.GetMaterialTypeById(materialTypeId);
            if (materialType == null)
            {
                return -1;
            }

            double productCoefficient = productType.Coeficent;
            double scrapRate = materialType.ScrapRate;

            double materialPerUnit = width * length * productCoefficient;

            double totalMaterial = materialPerUnit * quantity * (1 + scrapRate);

            return (int)Math.Ceiling(totalMaterial);
        }
    }
}
