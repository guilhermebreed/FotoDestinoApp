using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoDestinoApp.Model
{
    public class MBFoto
    {
        [PrimaryKey, AutoIncrement]
        public Int16 idFoto { get; set; }
        
        [NotNull]
        public string pathFoto { get; set; }

        [NotNull]
        public double latitude { get; set; }

        [NotNull]
        public double longitude { get; set; }

        [OneToMany]
        public List<MBHistoricoComparacao> fotos1 { get; set; }

        [OneToMany]
        public List<MBHistoricoComparacao> fotos2 { get; set; }
    }
}
