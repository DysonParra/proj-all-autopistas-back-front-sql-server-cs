/*
 * @fileoverview    {Mercancia}
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
 * TODO: Definición de {@code Mercancia}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Mercancia {

        [Key]
        public Int64? IntIdMercancia { get; set; }
        public String? StrNombreMercancia { get; set; }
        public String? StrDescripcionMercancia { get; set; }

    }

}