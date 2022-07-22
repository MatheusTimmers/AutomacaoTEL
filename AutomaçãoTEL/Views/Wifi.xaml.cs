using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace AutomaçãoTEL.Views
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class Wifi : Page
    {
        readonly string[] WifiModulations = new string[14] { "Bluetooth Low Energy", "802.11a", "802.11b", "802.11g", "802.11n (20)", "802.11n (40)", "802.11n (80)", "802.11ac (20)", "802.11ac (40)", "802.11ac (80)", "802.11ax (20)", "802.11ax (40)", "802.11ax (80)", "802.11ax (160)"};
        readonly string[] Items = new string[9] { "Largura de Faixa a 6 dB", "Largura de Faixa a 26 dB", "Potência de Pico Máxima", "Valor Médio da Potência máxima de Saida", "Pico da Densidade de Potência", "Valor Médio da Densidade Espectral", "Emissão fora de faixa", "Potencia de Saida", "Densidade Espectral de Potência" };
        readonly CheckBox[] cBModulations = new CheckBox[15] { new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox() };
        readonly CheckBox[] cBItems = new CheckBox[10] { new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox()};

        public Wifi()
        {
            this.InitializeComponent();
            cBItems[0].Checked += SelectAll_Checked;
            cBItems[0].Unchecked += SelectAll_Unchecked;
            cBItems[0].Indeterminate += SelectAll_Indeterminate;
            for (int i = 1; i < cBItems.Length; i++)
            {
                cBItems[i].Checked += Option_Checked;
                cBItems[i].Unchecked += Option_Unchecked;

            }
            cBModulations[0].Checked += SelectAll_Checked;
            cBModulations[0].Unchecked += SelectAll_Unchecked;
            cBModulations[0].Indeterminate += SelectAll_Indeterminate;
            for (int i = 1; i < cBModulations.Length; i++)
            {
                cBModulations[i].Checked += Option_Checked;
                cBModulations[i].Unchecked += Option_Unchecked;

            }
            ChangeContentLv();
        }

        private void SelectAll_Checked(object sender, RoutedEventArgs e)
        {
            if (TsItems.IsOn)
            {
                for (int i = 1; i <= Items.Length; i++)
                {
                    cBItems[i].IsChecked = true;
                }
                SetCheckedState();
            }
            else
            {
                for (int i = 1; i <= WifiModulations.Length; i++)
                {
                    cBModulations[i].IsChecked = true;
                }
                SetCheckedState();
            }
        }

        private void SelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            if (TsItems.IsOn)
            {
                for (int i = 1; i <= Items.Length; i++)
                {
                    cBItems[i].IsChecked = false;
                }
                SetCheckedState();
            }
            else
            {
                for (int i = 1; i <= WifiModulations.Length; i++)
                {
                    cBModulations[i].IsChecked = false;
                }
                SetCheckedState();
            }

        }

        private void SelectAll_Indeterminate(object sender, RoutedEventArgs e)
        {
            int cont = 0;
            if (TsItems.IsOn)
            {
                for (int i = 1; i <= Items.Length; i++)
                {
                    if (cBItems[i].IsChecked == true)
                    {
                        cont++;
                    }
                }
                if (cont == Items.Length)
                {
                    cBItems[0].IsChecked = false;
                }
                SetCheckedState();
            }
            else
            {
                for (int i = 1; i <= WifiModulations.Length; i++)
                {
                    if (cBModulations[i].IsChecked == true)
                    {
                        cont++;
                    }
                }
                if (cont == WifiModulations.Length)
                {
                    cBModulations[0].IsChecked = false;
                }
                SetCheckedState();
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
            int cont = 0;
            if (TsItems.IsOn)
            {
                if (cBItems[1] != null)
                {
                    for (int i = 1; i <= Items.Length; i++)
                    {
                        if (cBItems[i].IsChecked == true)
                        {
                            cont++;
                        }
                    }
                    if (cont == Items.Length)
                    {
                        cBItems[0].IsChecked = true;
                    }
                    else
                    {
                        cont = 0;
                        for (int i = 1; i <= Items.Length; i++)
                        {
                            if (cBItems[i].IsChecked == false)
                            {
                                cont++;
                            }
                        }
                        if (cont == Items.Length)
                        {
                            cBItems[0].IsChecked = false;
                        }
                        else
                        {
                            cBItems[0].IsChecked = null;
                        }
                    }

                }
            }
            else
            {
                if (cBModulations[1] != null)
                {
                    for (int i = 1; i <= WifiModulations.Length; i++)
                    {
                        if (cBModulations[i].IsChecked == true)
                        {
                            cont++;
                        }
                    }
                    if (cont == WifiModulations.Length)
                    {
                        cBModulations[0].IsChecked = true;
                    }
                    else
                    {
                        cont = 0;
                        for (int i = 1; i <= WifiModulations.Length; i++)
                        {
                            if (cBModulations[i].IsChecked == false)
                            {
                                cont++;
                            }
                        }
                        if (cont == WifiModulations.Length)
                        {
                            cBModulations[0].IsChecked = false;
                        }
                        else
                        {
                            cBModulations[0].IsChecked = null;
                        }
                    }
                }
            }
        }

        private void TsItem_Click(object sender, RoutedEventArgs e)
        {
            ChangeContentLv();
        }

        private void ChangeContentLv()
        {
            LvWifiModulation.Items.Clear();
            if (TsItems.IsOn)
            {
                cBItems[0].Content = "Selecionar Todos";
                cBItems[0].IsThreeState = true;
                LvWifiModulation.Items.Add(cBItems[0]);
                for (int i = 0; i < Items.Count(); i++)
                {
                    cBItems[i + 1].Content = Items[i].ToString();
                    cBItems[i + 1].Margin = new Thickness(24, 0, 0, 0);
                    LvWifiModulation.Items.Add(cBItems[i + 1]);
                }
            }
            else
            {
                cBModulations[0].Content = "Selecionar Todos";
                cBModulations[0].IsThreeState = true;
                LvWifiModulation.Items.Add(cBModulations[0]);
                for (int i = 0; i < WifiModulations.Length; i++)
                {
                    cBModulations[i + 1].Content = WifiModulations[i].ToString();
                    cBModulations[i + 1].Margin = new Thickness(24, 0, 0, 0);
                    LvWifiModulation.Items.Add(cBModulations[i + 1]);

                }
            }
        }

    }
}
