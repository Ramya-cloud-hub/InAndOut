using InAndOut.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Data
{
    public class ApplicationDBCOntext : DbContext
    {
        public ApplicationDBCOntext(DbContextOptions<ApplicationDBCOntext> options) :base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}
