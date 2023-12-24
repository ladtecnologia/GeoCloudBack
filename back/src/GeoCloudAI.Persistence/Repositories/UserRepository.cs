using Dapper;

using System.Transactions;
using GeoCloudAI.Domain.Classes;
using GeoCloudAI.Persistence.Data;
using GeoCloudAI.Persistence.Contracts;
using GeoCloudAI.Persistence.Models;

namespace GeoCloudAI.Persistence.Repositories
{
    public class UserRepository: IUserRepository
    {
        private DbSession _db;

        public UserRepository(DbSession dbSession)
        {
            _db = dbSession;
        }

        public async Task<int> Add(User user)
        {
            try
            {
                var conn = _db.Connection;
                using (TransactionScope scope = new TransactionScope())
                {
                    string command = @"INSERT INTO USER(firstName, lastName, email, company) 
                                            VALUES(@firstName, @lastName, @email, @company); " +
                                    "SELECT LAST_INSERT_ID();";
                    var result = conn.ExecuteScalar<int>(sql: command, param: user);
                    scope.Complete();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> Update(User user)
        {
            try
            {
                var conn = _db.Connection;
                string command = @"UPDATE USER SET 
                                    firstName   = @firstName,
                                    lastName    = @lastName,
                                    email       = @email,
                                    company     = @company
                                    WHERE ID    = @id";
                var result = await conn.ExecuteAsync(sql: command, param: user);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var conn = _db.Connection;
                string command = @"DELETE FROM USER WHERE id = @id";
                var resultado = await conn.ExecuteAsync(sql: command, param: new { id });
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<User>> Get(PageParams pageParams)
        {
            try
            {
                var conn = _db.Connection;
                var term         = pageParams.Term;
                var orderField   = pageParams.OrderField;
                var orderReverse = pageParams.OrderReverse;

                string query = "SELECT * FROM USER ";
                if (term != ""){
                    query = query + "WHERE firstName LIKE '%" + @term + "%' " +
                                    "OR    lastName  LIKE '%" + @term + "%' ";
                }
                
                query = query + "ORDER BY " + @orderField;
                if (orderReverse) {
                    query = query + " DESC ";
                }

                IEnumerable<User> users = (await conn.QueryAsync<User>(sql: query, param: new {})).ToArray();

                return await PageList<User>.CreateAsync(users, pageParams.PageNumber, pageParams.pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                var conn = _db.Connection;
                string query = "SELECT * FROM USER WHERE id = @id";
                User? user = await conn.QueryFirstOrDefaultAsync<User>(sql: query, param: new { id });
                return user!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}