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
    [Activity(Label = "NoteActivity")]
    public class NoteActivity : Activity
    {
        DatabaseService databaseService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (Resources.Configuration.Orientation == Android.Content.Res.Orientation.Landscape)
            {
                Finish();
            }
            SetContentView(Resource.Layout.note_activity);

            var noteId = Intent.Extras.GetInt("current_note_id", 0);

            var textView = FindViewById<TextView>(Resource.Id.textView1);
            textView.Text = DatabaseService.NotesList[noteId].Content;

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar1);
            SetActionBar(toolbar);
            ActionBar.Title = "Notes";
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.note_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var noteId = Intent.Extras.GetInt("current_note_id", 0);
            Note note = new Note();
            DatabaseService db = new DatabaseService();
            db.CreateDatabase();

            note=DatabaseService.NotesList[noteId];

            switch (item.TitleFormatted.ToString())
            {
                case "save":
                    db.SaveNote(note);
                    Finish();
                    break;
                case "delete":
                    db.DeleteNote(note);
                    Finish();
                    Recreate();
                    break;
            }
               
            return base.OnOptionsItemSelected(item);
        }
    }
}