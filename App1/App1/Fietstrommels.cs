using System;
using System.Data;
using System.IO;
using SQLite;

namespace App1
{
    class Fietstrommels
    {
        [Column("InvNr")]
        public string InvNr { get; set; }

        [Column("InvSrt")]
        public string InvSrt { get; set; }

        [Column("Omschrijving")]
        public string Omschrijving { get; set; }

        [Column("Straat")]
        public string Straat { get; set; }

        [Column("Thv")]
        public string Thv { get; set; }

        [Column("XCoord")]
        public float XCoord { get; set; }

        [Column("YCoord")]
        public float YCoord { get; set; }

        [Column("Deelgemeente")]
        public string Deelgemeente { get; set; }

        [Column("Status")]
        public string Status { get; set; }

        [Column("MutDatum")]
        public string MutDatum { get; set; }

        [Column("User")]
        public string User { get; set; }
    }
}