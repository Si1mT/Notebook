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
        Note note;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.note_layout);

            note = JsonConvert.DeserializeObject<Note>(Intent.GetStringExtra("note"));
            databaseService = new DatabaseService();
            databaseService.CreateDatabase();

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar1);
            SetActionBar(toolbar);
            ActionBar.Title = "Notes";

            var newContent = FindViewById<EditText>(Resource.Id.textInputEditText_content);

            newContent.Text = note.Content;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.note_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.TitleFormatted.ToString())
            {
                case "save":
                    var content = FindViewById<TextView>(Resource.Id.textInputEditText_content);
                    note.Content = content.Text;
                    databaseService.SaveNote(note);
                    Finish();
                    break;
                case "delete":
                    databaseService.DeleteNote(note);
                    Finish();
                    break;
            }
               
            return base.OnOptionsItemSelected(item);
        }
    }
}