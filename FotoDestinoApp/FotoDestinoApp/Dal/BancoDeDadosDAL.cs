using FotoDestinoApp.Infra;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoDestinoApp.Dal
{
    public class BancoDeDadosDAL
    {
        SQLiteConnection sqlConnection;

        public BancoDeDadosDAL()
        {
            sqlConnection = Xamarin.Forms.DependencyService.Get<IBancoDeDados>().DbConnection();
        }

        public SQLiteConnection GetConexao()
        {
            return sqlConnection;
        }

        public void CriarTabelas()
        {

            try
            {
                var command = sqlConnection.CreateCommand(TabelaMBFoto());
                command.ExecuteNonQuery();

                command = sqlConnection.CreateCommand(TabelaMBHistoricoComparacao());
                command.ExecuteNonQuery();
               
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch (Exception ex)
            {
                var mensagemErro = ex.Message;
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

        }


        private string TabelaMBFoto()
        {
            string comando = "";

            comando = "CREATE TABLE IF NOT EXISTS MBFoto( " +
                "idFoto INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                "pathFoto varchar (10) not null," +
                "latitude REAL not null," +
                "longitude REAL not null);";

            return comando;
        }

        


        private string TabelaMBHistoricoComparacao()
        {

            string comando = "";

            comando = "CREATE TABLE IF NOT EXISTS MBHistoricoComparacao( " +
                "idHistorico INTEGER primary key not null ," +
                "codigoFoto1 INTEGER not null," +
                "codigoFoto2 INTEGER not null," +
                "foreign key(codigoFoto1) references MBFoto(idFoto)" +
                "foreign key(codigoFoto2) references MBFoto(idFoto));";

            return comando;

        }
    }
}
