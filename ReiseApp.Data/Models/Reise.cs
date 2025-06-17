using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReiseApp.Data.Models
{
    public class Reise
    {

        public DateOnly Datum { get; set; }

        public string Ort { get; set; }
        public string Nachname { get; set; }

      
        public Reise(DateOnly datum, string ort, string nachname)
        {
            
            Nachname = nachname;
            Ort = ort;
            Datum = datum;
        }
    }
}
