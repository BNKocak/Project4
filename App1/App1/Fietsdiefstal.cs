using System;
using System.Data;
using System.IO;
using SQLite;

namespace App1
{
    class Fietsdiefstal
    {
        [Column("VNr")]
        public string VNr { get; set; }

        [Column("Kennisname")]
        public string Kennisname { get; set; }

        [Column("MK")]
        public string MK { get; set; }

        [Column("MKOmschrijving")]
        public string MKOmschrijving { get; set; }

        [Column("Poging")]
        public string Poging { get; set; }

        [Column("District")]
        public string District { get; set; }

        [Column("Werkgebied")]
        public string Werkgebied { get; set; }

        [Column("Plaats")]
        public string Plaats { get; set; }

        [Column("Buurt")]
        public string Buurt { get; set; }

        [Column("Straat")]
        public string Straat { get; set; }

        [Column("BeginDagsoort")]
        public string BeginDagsoort { get; set; }

        [Column("BeginDatum")]
        public string BeginDatum { get; set; }

        [Column("BeginTijd")]
        public string BeginTijd { get; set; }

        [Column("EindDagsoort")]
        public string EindDagsoort { get; set; }

        [Column("EindDatum")]
        public string EindDatum { get; set; }

        [Column("EindTijd")]
        public string EindTijd { get; set; }

        [Column("GemJaar")]
        public string GemJaar { get; set; }

        [Column("GemMaand")]
        public string GemMaand { get; set; }

        [Column("GemDagsoort")]
        public string GemDagsoort { get; set; }

        [Column("GemDagsoortUren")]
        public string GemDagsoortUren { get; set; }

        [Column("Trefwoord")]
        public string Trefwoord { get; set; }

        [Column("Object")]
        public string Object { get; set; }

        [Column("Merk")]
        public string Merk { get; set; }

        [Column("Type")]
        public string Type { get; set; }

        [Column("Kleur")]
        public string Kleur { get; set; }


    }
}