using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GP.App.ViewModels;

namespace GP.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base( options )
        {
        }
        public DbSet<GP.App.ViewModels.MarcaViewModel> MarcaViewModel { get; set; }
        public DbSet<GP.App.ViewModels.PatrimonioViewModel> PatrimonioViewModel { get; set; }
    }
}
