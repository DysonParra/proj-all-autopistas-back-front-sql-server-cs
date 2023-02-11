/*
 * @fileoverview    {Menu} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code Menu}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Menu {

        [Key]
        public String? StrId { get; set; }
        public String? StrTitle { get; set; }
        public String? StrSubtitle { get; set; }
        public String? StrType { get; set; }
        public String? StrIcon { get; set; }
        public String? StrLink { get; set; }
        public Boolean? BitExactMatch { get; set; }
        public Boolean? BitActive { get; set; }
        public Boolean? BitDisabled { get; set; }
        public String? StrBadge { get; set; }
        public String? StrFather { get; set; }

    }

}