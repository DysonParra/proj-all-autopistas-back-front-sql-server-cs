/*
 * @fileoverview    {TransitoDinamica}
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

/**
 * TODO: Description of {@code TransitoDinamica}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class TransitoDinamica {

        [Key]
        public Int64? IntIdDinamica { get; set; }
        public Int32? IntIdCategoria { get; set; }
        public String? StrPlacaVehiculo { get; set; }
        public DateTime? DtFechaHoraTransito { get; set; }
        public Int32? IntPesoGeneral { get; set; }
        public String? StrPesoEjes { get; set; }
        public Single? FltVelocidad { get; set; }
        public String? TxtBase64Placa { get; set; }

    }

}