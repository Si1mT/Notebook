using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;

namespace Notebook
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        DatabaseService databaseService = new DatabaseService();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            DatabaseService db = new DatabaseService();

            //var databaseService = new DatabaseService();
            //databaseService.CreateDatabase();
            databaseService.CreateDatabase();
            databaseService.CreateTableWithData();
            var notes = databaseService.GetAllNotes();

            ListView noteList = FindViewById<ListView>(Resource.Id.listView1);
            noteList.Adapter = new NoteAdapter(this,notes.ToList());

            Button addNote = FindViewById<Button>(Resource.Id.button_addNote);
            //addNote.Click += AddNoteClick;
            addNote.Click += delegate
            {
                databaseService.AddNote("New Note");

                notes = databaseService.GetAllNotes();
                noteList.Adapter = new NoteAdapter(this, notes.ToList());
            };

            //noteList.ItemClick += NotesListClick;
        }

        //private void NotesListClick(object sender, AdapterView.ItemClickEventArgs e)
        //{

        //    //    var commentActivity = new Intent(this, typeof(Comments));
        //    //    Value.Comments = new List<Comment>();
        //    //    Value.Comments.Add(All_Post[e.Position].Comment);

        //    //    StartActivity(commentActivity);
        //    var NoteActivity = new Intent(this, typeof(NoteActivity));
        //    databaseService.CreateDatabase();
        //    var AllNotes = databaseService.GetAllNotes().ToList();
        //    NoteActivity.PutExtra("note", AllNotes[e.Position].Content.ToString());
        //    StartActivity(NoteActivity);
        //}

        //public void AddNoteClick(object sender, EventArgs e)
        //{
        //    EditText noteTitle = FindViewById<EditText>(Resource.Id.textInputEditText_noteTitle);
        //    if (noteTitle.Text == "")
        //        noteTitle.Text = "New Note";
        //    db.AddNote(noteTitle.Text);
        //}
    }
}