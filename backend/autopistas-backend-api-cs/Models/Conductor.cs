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
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
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