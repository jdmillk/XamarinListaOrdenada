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
using static Android.Resource;


namespace Programa
{
    class AdaptadorPersonalizado : BaseAdapter<Datos>
    {
        private Context contexto;
        private List<Datos> listaDatos;
        private LayoutInflater inflater;

        public AdaptadorPersonalizado(Activity context, List<Datos> lista)
        {
            this.contexto = context;
            this.listaDatos = lista;
            inflater = LayoutInflater.From(context);
        }

        public override Datos this[int position] => listaDatos.ElementAt(position);

        public override int Count => listaDatos.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var item = this.listaDatos[position];
            var view = convertView;

            if (convertView == null || !(convertView is LinearLayout))
                view = inflater.Inflate(Resource.Layout.AdaptPerso, parent, false);

            TextView tvNombre = view.FindViewById(Resource.Id.tvNombre) as TextView;
            TextView tvApellido = view.FindViewById(Resource.Id.tvApellido) as TextView;
            TextView tvTelefono = view.FindViewById(Resource.Id.tvTelefono) as TextView;
            TextView tvFamilia = view.FindViewById(Resource.Id.tvFamilia) as TextView;
            tvNombre.SetText(item.getNombre(), TextView.BufferType.Normal);
            tvApellido.SetText(item.getApellido(), TextView.BufferType.Normal);
            tvTelefono.SetText(item.getTelefono().ToString(), TextView.BufferType.Normal);
            if (item.familiaNumerosa)
            {
                tvFamilia.SetText("Si", TextView.BufferType.Normal);
            }
            else
            {
                tvFamilia.SetText("No", TextView.BufferType.Normal);
            }
            return view;
        }

    }
}