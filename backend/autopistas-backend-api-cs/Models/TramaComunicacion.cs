/*
 * @fileoverview    {TramaComunicacion}
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
 * TODO: Definición de {@code TramaComunicacion}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

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