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
        readonly string[] BtModulations = new string[3] { "GFSK", "pi/4-DQPSK", "8DPSK" };
        readonly string[] Items = new string[7] { "Largura de Faixa a 20 db", "Potência de Pico Máxima", "Emissão Fora da Faixa", "Separação de Canais de Salto", "Numero de Frequencia de Salto", "Numero de Ocupações", "Tempo de Ocupação"};

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

        private void TsItem10_Click(object sender, RoutedEventArgs e)
        {
            LvBtModulation.Items.Clear();
            if (TsItem10.IsOn)
            {
                CheckBox[] cBModulations = new CheckBox[3] { new CheckBox(), new CheckBox(), new CheckBox() };
                cBModulations[0].Content = "Selecionar Todos";
                LvBtModulation.Items.Add(cBModulations[0]);
                for (int i = 1; i < BtModulations.Count(); i++)
                {
                    cBModulations[i].Content = BtModulations[i].ToString();
                    cBModulations[i].Margin = new Thickness(24, 0, 0, 0);
                    LvBtModulation.Items.Add(cBModulations[i]);

                }
                return;
            }
            CheckBox[] cBItems = new CheckBox[8] { new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox() };
            cBItems[0].Content = "Selecionar Todos";
            LvBtModulation.Items.Add(cBItems[0]);
            for (int i = 1; i < Items.Count(); i++)
            {
                cBItems[i].Content = Items[i].ToString();
                cBItems[i].Margin = new Thickness(24, 0, 0, 0);
                LvBtModulation.Items.Add(cBItems[i]);

            }

        }
    }
}
