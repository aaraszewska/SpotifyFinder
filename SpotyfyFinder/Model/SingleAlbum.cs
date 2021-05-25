///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///<summary>Single Album</summary>
///
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyfyFinder.Model
{
   public class SingleAlbum
    {
        #region Public declarations
        /// <summary>
        /// <param name="Album_type">Type of albums</param>
        /// <param name="Artists">Name of artists</param>
        /// </summary>
        public string Album_type { get; set; }
        public List<Artist> Artists { get; set; }
        public List<string> Available_markets { get; set; }
        public ExternalUrls2 ExternalUrls { get; set; }
       // public List<object> genres { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public string Release_date { get; set; }
        public string Release_date_precision { get; set; }
        public Tracks Tracks { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        #endregion

    }
}
