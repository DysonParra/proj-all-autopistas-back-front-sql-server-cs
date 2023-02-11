/*
 * @fileoverview    {Policia} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code Policia}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Policia {

        [Key]
        public Int64? IntIdPolicia { get; set; }
        public String? StrNombrePolicia { get; set; }
        public String? StrApellidoPolicia { get; set; }
        public String? StrTelefono { get; set; }

    }

}