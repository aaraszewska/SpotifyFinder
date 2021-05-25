////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///<summary>Http Grabber</summary>
///<author>Anna Araszewska</author>
///<date> 30.01.2020</date>
///
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using Newtonsoft.Json;
using SpotyfyFinder.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace SpotyfyFinder.Data
{
   
    public class HttpGrabber
    {
        #region Private declarations
        private string baseAddress = "https://api.spotify.com/v1/";
        #endregion
        #region Intearial declarations

        internal ObservableCollection<Item> SearchList = new ObservableCollection<Item>();
        #endregion
        #region Metods
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///<summary> Serialize Root Object</summary>
        ///<param name="AlbumList"> List of albums</param>
        ///<param name="root"> Deserialize object json </param>
        /// 
        /// <param name="search"></param>
        /// <returns></returns>
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task MakeStringGreatAgain(string search)
        {
            AlbumsList root = new AlbumsList();

            try
            {
                root = JsonConvert.DeserializeObject<AlbumsList>(await GetFromStream(search));

            }

            catch (Exception ex)
            {
                var a = ex.Message.ToString();
            }
            try
            {
                SearchList.ToList().All(p => SearchList.Remove(p));
                foreach (var item in root.Albums.Items) SearchList.Add(item);
            }
            catch (Exception)
            {
                //just pass
            }


        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Serialize Data for single album</sumary>
        ///<param name="root">Deserialize object single album json</param>
        /// <param name="albumId"></param>
        /// <returns></returns>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      
        public async Task<SingleAlbum> SerializeDataForSingleAlbum(string albumId)
        {
            SingleAlbum root = new SingleAlbum();

            try
            {
                root = JsonConvert.DeserializeObject<SingleAlbum>(await GetSingleAlbumStreem(albumId));

            }

            catch (Exception ex)
            {
                var a = ex.Message.ToString();
            }

            return root;
        }


       
       /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       ///<summary>Get HTTP </summary>
       /// <param name="search"></param>
       /// <returns></returns>
       /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private async Task<string> GetFromStream(string search)
        {
            string testRequest = search;
            try
            {
                var response = await GetRequestAsync(testRequest);

                using (var responseReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    return await responseReader.ReadToEndAsync();
                }


            }



            catch (Exception ex)
            {
                string error = ex.Message.ToString();

                //just pass
            }

            return testRequest;
        }
        
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private async Task<string> GetSingleAlbumStreem(string albumId)
        {
            string testRequest = albumId;
            try
            {
                var response = await GetSingleAlbumAsync(testRequest);

                using (var responseReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    return await responseReader.ReadToEndAsync();
                }


            }



            catch (Exception ex)
            {
                string error = ex.Message.ToString();

                //just pass
            }

            return testRequest;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>HTTP WEBrequest</summary>
        /// 
        /// <param name="testRequest"></param>
        /// <returns></returns>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private async Task<WebResponse> GetRequestAsync(string testRequest)
        {
            try
            {
                var request = HttpWebRequest.CreateHttp(baseAddress + "search?q=" + testRequest + "&type=album");
                request.Method = WebRequestMethods.Http.Get;
                request.Headers.Add("Authorization:  Bearer BQAM5JyxIEpmRt9G8PiZCcuulu6PE8RC1L745l7ELIN41EuedfKdyAeAlDN-wbgW3jo_DJzGw9hz-9wBlbo9Jt9Z4JMt1Wm3cvScGB3_s9v3dCONtMQI_VTXGKyte7sXpZ9ILeQHdWfeql8DTtTnVTMxP32gWQYK4u-CHGXTcDzxqohomrTc_tBcJDhhQvqrIJ20n0-ssK4m2urZcgY2");
                request.ContentType = "application/json; charset=utf-8";

                return await request.GetResponseAsync();
            }
            catch (WebException wex)
            {
                return wex?.Response as WebResponse;
            }

            catch (Exception)
            {

            }
            return null;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Get single album</summary>
        /// <param name="testRequest"></param>
        /// <returns></returns>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private async Task<WebResponse> GetSingleAlbumAsync(string albumId)
        {
            try
            {


                var request = HttpWebRequest.CreateHttp(baseAddress + "albums/" + albumId);
                request.Method = WebRequestMethods.Http.Get;
                request.Headers.Add("Authorization: Bearer BQAM5JyxIEpmRt9G8PiZCcuulu6PE8RC1L745l7ELIN41EuedfKdyAeAlDN-wbgW3jo_DJzGw9hz-9wBlbo9Jt9Z4JMt1Wm3cvScGB3_s9v3dCONtMQI_VTXGKyte7sXpZ9ILeQHdWfeql8DTtTnVTMxP32gWQYK4u-CHGXTcDzxqohomrTc_tBcJDhhQvqrIJ20n0-ssK4m2urZcgY2");
                request.ContentType = "application/json; charset=utf-8";

                return await request.GetResponseAsync();
            }
            catch (WebException wex)
            {
                return wex?.Response as WebResponse;
            }

            catch (Exception)
            {

            }
            return null;
        }
        #endregion
    }
}
