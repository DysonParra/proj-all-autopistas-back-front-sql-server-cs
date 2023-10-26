/*
 * @fileoverview    {Periferico}
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
 * TODO: Definición de {@code Periferico}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Periferico {

        [Key]
        public Int64? IntId { get; set; }
        public String? EnmTipoPeriferico { get; set; }
        public String? StrIp { get; set; }
        public Int64? IntPuerto { get; set; }
        public String? StrCodigo { get; set; }

    }

}