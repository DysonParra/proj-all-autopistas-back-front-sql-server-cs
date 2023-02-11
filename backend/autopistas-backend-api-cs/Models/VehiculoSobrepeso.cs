/*
 * @fileoverview    {VehiculoSobrepeso} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code VehiculoSobrepeso}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class VehiculoSobrepeso {

        [Key]
        public Int64? IntIdRepeso { get; set; }
        public Int32? IntPesoMaximo { get; set; }
        public Int32? IntDiferenciaPeso { get; set; }
        public String? StrPlacaVehiculo { get; set; }
        public Boolean? BitBorrado { get; set; }
        public Int64? IntIdDinamica { get; set; }

    }

}