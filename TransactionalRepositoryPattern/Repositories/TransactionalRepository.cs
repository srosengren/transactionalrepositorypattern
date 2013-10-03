using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionalRepositoryPattern.Interfaces.Repositories;

namespace TransactionalRepositoryPattern.Repositories
{
    public abstract class TransactionalRepository : ITransactionalRepository
    {
        private SqlConnection _con;
        private SqlTransaction _trans;
        protected SqlConnection Con
        {
            get
            {
                if (_con == null)
                {
                    _con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
                    _con.Open();
                }
                return _con;
            }
        }
        protected SqlTransaction Trans
        {
            get
            {
                if (_trans == null)
                    _trans = Con.BeginTransaction();
                return _trans;
            }
        }

        /// <summary>
        /// Executes an action, this action is supposed to contain other calls on the actual repository (TransactionalRepository is abstract)
        /// these calls will be performed on a single transaction and commited when the action has been invoked, or rollbacked if an exception
        /// is thrown.
        /// </summary>
        /// <param name="a"></param>
        public void ExecuteInTransaction(Action a)
        {
            try
            {
                a.Invoke();
                Trans.Commit();
                Trans.Dispose();
                _trans = null;
            }
            catch
            {
                Trans.Rollback();
                Trans.Dispose();
                _trans = null;
                throw;
            }
        }

        public void Dispose()
        {
            if (_trans != null)
                _trans.Dispose();
            if (_con != null)
            {
                _con.Close();
                _con.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}
