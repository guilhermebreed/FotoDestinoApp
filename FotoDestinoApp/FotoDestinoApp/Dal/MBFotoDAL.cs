using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoDestinoApp.Model;

namespace FotoDestinoApp.Dal
{
    public class MBFotoDAL
    {

        private SQLiteConnection sqlConnection;
        public MBFotoDAL()
        {
            BancoDeDadosDAL BancoDeDadosDAL = new BancoDeDadosDAL();
            sqlConnection = BancoDeDadosDAL.GetConexao();

        }


        public IEnumerable<MBFoto> GetAll()
        {

            return (from t in sqlConnection.GetAllWithChildren<MBFoto>()
                    select t).OrderBy(i => i.idFoto).ToList();
            //return sqlConnection.GetAllWithChildren<MBFoto>().ToList();

        }
        public MBFoto GetItemById(int id)
        {

            return sqlConnection.GetAllWithChildren<MBFoto>().FirstOrDefault(t => t.idFoto == id);

        }

        public void DeleteAll()
        {
            try
            {
                var command = sqlConnection.
                    CreateCommand("Delete FROM MBFoto");
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                var mensagemErro = ex.Message;
            }

        }

        public void DeleteById(int id)
        {
            try
            {
                sqlConnection.Delete<MBFoto>(id);
            }
            catch (Exception ex)
            {
                var mensagemErro = ex.Message;
            }

        }
        public void Add(MBFoto mbFoto)
        {
            try
            {
                sqlConnection.Insert(mbFoto);

            }
            catch (Exception ex)
            {
                var mensagemErro = ex.Message;
            }

        }
        public void Update(MBFoto mbFoto)
        {
            try
            {
                sqlConnection.Update(mbFoto);
            }
            catch (Exception ex)
            {
                var mensagemErro = ex.Message;
            }

        }
    }
}
