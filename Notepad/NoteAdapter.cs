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

namespace Notepad
{
    class NoteAdapter : BaseAdapter<Note>
    {
        List<Note> items;
        Activity context;
        DatabaseService databaseService;

        public NoteAdapter(Activity context, List<Note> items, DatabaseService databaseService) : base()
        {
            this.context = context;
            this.items = items;
            this.databaseService = databaseService;
        }

        public override Note this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }

            var item = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            item.Text = items[position].Content;
            view.Tag = position;
            view.Click += Item_Click;

            return view;
        }

        private void Item_Click(object sender, EventArgs e)
        {
            var position = (int)((View)sender).Tag;

            Intent intent = new Intent(context, typeof(NoteActivity));
            intent.PutExtra("note", JsonConvert.SerializeObject(items[position]));
            NotifyDataSetChanged();
            context.StartActivity(intent);
        }
    }
}