using System.Data.Common;
using System.Dynamic;
using System.Transactions;
using Dapper;
using Updog.Application;
using Updog.Domain;

namespace Updog.Persistance {
    public class DapperRepo { }

    /// <summary>
    /// Base class for repos to inherit if they work off the database.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity.</typeparam>
    public abstract class DapperRepo<TEntity> : DatabaseRepo where TEntity : IEntity {
        #region Constructor(s)
        /// <summary>
        /// Create a new database based repo.
        /// </summary>
        /// <param name="database">The database to work with.</param>
        public DapperRepo(DatabaseContext context) : base(context) { }
        #endregion

        #region Privates
        /// <summary>
        /// Generate the SQL query param object for pagination.
        /// </summary>
        /// <param name="pageNumber">The page index (0 based).</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <returns>The dynamic object with the params.</returns>
        protected object BuildPaginationParams(int pageNumber, int pageSize) {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Offset", pageSize * pageNumber);
            p.Add("@Limit", pageSize);

            return p;
        }

        /// <summary>
        /// Generate the SQL query param object for pagination with base properties.
        /// </summary>
        /// <param name="p">The base object to work with.</param>
        /// <param name="pageNumber">The page index (0 based).</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <returns>The dynamic object with the params.</returns>
        protected object BuildPaginationParams(dynamic p, int pageNumber, int pageSize) {
            DynamicParameters pars = new DynamicParameters(p);
            pars.Add("@Offset", pageSize * pageNumber);
            pars.Add("@Limit", pageSize);

            return pars;
        }
        #endregion
    }
}