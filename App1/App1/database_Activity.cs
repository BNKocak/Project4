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
    [Activity(Label = "Database")]
    public class database_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Database);

            //create the database
            Button btnCreateDB = FindViewById<Button>(Resource.Id.btnCreateDB);
            btnCreateDB.Click += btnCreateDB_Click;

            // create table
            Button btnCreateTable = FindViewById<Button>(Resource.Id.btnCreateTable);
            btnCreateTable.Click += btnCreateTable_Click;

            // To Insert the record
            Button btnAddRecord = FindViewById<Button>(Resource.Id.btnInstert);
            btnAddRecord.Click += btnAddRecord_Click;

            // to retrieve the data
            Button btnGetAll = FindViewById<Button>(Resource.Id.btnGetData);
            btnGetAll.Click += btnGetAll_Click;

            // to retrieve specifick record
            Button btnGetById = FindViewById<Button>(Resource.Id.btnGetDataByID);
            btnGetById.Click += btnGetById_Click;

            // To Update record
            Button btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            btnUpdate.Click += btnUpdate_Click;

            // to delete record
            Button btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            btnDelete.Click += btnDelete_Click;
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(RemoveTask_Activity));
        }

        void btnUpdate_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(UpdateTask_Activity));
        }

        void btnGetById_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Search_Activity));
        }

        void btnGetAll_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.GetAllRecords();
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        void btnAddRecord_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(InsertTask_Activity));
        }

        void btnCreateTable_Click(Object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.CreateTable();
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        void btnCreateDB_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.CreateDB();
            Toast.MakeText(this, result, ToastLength.Short).Show();

        }
    }
}