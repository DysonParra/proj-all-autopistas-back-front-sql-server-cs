/*
 * @fileoverview    {Usuario}
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
 * TODO: Definición de {@code Usuario}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Usuario {

        [Key]
        public Int64? IntCedulaUsuario { get; set; }
        public String? StrNombreUsuario { get; set; }
        public String? StrApellidoUsuario { get; set; }
        public String? StrSeudonimo { get; set; }
        public Char? EnmTipoUsuario { get; set; }
        public String? StrContrasena { get; set; }
        public String? StrCargoUsuario { get; set; }

    }

}