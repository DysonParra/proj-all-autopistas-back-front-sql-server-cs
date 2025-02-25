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
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Models {

    /**
     * TODO: Description of {@code Comparendo}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
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