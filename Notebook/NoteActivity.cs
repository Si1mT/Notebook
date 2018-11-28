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
    [Activity(Label = "NoteActivity")]
    public class NoteActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.note_layout);

            Note Note = JsonConvert.DeserializeObject<Note>(Intent.GetStringExtra("note"));
            TextView Notetext = FindViewById<TextView>(Resource.Id.textInputEditText_content);
            Notetext.Text = Note.Content;

            Button deleteNote = FindViewById<Button>(Resource.Id.button_delete);
            Button saveNote = FindViewById<Button>(Resource.Id.button_save);

            DatabaseService databaseService = new DatabaseService();
            databaseService.CreateDatabase();

            deleteNote.Click += delegate
            {
                databaseService.DeleteNote(Note);
                Finish();
                //notes = databaseService.GetAllNotes();
                //noteList.Adapter = new NoteAdapter(this, notes.ToList());
            };
        }
    }
}