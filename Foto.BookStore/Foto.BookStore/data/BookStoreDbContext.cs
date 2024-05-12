using System;
using System.Collections.Generic;
using Foto.BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace Foto.BookStore.data;

public partial class BookStoreDbContext : DbContext
{
    //public BookStoreDbContext()
    //{
    //}

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }
    //public BookStoreDbContext(DbContextOptions options) : base(options)
    //{
    //}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("BSConn");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    public DbSet<ClsUnit> ClsUnitLst { get; set; }
    public  DbSet<Books> Books { get; set; }
    public  DbSet<LanguageModel> Languages { get; set; }


//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAP-APY;Database=BookStoreDB;User Id=sa;Password=Foto@123;Trusted_Connection=True;Encrypt=False");

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    OnModelCreatingPartial(modelBuilder);
    //    modelBuilder.Entity<UnitsModel>().OwnsOne(x=>x.Lst_Units);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
