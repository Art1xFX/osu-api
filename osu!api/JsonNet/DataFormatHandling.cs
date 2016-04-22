﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonNet
{
    /// <summary>
    /// Specifies how dates are formatted when writing JSON text.
    /// </summary>
    public enum DateFormatHandling
    {
        /// <summary>
        /// Dates are written in the ISO 8601 format, e.g. "2012-03-21T05:40Z".
        /// </summary>
        IsoDateFormat,

        /// <summary>
        /// Dates are written in the Microsoft JSON format, e.g. "\/Date(1198908717056)\/".
        /// </summary>
        MicrosoftDateFormat
    }
}