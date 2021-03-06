﻿namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     The status of an export
    /// </summary>
    public enum ExportStatus
    {
        /// <summary>
        ///     Unknown
        /// </summary>
        Unknown = 0,

        /// <summary>
        ///     Queued
        /// </summary>
        Queued = 1,

        /// <summary>
        ///     Working
        /// </summary>
        Working = 2,

        /// <summary>
        ///     Completed
        /// </summary>
        Completed = 3
    }
}