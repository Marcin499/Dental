﻿using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class BrakZebow
    {
        [Key]
        public int ZabID { get; set; }

        public string Kategoria { get; set; }

        public string GD { get; set; }

        public string LP { get; set; }

        public int Zab { get; set; }

        public int PacjentID { get; set; }
    }
}
