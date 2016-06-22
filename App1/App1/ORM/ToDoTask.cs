using System;
using System.Data;
using System.IO;
using SQLite;

namespace App1
{
    [Table("ToDoTasks")]

    public class ToDoTask
    {
        [PrimaryKey,AutoIncrement,Column("_Id")]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Task { get; set; }
    }
}