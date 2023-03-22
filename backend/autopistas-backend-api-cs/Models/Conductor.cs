/*
 * @fileoverview    {Conductor}
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
 * TODO: Definición de {@code Conductor}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Conductor {

        [Key]
        public Int64? IntCedulaConductor { get; set; }
        public String? StrNombreConductor { get; set; }
        public String? StrApellidoConductor { get; set; }
        public String? StrTelefono { get; set; }

    }

}