using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoDestinoApp.Model
{
    public class MBHistoricoComparacao
    {
        [PrimaryKey, AutoIncrement]
        public Int32 idHistorico { get; set; }

        [ForeignKey(typeof(MBFoto)), NotNull]
        public Int16 codigoFoto1 { get; set; }

        [ForeignKey(typeof(MBFoto)), NotNull]
        public Int16 codigoFoto2 { get; set; }

    }
}
