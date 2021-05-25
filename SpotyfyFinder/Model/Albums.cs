///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///
///<summary> public class Album </summary>
///<author>Anna Araszewska</author>
///<date>30.01.2020</date>
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyfyFinder.Model
{
    
    public class Albums
    {
        #region Public declarations
        /// <summary>
        /// <param name="List"> List of albums in Spotify</param>
        /// </summary>
        public string Href { get; set; }
        public List<Item> Items { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public int Offset { get; set; }
        public object Previous { get; set; }
        public int Total { get; set; }
    }
    #endregion

}
