//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///<summary>public class Artist</summary>
///
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyfyFinder.Model
{
  public   class Artist
    {
        #region Public declarations
        /// <summary>
        /// Name of Artists
        /// <param name="URI"></param>
        /// <param name="ExternalUrls"></param>
        /// </summary>
        public ExternalUrls ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        #endregion
    }
}
