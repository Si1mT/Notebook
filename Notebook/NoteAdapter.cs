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
using Newtonsoft.Json;

namespace Notebook
{
    public class NoteAdapter : BaseAdapter<Note>
    {
        List<Note> items;
        Activity context;

        public NoteAdapter(Activity context, List<Note> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override int Count
        {
            get { return items.Count; }
        }

        //public override Java.Lang.Object GetItem(int position)
        //{
        //    return null; // could wrap a Contact in a Java.Lang.Object to return it here if needed
        //}
        public override Note this[int position]
        {
            get { return items[position]; }//Title might be content
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position].Content;
            view.Click -= View_Click;
            view.Click += View_Click;

            return view;
        }

        private void View_Click(object sender, EventArgs e)
        {
            var position = (int)((View)sender).Tag;

            Intent intent = new Intent(context, typeof(NoteActivity));
            intent.PutExtra("note", JsonConvert.SerializeObject(items[position]));
            context.StartActivity(intent);
            this.NotifyDataSetChanged();
        }
    }
}