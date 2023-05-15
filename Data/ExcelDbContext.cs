namespace WebApplication5.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication5.Models;
using OfficeOpenXml;
using System.IO;


public class ExcelDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Bird> Birds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Specify the connection string to your Excel file
        optionsBuilder.UseSqlServer("Data Source=database.xlsx");

    }
}

