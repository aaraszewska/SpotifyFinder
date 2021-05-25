﻿///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///<summary>Album List Page</summary>
///
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Interaction logic for AlbumListPage.xaml
    /// </summary>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public partial class AlbumListPage : Page
    {
        private HttpGrabber http;
        #region Metods
        public AlbumListPage()
        {
            InitializeComponent();
        }
        public AlbumListPage(HttpGrabber http)
        {
            InitializeComponent();
            this.http = http;
        }
        
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///<summary>OnPagesLoaded </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
          

            http.SearchList.CollectionChanged += SearchList_CollectionChanged;

            }
        
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Search List</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void SearchList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DataList.ItemsSource = http.SearchList;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 
        ///<summary>OnLeftMouseClick </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void OnLeftMouseButtonClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = (sender as ListView).SelectedItem as Item;
                MainWindow._mainFrame.Navigate(new AlbumDetailsPage(item,http));
                

            }
            catch
            {
                //just pass
            }
            
            
        }
        #endregion
    }
}
