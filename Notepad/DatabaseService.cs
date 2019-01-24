using System;
using System.Collections.Generic;
using System.IO;
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
    class DatabaseService
    {
        SQLiteConnection db;

        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db.db3");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Note>();

            var table = db.Table<Note>();
            Note patientZero = new Note()
            {
                Content = "ebola"
            };
            if (!table.Contains(patientZero))
                db.Insert(patientZero);
            db.Delete(patientZero);
        }

        public void AddNote(Note note)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db.db3");
            SQLiteConnection db = new SQLiteConnection(dbPath);
            db.Insert(note);
        }

        public void SaveNote(Note note)
        {
            db.Update(note);
        }

        public void DeleteNote(Note note)
        {
            db.Delete(note);
        }

        public List<Note> GetAllNotes()
        {
            var table = db.Table<Note>();
            return table.ToList();
        }
    }
}