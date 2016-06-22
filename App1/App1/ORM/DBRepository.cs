using System;
using System.Data;
using System.IO;
using SQLite;

namespace App1.ORM
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
    }
}



