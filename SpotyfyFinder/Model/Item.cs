//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///<summary>Item</summary>
///
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyfyFinder.Model
{
   public class Item
    {
        #region Public declarations
        /// <summary>
        /// 
        /// </summary>
        public string Album_type { get; set; }
        public List<Artist> Artists { get; set; }
        public List<string> Available_markets { get; set; }
        public ExternalUrls2 External_urls { get; set; }
        public string Htef { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
        public List<Image> Images { get; set; }
        public int Disc_number { get; set; }
        public int Duration_ms { get; set; }
        public string Preview_url { get; set; }
        public int Track_number { get; set; }
        #endregion
    }


}
