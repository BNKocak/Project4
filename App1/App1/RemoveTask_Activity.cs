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
    [Activity(Label = "RemoveTask_Activity")]
    public class RemoveTask_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RemoveTask_Layout);
            Button btnRemove = FindViewById<Button>(Resource.Id.btnDelete);
            btnRemove.Click += btnRemove_Click;
        }

        void btnRemove_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            EditText txtTaskId = FindViewById<EditText>(Resource.Id.txtTaskID);
            string result = dbr.RemoveTask(int.Parse(txtTaskId.Text));
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }
    }
}