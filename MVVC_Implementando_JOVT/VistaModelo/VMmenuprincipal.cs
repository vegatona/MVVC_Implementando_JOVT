using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MVVC_Implementando_JOVT.Modelo;
using MVVC_Implementando_JOVT.Vista;

namespace MVVC_Implementando_JOVT.VistaModelo
{
    public class VMmenuprincipal : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public List<Mmenuprincipal> listapagina { get; set; }
        #endregion

        #region CONTRUCTOR
        public VMmenuprincipal(INavigation navigation)
        {
            Navigation = navigation;
            MostrarPagina();
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
        public void MostrarPagina()
        {
            listapagina = new List<Mmenuprincipal>
            {
                new Mmenuprincipal
                {
                    Pagina="Entry, datepicker, picker, label, navegation",
                    Icono="https://ibb.co/sp4ntQh"
                },
                new Mmenuprincipal
                {
                    Pagina="CollectionView sin enlace a base de datos",
                    Icono="https://ibb.co/PjhP39T"
                },
                new Mmenuprincipal
                {
                    Pagina="Crud pokemon",
                    Icono="https://ibb.co/QX9ZqvC"
                },
            };
        }
        public async Task Navegar(Mmenuprincipal parametros)
        {
            string pagina;
            pagina = parametros.Pagina;
            if (pagina.Contains("Entry, datepicker"))
            {
                await Navigation.PushAsync(new Pagina1());
            }
            if (pagina.Contains("CollectionView sin enlace"))
            {
                await Navigation.PushAsync(new Page2());
            }
            if (pagina.Contains("Crud Pokemon"))
            {
                await Navigation.PushAsync(new Crudpokemon());
            }
        }

        #endregion

        #region COMANDOS
        //public ICommand Volvercommand => new Command(async () => await Volver());
        //public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        public ICommand Navegarcommand => new Command<Mmenuprincipal>(async (p) => await Navegar(p));
        #endregion
    }
}