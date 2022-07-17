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
    public sealed partial class Bluetooth : Page
    {
        public Bluetooth()
        {
            this.InitializeComponent();
        }

        private void SelectAll_Checked(object sender, RoutedEventArgs e)
        {
            Option1CheckBox.IsChecked = Option2CheckBox.IsChecked = Option3CheckBox.IsChecked = true;
        }

        private void SelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            Option1CheckBox.IsChecked = Option2CheckBox.IsChecked = Option3CheckBox.IsChecked = false;
        }

        private void SelectAll_Indeterminate(object sender, RoutedEventArgs e)
        {
            if (Option1CheckBox.IsChecked == true && 
                Option2CheckBox.IsChecked == true && 
                Option3CheckBox.IsChecked == true)
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
                if (Option1CheckBox.IsChecked == true && 
                    Option2CheckBox.IsChecked == true && 
                    Option3CheckBox.IsChecked == true)
                {
                    OptionsAllCheckBox.IsChecked = true;
                }
                else if (Option1CheckBox.IsChecked == false && 
                    Option2CheckBox.IsChecked == false && 
                    Option3CheckBox.IsChecked == false)
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
