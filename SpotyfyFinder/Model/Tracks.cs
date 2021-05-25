///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///<summary>Tracks</summary>
///
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyfyFinder.Model
{
   public  class Tracks
    {
        #region Public declarations
        /// <summary>
        /// 
        /// </summary>
        public string Href { get; set; }
        public List<Item> Items { get; set; }
        public int Limit { get; set; }
        public object Next { get; set; }
        public int Offset { get; set; }
        public object Previous { get; set; }
        public int Total { get; set; }
        #endregion
    }
}
