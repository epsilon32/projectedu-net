using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projectedu.API.Helpers
{
    /// <summary>
    /// Representation of the appsettings.json
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// JWT key
        /// </summary>
        public string Secret { get; set; }
    }
}
