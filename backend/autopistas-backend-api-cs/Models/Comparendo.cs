/*
 * @fileoverview    {Comparendo}
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
 * TODO: Definición de {@code Comparendo}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Comparendo {

        [Key]
        public Int64? IntIdComparendo { get; set; }
        public Int32? IntCodigoComparendo { get; set; }
        public String? StrObservaciones { get; set; }
        public Char? EnmTipoInfractor { get; set; }
        public Int64? IntCedulaConductor { get; set; }
        public Int64? IntIdPolicia { get; set; }
        public String? StrPlacaVehiculo { get; set; }
        public Int64? IntTiqueteNro { get; set; }

    }

}