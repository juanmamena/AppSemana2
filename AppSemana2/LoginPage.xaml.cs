using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AppSemana2
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void btnIngresar_Clicked(System.Object sender, System.EventArgs e)
        {
            if (txtUsuario.Text == "jumenam" && txtPassword.Text == "Pedro2021")
            {
                await Navigation.PushAsync(new MainPage(txtUsuario.Text));
            }
            else
            {
                await DisplayAlert("MENSAJE", "Usuario o Clave incorrecto", "ACEPTAR");
            }
        }
    }
}
