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
    [Activity(Label = "UpdateTask_Activity")]
    public class UpdateTask_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.UpdateTaskLayout);
            // Search button click
            Button btnSearch = FindViewById<Button>(Resource.Id.btnSearch);
            btnSearch.Click += btnSearch_Click;

            //Update button click
            Button btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            btnUpdate.Click += btnUpdate_Click;
        }

        void btnUpdate_Click(object sender, EventArgs e)
        {
            EditText txtId = FindViewById<EditText>(Resource.Id.txtTaskId);
            EditText txtTask = FindViewById<EditText>(Resource.Id.txtTask);
            DBRepository dbr = new DBRepository();
            string result = dbr.updateRecord(int.Parse(txtId.Text), txtTask.Text);
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            EditText txtId = FindViewById<EditText>(Resource.Id.txtTaskId);
            EditText txtTask = FindViewById<EditText>(Resource.Id.txtTask);
            txtTask.Text = dbr.GetTaskById(int.Parse(txtId.Text));
        }
    }
}