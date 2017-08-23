using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
using Image = System.Drawing.Image;

namespace WarframeDucatLister
{
    public partial class MainWindow : Window, IDisposable
    {
        private readonly WarframeDucatLister _warframeDucatLister;
        private readonly PrimeDatabase _primeDatabase;

        public MainWindow()
        {
            InitializeComponent();
            _warframeDucatLister = new WarframeDucatLister();
            _primeDatabase = new PrimeDatabase();
        }

        private void GetPrimeValuesButton_OnClick(object sender, RoutedEventArgs e)
        {
            Image screenShot = _warframeDucatLister.GetScreenshot();
            screenShot.Save(Guid.NewGuid().ToString() + ".png", ImageFormat.Png);
            var options = _warframeDucatLister.GetOptions(screenShot);
            PrimeValuesDataGrid.ItemsSource = _primeDatabase.GetPrimeItems(options);
        }

        public void Dispose()
        {
            _warframeDucatLister?.Dispose();
        }
    }
}