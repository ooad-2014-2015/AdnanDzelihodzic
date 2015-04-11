using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Uposlenik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pozicija { get; set; }
        public string Kartica { get; set; }
        public virtual ICollection<Dogadjaj> Dogadjaji { get; set; }
    }

    public class Dogadjaj
    {
        public int Id {get;set;}
        public DateTime DatumVrijemeDogadjaja {get;set;}
        public int UposlenikId { get; set; }
        public virtual Uposlenik Uposlenik { get; set; }
    }
}
