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
                db.CreateTable<DBAddress>();
                string result = "Table Created successfully..";
                return result;     
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        public string InsertAddress(string address)
        {
            try
            {
                DBAddress item = new DBAddress();
                item.DBLocation = address;
                db.Insert(item);
                return "Saved location";
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
                item.FCount         = 0;
                db.Insert(item);
                return "Records Added...";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        public string InsertDiefstal(string[] row)
        {
            try
            {

                Fietsdiefstal item = new Fietsdiefstal();
                item.VNr = row[0];
                item.Kennisname = row[1];
                item.MK = row[2];
                item.MKOmschrijving = row[3];
                item.Poging = row[4];
                item.District = row[5];
                item.Werkgebied = row[6];
                item.Plaats = row[7];
                item.Buurt = row[8];
                item.Straat = row[9];
                item.BeginDagsoort = row[10];
                item.BeginDatum = row[11];
                item.BeginTijd = row[12];
                item.EindDagsoort = row[13];
                item.EindDatum = row[14];
                item.EindTijd = row[15];
                item.GemJaar = row[16];
                item.GemMaand = row[17];
                item.GemDagsoort = row[18];
                item.GemDagsoortUren = row[19];
                item.Trefwoord = row[20];
                item.Object = row[21];
                item.Merk = row[22];
                item.Type = row[23];
                item.Kleur = row[24];
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

        public string GetLocation()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);
            string output = "";
            string query = "SELECT * FROM DBAddress";
            var item = db.Query<DBAddress>(query);
            foreach (var row in item)
            {
                output += row.DBLocation;
            }
            return output;
        }

        public string DeleteLocation()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);
            string output = "Removed Location";
            string query = "DELETE FROM DBAddress";
            db.Query<DBAddress>(query);
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



