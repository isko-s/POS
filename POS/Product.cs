using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsPdc
{
    public class Product { 
       public static List<Product> _products = new();

            public string _sifra = string.Empty;
        public string _naziv = string.Empty;

        public int _kolicina;

        public decimal _ulazna;
        public int _marzaProc;

        public decimal _izlazna;

        public int _porezProc;
        public decimal _izlaznaPorez;

        public string Stampaj()
        {
            return $"{_sifra} -- {_naziv} - {_kolicina} - {_ulazna} - " +
                $"{_marzaProc}% - {_porezProc}% - {_izlazna} - {_izlaznaPorez}";
        }

        public string ZaFajl()
        {
            return $"{_sifra}|{_naziv}|{_kolicina}|{_ulazna}|" +
                $"{_marzaProc}|{_porezProc}|{_izlazna}|{_izlaznaPorez}" +
                Environment.NewLine;
        }


    }
}
