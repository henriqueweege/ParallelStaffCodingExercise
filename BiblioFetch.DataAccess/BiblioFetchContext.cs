﻿using BiblioFetch.Configurations;
using BiblioFetch.DataAccess.Contract;
using BiblioFetch.Models;
using Microsoft.EntityFrameworkCore;

namespace BiblioFetch.DataAccess
{
    public class BiblioFetchContext : DbContext, IBiblioFetchContext
    {


        public BiblioFetchContext(DbContextOptionsBuilder dbContextOptionsBuilder) : base(dbContextOptionsBuilder.Options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            //if (EnvironmentVerificator.IsTestEnv())
            //{
            //    dbContextOptionsBuilder.UseInMemoryDatabase(databaseName: "BiblioFetchDb");
            //}
            //else if (_dbContextOptionsBuilder == null)
            //{
            //    dbContextOptionsBuilder.UseMySql((""), ServerVersion.AutoDetect(""));
            //}
            dbContextOptionsBuilder.UseMySql(AppSettings.ConnectionString, ServerVersion.AutoDetect(AppSettings.ConnectionString));

        }

        public DbSet<BookModel> Books { get; set; }

    }
}