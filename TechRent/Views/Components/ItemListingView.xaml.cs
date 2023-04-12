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
using TechRent.Features.ShowItemListing;

namespace TechRent.Views.Components
{
    /// <summary>
    /// Interaktionslogik für ItemListingView.xaml
    /// </summary>
    public partial class ItemListingView : UserControl
    {
        public ItemListingView()
        {
            InitializeComponent();
        }

        private void PopupButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            var viewModel = button?.DataContext as ItemListingElementViewModel;

            if (viewModel == null)
            {
                return;
            }
            viewModel.IsPopupOpen = true;
        }

        private void ListView_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}
