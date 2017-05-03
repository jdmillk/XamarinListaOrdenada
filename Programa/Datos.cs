using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Programa
{
    class Datos
    {
        public string nombre;
        public string apellido;
        public int telefono;
        public bool familiaNumerosa;

        public string getNombre()
        {
            return nombre;
        }

        public void setNombre(string valor)
        {
            nombre = valor;
        }

        public string getApellido()
        {
            return apellido;
        }

        public void setApellido(string valor)
        {
            apellido = valor;
        }
        public int getTelefono()
        {
            return telefono;
        }

        public void setTelefono(int valor)
        {
            telefono = valor;
        }
        public bool isFamilia()
        {
            return familiaNumerosa;
        }

        public void setFamilia(bool valor)
        {
            familiaNumerosa = valor;
        }
    }
}