using System;
using EBBSCweb.Models;
using Microsoft.EntityFrameworkCore;

namespace EBBSCweb.Data
{
	public class ApplicationDbContext : DbContext
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

        public DbSet<Media> Medias { get; set; }
    }

	
}

