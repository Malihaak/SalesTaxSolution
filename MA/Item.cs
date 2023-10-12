using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    class Item
    {
        public string Name { get; }
        public decimal Price { get; }
        public bool IsImported { get; }
        public bool IsExempt { get; }

        public Item(string name, decimal price, bool isImported, bool isExempt)
        {
            Name = name;
            Price = price;
            IsImported = isImported;
            IsExempt = isExempt;
        }
        public decimal GetSalesTax()
        {
            decimal salesTaxRate = 0m; 
           if (!IsExempt)
            {
                salesTaxRate = 0.1m; // 10% basic sales tax
            }
            
            if (IsImported)
            {
                salesTaxRate += 0.05m; // 5% import tax
            }

            decimal salesTax = Math.Ceiling(Price * salesTaxRate / 0.05m) * 0.05m; // Round off to nearest 5 cents
            return salesTax;
        }

        public decimal GetTotalPrice()
        {
            decimal total = Price + GetSalesTax();
            return total;
        }
    }
    
}

