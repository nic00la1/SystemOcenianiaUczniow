using Microsoft.Maui.Controls;
using SystemOcenianiaUczniow.MVVM.Model;
using SystemOcenianiaUczniow.MVVM.ViewModel;

namespace SystemOcenianiaUczniow
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Uczen uczen)
            {
                var viewModel = BindingContext as UczenViewModel;
                viewModel?.WyswietlUczniaCommand.Execute(uczen);
            }
        }
    }
}