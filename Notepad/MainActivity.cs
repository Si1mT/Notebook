using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;

namespace Notepad
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        DatabaseService databaseService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_activity);

            var NotesListView = FindViewById<ListView>(Resource.Id.listView1);
            var addButton = FindViewById<Button>(Resource.Id.button_addNote);

            databaseService = new DatabaseService();
            databaseService.CreateDatabase();
            List<Note> notes = databaseService.GetAllNotes();
            
            addButton.Click += Button_Click;
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            Note note = new Note();
            note.Content ="new note";
            databaseService.AddNote(note);

            List<Note> notes = databaseService.GetAllNotes();

            var listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = new NoteAdapter(this, notes, databaseService);
        }

        protected override void OnStart()
        {
            base.OnStart();

            List<Note> notes = databaseService.GetAllNotes();

            var notesListView = FindViewById<ListView>(Resource.Id.listView1);
            notesListView.Adapter = new NoteAdapter(this, notes, databaseService);
        }
    }
}