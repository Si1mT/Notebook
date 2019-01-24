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
using SQLite;

namespace Notepad
{
    class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Content { get; set; }

        //public static string[] notesArray = { "lol" };
        //public List<string> notesList { get; set; }

        //public Note()
        //{
        //    var databaseService = new DatabaseService();
        //    databaseService.CreateDatabase();
        //    List<Note> notes = databaseService.GetAllNotes();
        //    foreach (var note in notes)
        //    {
        //        notesList.Add(note.Content);
        //    }
        //    notesArray = notesList.ToArray();
        //}
    }
}