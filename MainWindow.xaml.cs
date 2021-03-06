using SpotyfyFinder.Data;
using SpotyfyFinder.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpotyfyFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        private  HttpGrabber http = new HttpGrabber();
        internal static Frame _mainFrame;
        AlbumListPage albumListPage;

        
        public MainWindow()
        {
            InitializeComponent();
        }

       private void IntProgram()
        {
            _mainFrame = MyFrame;

            albumListPage = new AlbumListPage(http);
            _mainFrame.Navigate(albumListPage);

        }

       
        private async Task GetData(string search)
        {
            await http.MakeStringGreatAgain(search);
            

        }



        private void SearchBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            string search = searchBox.Text;
            if (search.Length > 2 && TimeBetwenkeyUp(500, search))
            {
                GetData(search);
            }
         
        }
        private int lastSearchStringLength = 0;
        private long lastKeyUp = 0;
        private bool TimeBetwenkeyUp(int time, string search)
        {
            bool searchAfterTime = false;

            if (search.Length == lastSearchStringLength)

                return false;
            var elapsedTics = Stopwatch.GetTimestamp() - lastKeyUp;
            var elapsedTimeMs = elapsedTics * 1000000 / Stopwatch.Frequency;

            if (elapsedTimeMs > time)
            {
                searchAfterTime = true;
            }

            lastKeyUp = Stopwatch.GetTimestamp();



            return searchAfterTime;
        }
        /// <summary>
        /// metoda inicjaca program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            IntProgram();
        }
    }
}
