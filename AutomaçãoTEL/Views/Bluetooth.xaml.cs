using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
        readonly CheckBox[] cBModulations = new CheckBox[4] { new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox() };
        readonly CheckBox[] cBItems = new CheckBox[8] { new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox() };


        public Bluetooth()
        {
            this.InitializeComponent();
            cBModulations[0].Checked += SelectAll_Checked;
            cBItems[0].Checked += SelectAll_Checked;
            cBModulations[0].Unchecked += SelectAll_Unchecked;
            cBItems[0].Unchecked += SelectAll_Unchecked;
            cBModulations[0].Indeterminate += SelectAll_Indeterminate;
            cBItems[0].Indeterminate += SelectAll_Indeterminate;
            for (int i = 1; i < BtModulations.Length; i++)
            {
                cBModulations[i].Checked += Option_Checked;
                cBItems[i].Checked += Option_Checked;
                cBModulations[i].Unchecked += Option_Unchecked;
                cBItems[i].Unchecked += Option_Unchecked;

            }
            ChangeContentLv();
        }

        private void SelectAll_Checked(object sender, RoutedEventArgs e)
        {
            if (!TsItem10.IsOn)
            {
                for (int i = 1; i <= BtModulations.Length; i++)
                {
                    cBModulations[i].IsChecked = true;
                }
            }
            else
            {
                for (int i = 1; i <= Items.Length; i++)
                {
                    cBItems[i].IsChecked = true;
                }
                
            }
        }

        private void SelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!TsItem10.IsOn)
            {
                for (int i = 1; i <= cBModulations.Length; i++)
                {
                    cBModulations[i].IsChecked = false;
                }
            }
            else
            {
                for (int i = 1; i <= cBItems.Length; i++)
                {
                    cBItems[i].IsChecked = false;
                }
            }
                
        }

        private void SelectAll_Indeterminate(object sender, RoutedEventArgs e)
        {
            int cont = 0;
            if (!TsItem10.IsOn)
            { 
                for (int i = 1; i <= BtModulations.Length; i++)
                {
                    if (cBModulations[i].IsChecked == true)
                    {
                        cont++;
                    }
                }
                if (cont == 3)
                {
                    cBModulations[0].IsChecked = false;
                }
                
            }
            else
            {
                for (int i = 1; i <= Items.Length; i++)
                {
                    if (cBItems[i].IsChecked == true)
                    {
                        cont++;
                    }
                }
                if (cont == 7)
                {
                    cBItems[0].IsChecked = false;
                }
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
            if (!TsItem10.IsOn)
            {
                if (cBModulations[1] != null)
                {
                    for (int i = 1; i <= BtModulations.Length; i++)
                    {
                        if (cBModulations[i].IsChecked == true)
                        {
                            cont++;
                        }
                    }
                    if (cont == 3)
                    {
                        cBModulations[0].IsChecked = true;
                    }
                    else
                    {
                        for (int i = 1; i <= BtModulations.Length; i++)
                        {
                            if (cBModulations[i].IsChecked == false)
                            {
                                cont++;
                            }
                        }
                        if (cont == 3)
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
            else
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
                    if (cont == 7)
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
                        if (cont == 7)
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
            
        }

        private void TsItem10_Click(object sender, RoutedEventArgs e)
        {
            ChangeContentLv();
        }

        private void ChangeContentLv()
        {
            LvBtModulation.Items.Clear();
            if (!TsItem10.IsOn)
            {

                cBModulations[0].Content = "Selecionar Todos";
                cBModulations[0].IsThreeState = true;
                LvBtModulation.Items.Add(cBModulations[0]);
                for (int i = 0; i < BtModulations.Count(); i++)
                {
                    cBModulations[i + 1].Content = BtModulations[i].ToString();
                    cBModulations[i + 1].Margin = new Thickness(24, 0, 0, 0);
                    LvBtModulation.Items.Add(cBModulations[i + 1]);

                }
            }
            else
            {
                cBItems[0].Content = "Selecionar Todos";
                cBItems[0].IsThreeState = true;
                LvBtModulation.Items.Add(cBItems[0]);
                for (int i = 0; i < Items.Count(); i++)
                {
                    cBItems[i + 1].Content = Items[i].ToString();
                    cBItems[i + 1].Margin = new Thickness(24, 0, 0, 0);
                    LvBtModulation.Items.Add(cBItems[i + 1]);
                }
            }
        }

    }
}
