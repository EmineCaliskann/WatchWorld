﻿using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Spesifications
{
    public class BasketWithItemSpecification :Specification<Basket>
    {
        public BasketWithItemSpecification(string buyerId)
        {
            Query.Where(x => x.BuyerId == buyerId)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product);
        }
    }
}
