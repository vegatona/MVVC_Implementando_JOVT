using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MVVC_Implementando_JOVT.Modelo;

namespace MVVC_Implementando_JOVT.VistaModelo
{
    public class VMpage2 : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public List<Musuarios> listausuarioa { get; set; }
        #endregion

        #region CONTRUCTOR
        public VMpage2(INavigation navigation)
        {
            Navigation = navigation;
            Mostrarusuarios();
        }
        #endregion

        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion

        #region PROCESOS
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public void Mostrarusuarios()
        {
            listausuarioa = new List<Musuarios>
            {
                new Musuarios
                {
                    Nombre="Frank",
                    Imagen="https://ibb.co/sp4ntQh"
                },
                new Musuarios
                {
                    Nombre="Juan",
                    Imagen="https://ibb.co/PjhP39T"
                },
                new Musuarios
                {
                    Nombre="Carlos",
                    Imagen="https://ibb.co/QX9ZqvC"
                },
            };
        }
        public async Task Alerta(Musuarios parametros)
        {
            await DisplayAlert("Titulo", parametros.Nombre, "Ok");
        }

        #endregion

        #region COMANDOS
        public ICommand Volvercommand => new Command(async () => await Volver());
        //public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        public ICommand Alertacommand => new Command<Musuarios>(async (p) => await Alerta(p));
        #endregion
    }
}
