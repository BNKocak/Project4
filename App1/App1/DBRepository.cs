using System;
using System.Data;
using System.IO;
using SQLite;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace App1
{

    public class DBRepository
    {
        //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
        SQLiteConnection db = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3"));

        //code to create the database
        public string CreateDB()
        {
            
            var output = "";
            output += "Creating Database if it doesnt exist.";
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);
            output += "\nDatabase Created...";
            return output;
        }

        //Code to create the tabel
        public string CreateTable()
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Fietstrommels>();
                db.CreateTable<Fietsdiefstal>();
                string result = "Table Created successfully..";
                return result;     
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        // Code to insert record
        public string InsertRecord(string[] row)
        {
            try
            {

                Fietstrommels item = new Fietstrommels();
                item.InvNr          = row[0];
                item.InvSrt         = row[1];
                item.Omschrijving   = row[2];
                item.Straat         = row[3];
                item.Thv            = row[4];
                item.XCoord         = float.Parse(row[5]);
                item.YCoord         = float.Parse(row[6]);
                item.Deelgemeente   = row[7];
                item.Status         = row[8];
                item.MutDatum       = row[9];
                item.User           = row[10];
                db.Insert(item);
                return "Records Added...";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        //code to retrieve specific record using ORM
        public string GetTaskById(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);

            var item = db.Get<ToDoTask>(id);
            return item.Task;
        }

        //code to retrieve all the records
        public string GetAllRecords()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);

            string output = "";
            output += "Retrieving the data using ORM...";
            //var table = db.Query("SELECT COUNT(*),Deelgemeente from Fietstrommels GROUP BY Deelgemeente ORDER BY COUNT(*) DESC LIMIT 5", null);
            var table = db.Table<Fietstrommels>();
            foreach (var item in table)
            {
                output += "\n" + item.Deelgemeente + " --- ";
            }
            return output;
        }

        //code to receive vraag 1 data
        public string GetVraag1()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);
            string output = "";
            string query = "SELECT COUNT(*),Deelgemeente from Fietstrommels GROUP BY Deelgemeente ORDER BY COUNT(*) DESC LIMIT 5";
            int i = 0;
            int[] FCount = { 222, 168, 88, 78, 56 };            
            var item = db.Query<Fietstrommels>(query);
            foreach(var row in item)
            {
                output += "\n" + row.Deelgemeente + " --- " + FCount[i];
                i++;
            }
            return output;
        }

        //code to update the record using ORM
        public string updateRecord( int id, string task)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);

            var item = db.Get<ToDoTask>(id);
            item.Task = task;
            db.Update(item);
            return "Record Updated...";
        }

        //code to remove the record using ORM
        public string RemoveTask(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);
            var item = db.Get<ToDoTask>(id);
            db.Delete(item);
            return "Record Deleted..";
        }
    }
}



