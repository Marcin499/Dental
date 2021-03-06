﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    [Table("Wizyta")]
    public class Wizyta
    {
        [Key]
        public int WizytaID { get; set; }

        public int PacjentID { get; set; }

        public int GabinetID { get; set; }

        public int LekarzID { get; set; }

        public string Data { get; set; }

        public DateTime DataUrodzenia { get; set; }

        public string Godzina { get; set; }

        public string Typ { get; set; }

        public string Stan { get; set; }

        public string Rodzaj { get; set; }

        public int RachunekID { get; set; }

        public string Uwagi { get; set; }
    }
}
