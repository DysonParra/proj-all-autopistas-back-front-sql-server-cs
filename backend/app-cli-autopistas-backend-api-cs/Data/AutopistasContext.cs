/*
 * @fileoverview    {AutopistasContext}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Autopistas.Data
{
    public class AutopistasContext : DbContext
    {
        public AutopistasContext (DbContextOptions<AutopistasContext> options)
            : base(options)
        {
        }

        public DbSet<Project.Models.Badge> Badge { get; set; } = default!;

        public DbSet<Project.Models.Categoria> Categoria { get; set; }

        public DbSet<Project.Models.Comparendo> Comparendo { get; set; }

        public DbSet<Project.Models.Conductor> Conductor { get; set; }

        public DbSet<Project.Models.Configuracion> Configuracion { get; set; }

        public DbSet<Project.Models.Menu> Menu { get; set; }

        public DbSet<Project.Models.Mercancia> Mercancia { get; set; }

        public DbSet<Project.Models.Periferico> Periferico { get; set; }

        public DbSet<Project.Models.Pesaje> Pesaje { get; set; }

        public DbSet<Project.Models.Policia> Policia { get; set; }

        public DbSet<Project.Models.RegistroVehiculo> RegistroVehiculo { get; set; }

        public DbSet<Project.Models.TramaComunicacion> TramaComunicacion { get; set; }

        public DbSet<Project.Models.TransitoDinamica> TransitoDinamica { get; set; }

        public DbSet<Project.Models.Usuario> Usuario { get; set; }

        public DbSet<Project.Models.Vehiculo> Vehiculo { get; set; }

        public DbSet<Project.Models.VehiculoSobrepeso> VehiculoSobrepeso { get; set; }
    }
}
