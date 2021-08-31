using _08312021_Empite_Co_Solution.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08312021_Empite_Co_Solution.Data
{
    public class ProductContext: DbContext
    {
        public ProductContext()
        {

        }

        public ProductContext(DbContextOptions<ProductContext> options): base(options)
        {

        }


        public DbSet<ProductDTOs> iProducts { get; set; }
    }
}
