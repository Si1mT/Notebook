using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;

namespace Notepad
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", Icon ="@drawable/app_icon")]
    public class MainActivity : Activity
    {
        DatabaseService db=new DatabaseService();
        EditText editText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_activity);

            AppCenter.Start("3866317d-4cee-4f6e-ad03-a5e364eb47d9", typeof(Analytics), typeof(Crashes),typeof(Distribute));

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar1);
            SetActionBar(toolbar);
            ActionBar.Title = "Notes";

            editText = FindViewById<EditText>(Resource.Id.textInputEditText1);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.note_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Note note = new Note();
            
            DatabaseService db = new DatabaseService();

            switch (item.TitleFormatted.ToString())
            {
                case "add":
                    Note newNote = new Note();
                    newNote.Content = "new note";
                    db.AddNote(newNote);
                    break;
                case "save":
                    note.Id = DatabaseService.NotesList[NoteFragment.StatNoteId].Id;
                    note.Content = NoteFragment.editText.Text;
                    db.SaveNote(note);
                    break;
                case "delete":
                    db.DeleteNote(note);
                    break;
            }

            this.Recreate();

            return base.OnOptionsItemSelected(item);
        }
    }
}