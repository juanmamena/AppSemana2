using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppSemana2
{
    public partial class MainPage : ContentPage
    {
        private Double porcentajeSeguimiento = 0.3;
        private Double porcentajeExamen = 0.2;
        private Double notaSeguimiento = 0.0;
        private Double notaExamen = 0.0;


        public MainPage(string user)
        {
            InitializeComponent();
            lblUser.Text = user;
        }

        private Double calcularParcial(Double notaSeguimiento, Double notaExamen)
        {
            Double notaParcial = new Double();

            notaParcial = (notaSeguimiento * porcentajeSeguimiento) + (notaExamen * porcentajeExamen);

            return notaParcial;
        }

        private void validarNotas(Entry txtSeguimiento, Entry txtExamen, Label lblPromedio)
        {
            if ((txtSeguimiento.Text != "") && (txtSeguimiento.Text != null))
            {
                notaSeguimiento = Double.Parse(txtSeguimiento.Text);
            }
            if ((txtExamen.Text != "") && (txtExamen.Text != null))
            {
                notaExamen = Double.Parse(txtExamen.Text);
            }

            if (notaExamen > 10 || notaSeguimiento > 10)
            {
                txtSeguimiento.Text = "";
                txtExamen.Text = "";
                DisplayAlert("ERROR", "Las notas ingresadas NO pueden ser MAYORES que 10", "Cerrar");

            }
            else
            {
                lblPromedio.Text = calcularParcial(notaSeguimiento, notaExamen).ToString();
            }
        }


        void txtSeguimientoUno_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            validarNotas(txtSeguimientoUno, txtExamenUno, lblPromedioUno);
        }

        void txtExamenUno_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            validarNotas(txtSeguimientoUno, txtExamenUno, lblPromedioUno);
        }

        void txtSeguimientoDos_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            validarNotas(txtSeguimientoDos, txtExamenDos, lblPromedioDos);
        }

        void txtExamenDos_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            validarNotas(txtSeguimientoDos, txtExamenDos, lblPromedioDos);
        }

        void btnProcesar_Clicked(System.Object sender, System.EventArgs e)
        {
            Double notaFinal = 0.0;
            notaFinal = (Double.Parse(lblPromedioUno.Text) + Double.Parse(lblPromedioDos.Text));
            lblNotaFinal.Text = notaFinal.ToString();
            if (notaFinal >= 7.0)
            {
                lblEstado.Text = "APROBADO";
                lblEstado.TextColor = Xamarin.Forms.Color.Green;
            }
            else if (notaFinal >= 5.0 && notaFinal <= 6.9)
            {
                lblEstado.Text = "COMPLEMENTARIO";
                lblEstado.TextColor = Xamarin.Forms.Color.Orange;
            }
            else if (notaFinal < 5)
            {
                lblEstado.Text = "REPROBADO";
                lblEstado.TextColor = Xamarin.Forms.Color.Red;

            }

        }
    }
}
