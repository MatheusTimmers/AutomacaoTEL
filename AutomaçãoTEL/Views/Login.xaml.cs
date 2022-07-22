using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using AutomaçãoTEL.UserFolder;



namespace AutomaçãoTEL.Views
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private void BtRegister_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegistrationAccount));
        }

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void BtLogin_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(TboxName.Text, TboxPassword.Password);
            if (!user.Login())
            {
                DisplayInvalidNameOrPassword();
                return;
            }
            LoginPerformed();
            user.LoadImage();
        }

        private async void DisplayInvalidNameOrPassword()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Nome ou senha inválidos",
                Content = "Verifique o nome ou a senha e tente novamente",
                CloseButtonText = "Ok"
            };
            _ = await noWifiDialog.ShowAsync();
        }

        private async void LoginPerformed()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Login Efetuado",
                CloseButtonText = "Ok"
            };
            _ = await noWifiDialog.ShowAsync();
        }

    }
}
