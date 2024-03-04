using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Spesification
{
    public class CatalogFilterSpesification : Specification<Product>
    {
        public CatalogFilterSpesification(int? categoryId, int? brandId)
        {
            if (categoryId.HasValue)
            {
                Query.Where(x => x.CategoryId == categoryId);
            }
            if (brandId.HasValue)
            {
                Query.Where(x => x.BrandId == brandId);
            }
        }

    }
}
