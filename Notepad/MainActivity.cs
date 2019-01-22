using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Views;

namespace Notepad
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        DatabaseService databaseService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_activity);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar1);
            SetActionBar(toolbar);
            ActionBar.Title = "Notes";

            var NotesListView = FindViewById<ListView>(Resource.Id.listView1);

            databaseService = new DatabaseService();
            databaseService.CreateDatabase();
            List<Note> notes = databaseService.GetAllNotes();
        }

        protected override void OnStart()
        {
            base.OnStart();

            List<Note> notes = databaseService.GetAllNotes();

            var notesListView = FindViewById<ListView>(Resource.Id.listView1);
            notesListView.Adapter = new NoteAdapter(this, notes, databaseService);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Note note = new Note();
            note.Content = "new note";
            databaseService.AddNote(note);

            List<Note> notes = databaseService.GetAllNotes();

            var listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = new NoteAdapter(this, notes, databaseService);
            return base.OnOptionsItemSelected(item);
        }
    }
}