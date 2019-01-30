﻿using System;
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
    public class NoteFragment : Fragment
    {
        DatabaseService DatabaseService;
        public int NoteId => Arguments.GetInt("current_note_id", 0);

        public static NoteFragment NewInstance(int noteId)
        {
            var bundle = new Bundle();
            bundle.PutInt("current_note_id", noteId);
            return new NoteFragment { Arguments = bundle };
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                return null;
            }

            //var editText = new EditText(Activity);
            var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
            //editText.SetPadding(padding, padding, padding, padding);
            //editText.TextSize = 24;
            //editText.Text = DatabaseService.GetAllNotes().ElementAt(Id).Content[NoteId].ToString();

            var scroller = new ScrollView(Activity);
            //scroller.AddView(editText);

            return scroller;
        }
    }
}