/*
 * @overview        {TramaComunicacion}
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
     * TODO: Description of {@code TramaComunicacion}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class TramaComunicacion {

        [Key]
        public Int64? IntIdTrama { get; set; }
        public String? StrNombreTrama { get; set; }
        public Int32? IntPosicionInicial { get; set; }
        public Int32? IntTotalDatosPeso { get; set; }
        public String? CrCaracterFin { get; set; }
        public String? CrCaracterInicio { get; set; }

    }

}