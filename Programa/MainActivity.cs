using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;
using static Android.Resource;
using System.Linq;

namespace Programa
{
    [Activity(Label = "Programa", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        List<Datos> SortedList;
        AdaptadorPersonalizado adaptador;
        ListView lvDatos;
        Button btInsertar;
        EditText etNombre;
        EditText etApellido;
        EditText etTelefono;
        CheckBox cbFam;
        string errores = "";
        int posicion = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            etNombre = FindViewById<EditText>(Resource.Id.etNombre);
            etApellido = FindViewById<EditText>(Resource.Id.etApellido);
            etTelefono = FindViewById<EditText>(Resource.Id.etTelefono);
            cbFam = FindViewById<CheckBox>(Resource.Id.cbFamNu);
            btInsertar = FindViewById<Button>(Resource.Id.btInsertar);
            lvDatos = FindViewById<ListView>(Resource.Id.lvDatos);
            SortedList = new List<Datos>();
            Button btOrdenar = FindViewById<Button>(Resource.Id.btOrdenar);
            
            enviarAdaptador();
            btInsertar.Click += delegate
            {
                
                Datos d = new Datos();

                if(etNombre.Text.Equals(""))
                {
                    errores += "nombre "; 
                }
                if (etApellido.Text.Equals(""))
                {
                    errores += "apellido ";
                }
                if (etTelefono.Text.Equals("") || etTelefono.Text.Length != 9)
                {
                    errores += "numero de telefono ";
                }
                

                if (errores.Equals(""))
                {
                    d.setNombre(etNombre.Text);
                    d.setApellido(etApellido.Text);
                    d.setTelefono(int.Parse(etTelefono.Text));
                    d.setFamilia(cbFam.Checked);

                    SortedList.Add(d);
                    burbuja();
                    actualizarLista();
                }
                else
                {
                    Toast.MakeText(this, errores + "erróneo", ToastLength.Long).Show();
                    errores = "";
                }

            };

            btOrdenar.Click += delegate
            {
               
                SortedList = SortedList.OrderBy(o => o.nombre).ToList();
                enviarAdaptador();
                actualizarLista();
                
            };

            lvDatos.ItemLongClick += LvDatos_ItemLongClick;
            
                
        }

        private void burbuja()
        {
            string aux = "";
            for(int i=0; i< SortedList.Count; i++)
            {
                System.Console.WriteLine(SortedList[i].nombre);
            }

            for(int i = 0; i < SortedList.Count - 1; i++)
            {
                System.Console.WriteLine(SortedList.Count-1);
                for (int j=0;j<SortedList.Count -i - 1; j++)
                {
                    System.Console.WriteLine(SortedList.Count -i-1);
                    if (SortedList[j+1].nombre.CompareTo(SortedList[j].nombre) <= 0)
                    {
                        aux = SortedList[j + 1].nombre;
                        SortedList[j + 1].nombre = SortedList[j].nombre;
                        SortedList[j].nombre = aux; 
                    }
                }
            }

            for(int i=0; i < SortedList.Count; i++)
            {
                System.Console.WriteLine(SortedList[i].nombre);
            }
        }

        private void burbujaApellido()
        {
            string aux = "";
            for (int i = 0; i < SortedList.Count - 1; i++)
            {
                System.Console.WriteLine(SortedList.Count - 1);
                for (int j = 0; j < SortedList.Count - i - 1; j++)
                {
                    System.Console.WriteLine(SortedList.Count - i - 1);
                    if (SortedList[j + 1].apellido.CompareTo(SortedList[j].apellido) <= 0)
                    {
                        aux = SortedList[j + 1].apellido;
                        SortedList[j + 1].apellido = SortedList[j].apellido;
                        SortedList[j].apellido = aux;
                    }
                }
            }
        }

        private void LvDatos_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            PopupMenu menu = new PopupMenu(this, lvDatos);
            menu.Inflate(Resource.Menu.menu_context);
            posicion = e.Position;
            menu.Show();

            menu.MenuItemClick += Menu_MenuItemClick;
        }

        private void Menu_MenuItemClick(object sender, PopupMenu.MenuItemClickEventArgs e)
        {
            switch (e.Item.ItemId)
            {
                case Resource.Id.iModificar:
                    Datos d = new Datos();

                    if (etNombre.Text.Equals(""))
                    {
                        errores += "nombre ";
                    }
                    if (etApellido.Text.Equals(""))
                    {
                        errores += "apellido ";
                    }
                    if (etTelefono.Text.Equals("") || etTelefono.Text.Length != 9)
                    {
                        errores += "numero de telefono ";
                    }


                    if (errores.Equals(""))
                    {
                        d.setNombre(etNombre.Text);
                        d.setApellido(etApellido.Text);
                        d.setTelefono(int.Parse(etTelefono.Text));
                        d.setFamilia(cbFam.Checked);

                        SortedList.Add(d);
                        SortedList[posicion] = SortedList[SortedList.Count - 1];
                        SortedList.RemoveAt(SortedList.Count - 1);
                        enviarAdaptador();


                        actualizarLista();
                    }
                    else
                    {
                        Toast.MakeText(this, errores + "erróneo", ToastLength.Long).Show();
                        errores = "";
                    }
                   
                    break;
                case Resource.Id.iEliminar:
                   
                    SortedList.RemoveAt(posicion);
                    actualizarLista();
                    break;
                default:
                    break;
            }
        }

        private void enviarAdaptador()
        {
            adaptador = new AdaptadorPersonalizado(this, SortedList);
            lvDatos.Adapter = adaptador;
        }

        private void actualizarLista()
        {
            adaptador.NotifyDataSetChanged();
        }
    }
}

