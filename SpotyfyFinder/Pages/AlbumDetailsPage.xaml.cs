///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///<summary>Album details page</summary>
///
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using SpotyfyFinder.Data;
using SpotyfyFinder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpotyfyFinder.Pages
{
    /// <summary>
    /// Interaction logic for AlbumDetailsPage.xaml
    /// </summary>
    public partial class AlbumDetailsPage : Page
    {
        #region Private declarations
        private Item albumItem;
        private HttpGrabber http;
        #endregion
        #region Constructions
        public AlbumDetailsPage(Item item, HttpGrabber http)
        {
            InitializeComponent();
            this.albumItem = item;
            this.http = http;
     
        }

        private void OnPagesLoaded(object sender, RoutedEventArgs e)
        {
           
            GetData(albumItem.Id);


        }

       

        private async Task GetData(string albumId)
        {
          var data =  await http.SerializeDataForSingleAlbum(albumId);
            BigImage.Source =  new BitmapImage(new Uri (data.Images.FirstOrDefault().Url));
            TrackPlayer.Source = new Uri (data.Tracks.Items.FirstOrDefault().Preview_url);
            

            
            

        }

        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow._mainFrame.GoBack();
        }
        #endregion
    }
}
