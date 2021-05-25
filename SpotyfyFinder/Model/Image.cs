////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///<summary>Image</summary>
///
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyfyFinder.Model
{
  public  class Image
    {
        #region Public declarations
        /// <summary>
        /// <param name="Url">Url to Image locations</param>
        /// </summary>
        public int? Height { get; set; }
        public string Url { get; set; }
        public int? Width { get; set; }
        #endregion
    }
}
