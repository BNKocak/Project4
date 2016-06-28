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
using System.IO;

namespace App1
{
    [Activity(Label = "Database")]
    public class database_Activity : Activity
    {
        List<string[]> ReadandParseData(string path, char seperator)
        {
            var parsedData = new List<string[]>();
            string[] test = File.ReadAllLines(path);
            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] row = line.Split(seperator);
                    parsedData.Add(row);
                }
            }
            return parsedData;
        }

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
            DBRepository dbr = new DBRepository();
            var result = dbr.GetVraag1();
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }
        void btnGetAll_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.GetAllRecords();
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        static void ExploreDirectories(string root)
        {
            var directories = Directory.GetDirectories(root);
            if (directories.Count() == 0)
                return;
            foreach(var d in directories)
            {
                ExploreDirectories(d);
            }
        }
        void btnAddRecord_Click(object sender, EventArgs e)
        {
            //StartActivity(typeof(InsertTask_Activity));
            DBRepository dbr = new DBRepository();
            //string csvdir = System.Environment.CurrentDirectory;
            //ExploreDirectories("/storage/extSdCard");
            string csvpath = Path.Combine("/storage/extSdCard", "Fietstrommels.csv");
            //var x = Directory.GetDirectories(csvdir);
            //string[] test = File.ReadAllLines(csvpath);
            //string[] files = Directory.GetFiles(csvdir);
            //File.Copy("Fietstrommels.csv", csvpath);
            List<string[]> parsedData = ReadandParseData(csvpath, ',');
            int cnt = 0;
            foreach (string[] row in parsedData)
            {
                cnt++;
                string result = dbr.InsertRecord(row);
            }
            Toast.MakeText(this, "Amount of records : " + cnt.ToString(), ToastLength.Short).Show();
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