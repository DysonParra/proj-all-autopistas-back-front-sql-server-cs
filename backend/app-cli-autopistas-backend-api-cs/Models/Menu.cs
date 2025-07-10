/*
 * @overview        {Menu}
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

namespace Project.Models {

    /**
     * TODO: Description of {@code Menu}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
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