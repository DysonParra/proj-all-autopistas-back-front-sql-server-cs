/*
 * @fileoverview    {RegistroVehiculo}
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
     * TODO: Description of {@code RegistroVehiculo}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
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