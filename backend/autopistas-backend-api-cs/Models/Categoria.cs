/*
 * @fileoverview    {Categoria}
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
 * TODO: Definición de {@code Categoria}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Categoria {

        [Key]
        public Int64? IntIdCategoria { get; set; }
        public String? StrCategoria { get; set; }
        public Int32? IntPesoMaximo { get; set; }
        public Int32? IntTolerancia { get; set; }
        public String? StrDescripcion { get; set; }
        public Int32? IntEjeSencillo { get; set; }
        public Int32? IntEjeTandem { get; set; }
        public Int32? IntTotalEjes { get; set; }

    }

}