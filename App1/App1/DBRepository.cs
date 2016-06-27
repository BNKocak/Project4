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
                db.CreateTable<ToDoTask>();
                string result = "Table Created successfully..";
                return result;     
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        // Code to insert record
        public string InsertRecord(string task)
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
                var db = new SQLiteConnection(dbPath);

                ToDoTask item = new ToDoTask();
                item.Task = task;
                db.Insert(item);
                return "Record Added...";
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
            var table = db.Table<ToDoTask>();
            foreach (var item in table)
            {
                output += "\n" + item.Id + " --- " + item.Task;
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



