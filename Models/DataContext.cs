using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace TesteVisitantes.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Visitante> Visitantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server=localhost;database=bcoVisitantes;Uid=root;Pwd=root;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Departamento>().HasData(new List<Departamento>() { 
                new Departamento(1, "Sala"),
                new Departamento(2, "Quarto"),
                new Departamento(3, "Cozinha"),
                new Departamento(4, "Banheiro"),
                new Departamento(5, "Garagem")
            });

            builder.Entity<Visitante>().HasData(new List<Visitante>() {
                new Visitante(1, "Empresa 05", Convert.ToDateTime("08:00"), Convert.ToDateTime("09:00"), Convert.ToDateTime("07/12/2020"),"Eric Figueiredo",3),
                new Visitante(2, "Empresa 04", Convert.ToDateTime("09:00"), Convert.ToDateTime("10:00"), Convert.ToDateTime("07/12/2020"),"Cristiniane Queiroz",2),
                new Visitante(3, "Empresa 03", Convert.ToDateTime("11:00"), Convert.ToDateTime("12:00"), Convert.ToDateTime("07/12/2020"),"Madalena Puca",4),
                new Visitante(4, "Empresa 02", Convert.ToDateTime("10:00"), Convert.ToDateTime("12:00"), Convert.ToDateTime("07/12/2020"),"Miguel Comitre",5),
                new Visitante(5, "Empresa 01", Convert.ToDateTime("12:00"), Convert.ToDateTime("13:00"), Convert.ToDateTime("07/12/2020"),"Márcia do Celso",1)
            });
        }


    }
}
