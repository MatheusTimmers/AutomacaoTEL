using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace AutomaçãoTEL.Views
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class Wifi : Page
    {
        public Wifi()
        {
            this.InitializeComponent();
        }

        private void SelectAll_Checked(object sender, RoutedEventArgs e)
        {
            Option1CheckBox.IsChecked = Option2CheckBox.IsChecked = Option3CheckBox.IsChecked = Option4CheckBox.IsChecked = Option5CheckBox.IsChecked
            = Option6CheckBox.IsChecked = Option7CheckBox.IsChecked = Option8CheckBox.IsChecked = Option9CheckBox.IsChecked = Option10CheckBox.IsChecked
            = Option11CheckBox.IsChecked = Option12CheckBox.IsChecked = Option13CheckBox.IsChecked = Option14CheckBox.IsChecked = true; 
        }

        private void SelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            Option1CheckBox.IsChecked = Option2CheckBox.IsChecked = Option3CheckBox.IsChecked = Option4CheckBox.IsChecked = Option5CheckBox.IsChecked
            = Option6CheckBox.IsChecked = Option7CheckBox.IsChecked = Option8CheckBox.IsChecked = Option9CheckBox.IsChecked = Option10CheckBox.IsChecked
            = Option11CheckBox.IsChecked = Option12CheckBox.IsChecked = Option13CheckBox.IsChecked = Option14CheckBox.IsChecked = false;
        }

        private void SelectAll_Indeterminate(object sender, RoutedEventArgs e)
        {
            if (Option1CheckBox.IsChecked == true && Option2CheckBox.IsChecked == true && Option3CheckBox.IsChecked == true && Option4CheckBox.IsChecked == true && Option5CheckBox.IsChecked == true &&
                Option6CheckBox.IsChecked == true && Option7CheckBox.IsChecked == true && Option8CheckBox.IsChecked == true && Option9CheckBox.IsChecked == true && Option10CheckBox.IsChecked == true &&
                Option11CheckBox.IsChecked == true && Option12CheckBox.IsChecked == true && Option13CheckBox.IsChecked == true && Option14CheckBox.IsChecked == true)
            {
                OptionsAllCheckBox.IsChecked = false;
            }
        }

        private void Option_Checked(object sender, RoutedEventArgs e)
        {
            SetCheckedState();
        }

        private void Option_Unchecked(object sender, RoutedEventArgs e)
        {
            SetCheckedState();
        }

        private void SetCheckedState()
        {
            if (Option1CheckBox != null)
            {
                if (Option1CheckBox.IsChecked == true && Option2CheckBox.IsChecked == true && Option3CheckBox.IsChecked == true && Option4CheckBox.IsChecked == true && Option5CheckBox.IsChecked == true &&
                Option6CheckBox.IsChecked == true && Option7CheckBox.IsChecked == true && Option8CheckBox.IsChecked == true && Option9CheckBox.IsChecked == true && Option10CheckBox.IsChecked == true &&
                Option11CheckBox.IsChecked == true && Option12CheckBox.IsChecked == true && Option13CheckBox.IsChecked == true && Option14CheckBox.IsChecked == true)
                {
                    OptionsAllCheckBox.IsChecked = true;
                }
                else if (Option1CheckBox.IsChecked == false && Option2CheckBox.IsChecked == false && Option3CheckBox.IsChecked == false && Option4CheckBox.IsChecked == false && Option5CheckBox.IsChecked == false &&
                Option6CheckBox.IsChecked == false && Option7CheckBox.IsChecked == false && Option8CheckBox.IsChecked == false && Option9CheckBox.IsChecked == false && Option10CheckBox.IsChecked == false &&
                Option11CheckBox.IsChecked == false && Option12CheckBox.IsChecked == false && Option13CheckBox.IsChecked == false && Option14CheckBox.IsChecked == false)
                {
                    OptionsAllCheckBox.IsChecked = false;
                }
                else
                {
                    OptionsAllCheckBox.IsChecked = null;
                }
            }
        }

    }
}
