using System;
using System.Data;
using System.IO;
using SQLite;

namespace App1
{
    public class DBRepository
    {
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
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
                var db = new SQLiteConnection(dbPath);

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

        //code to retrieve specific record using ORM
        public string GetTaskById(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);

            var item = db.Get<ToDoTask>(id);
            return item.Task;
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



