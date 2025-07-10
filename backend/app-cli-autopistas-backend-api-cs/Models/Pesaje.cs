/*
 * @overview        {Pesaje}
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
     * TODO: Description of {@code Pesaje}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class Pesaje {

        [Key]
        public Int64? IntId { get; set; }
        public Int64? IntTiqueteNumero { get; set; }
        public String? StrPlaca { get; set; }
        public String? StrCodigo { get; set; }
        public Int64? IntNumeroInterno { get; set; }
        public String? StrTipoVehiculo { get; set; }
        public String? StrConductor { get; set; }
        public String? StrCedula { get; set; }
        public String? StrProducto { get; set; }
        public String? StrPlanta { get; set; }
        public String? StrCliente { get; set; }
        public String? StrTransportadora { get; set; }
        public DateTime? DtFechaHoraPesoVacio { get; set; }
        public DateTime? DtFechaHoraPesoLleno { get; set; }
        public String? StrCiv { get; set; }
        public String? StrDireccion { get; set; }
        public String? StrEntregadoPor { get; set; }
        public String? StrRecibidoPor { get; set; }
        public String? StrShipment { get; set; }
        public String? StrSello { get; set; }
        public String? StrR { get; set; }
        public String? StrContenedor { get; set; }
        public String? StrObservacion { get; set; }
        public String? EnmTipoIngreso { get; set; }

    }

}