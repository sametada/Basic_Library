﻿using Microsoft.EntityFrameworkCore;
using WebApplication_01.Models;
// veri tabanı ef tablosu oluşturmak için buraya ilgili model sınıfı eklenir.
namespace WebApplication_01.Utility
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options):base(options) {   }

        public DbSet<KitapTuru> KitapTurleri { get; set; }
		public DbSet<Kitap> Kitaplar { get; set; }
		public DbSet<Kiralama> Kiralamalar { get; set; }
	}
}
