﻿namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     How to group an export
    /// </summary>
    public enum ExportContext
    {
        /// <summary>
        ///     Unknown type
        /// </summary>
        Unknown = 0,

        /// <summary>
        ///     Export by person
        /// </summary>
        People = 1,

        /// <summary>
        ///     Export by household
        /// </summary>
        Households = 2
    }
}