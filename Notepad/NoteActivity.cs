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

            var content = FindViewById<TextView>(Resource.Id.textView_content);
            var buttonDelete = FindViewById<Button>(Resource.Id.button_delete);
            var buttonSave = FindViewById<Button>(Resource.Id.button_save);

            content.Text = note.Content;

            buttonDelete.Click += Delete_Click;
            buttonSave.Click += Save_Click;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var content = FindViewById<TextView>(Resource.Id.textInputEditText_content);

            note.Content = content.Text;
            databaseService.SaveNote(note);
            Finish();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            databaseService.DeleteNote(note);
            Finish();
        }
    }
}