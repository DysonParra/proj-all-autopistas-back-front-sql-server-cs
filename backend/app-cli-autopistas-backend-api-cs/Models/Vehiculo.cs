/*
 * @fileoverview    {Vehiculo}
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
 * TODO: Description of {@code Vehiculo}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Vehiculo {

        [Key]
        public String? StrPlacaVehiculo { get; set; }
        public String? StrObservaciones { get; set; }
        public Int64? IntIdCategoria { get; set; }

    }

}