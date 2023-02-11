/*
 * @fileoverview    {RegistroVehiculo} se encarga de realizar tareas específicas.
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementación realizada.
 * @version 2.0     Documentación agregada.
 */
using System;
using System.ComponentModel.DataAnnotations;

/**
 * TODO: Definición de {@code RegistroVehiculo}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class RegistroVehiculo {

        [Key]
        public Int64? IntTiqueteNro { get; set; }
        public DateTime? DtFechaHoraEstatica { get; set; }
        public Int64? IntPesoEstatica { get; set; }
        public Int64? IntSobrepeso { get; set; }
        public Boolean? BitPesajeAutorizado { get; set; }
        public Boolean? BitComparendo { get; set; }
        public Int64? IntCedulaConductor { get; set; }
        public Int64? IntCedulaUsuario { get; set; }
        public Int64? IntIdCategoria { get; set; }
        public Int64? IntIdMercancia { get; set; }
        public Int64? IntIdRepeso { get; set; }
        public String? StrPlacaVehiculo { get; set; }

    }

}