using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Notepad
{
    public class NotesListFragment : ListFragment
    {
        //DatabaseService databaseService;
        int selectedNoteId;

        public NotesListFragment()
        {
            // Being explicit about the requirement for a default constructor.
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            //databaseService = new DatabaseService();
            //databaseService.CreateDatabase();
            //List<Note> notes = databaseService.GetAllNotes();
            //List<string> notesList = new List<string>();
            //foreach (var note in notes)
            //{
            //    notesList.Add(note.Content);
            //}

            base.OnActivityCreated(savedInstanceState);
            ListAdapter = new ArrayAdapter<String>(Activity, Android.Resource.Layout.SimpleListItemActivated1, Note.notesArray);

            if (savedInstanceState != null)
            {
                selectedNoteId = savedInstanceState.GetInt("current_note_id", 0);
            }
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt("current_note_id", selectedNoteId);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            ShowNote(position);
        }

        void ShowNote(int playId)
        {
            var intent = new Intent(Activity, typeof(NoteActivity));
            intent.PutExtra("current_note_id", playId);
            StartActivity(intent);
        }
    }
}