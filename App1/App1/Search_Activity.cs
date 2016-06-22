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

namespace App1
{
    [Activity(Label = "Search_Activity")]
    public class Search_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SearchLayout);

            Button btnSearch = FindViewById<Button>(Resource.Id.btnSearch);
            btnSearch.Click += btnSearch_Click;
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            EditText txtId = FindViewById<EditText>(Resource.Id.txtTaskId);
            string task = dbr.GetTaskById(int.Parse(txtId.Text));
            Toast.MakeText(this, task, ToastLength.Short).Show();
        } 
    }
}