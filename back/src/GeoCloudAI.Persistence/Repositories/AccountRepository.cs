using Dapper;

using System.Transactions;
using GeoCloudAI.Domain.Classes;
using GeoCloudAI.Persistence.Data;
using GeoCloudAI.Persistence.Contracts;
using GeoCloudAI.Persistence.Models;

namespace GeoCloudAI.Persistence.Repositories
{
    public class AccountRepository: IAccountRepository
    {
        private DbSession _db;

        public AccountRepository(DbSession dbSession)
        {
            _db = dbSession;
        }

        public async Task<int> Add(Account account)
        {
            try
            {
                var conn = _db.Connection;
                using (TransactionScope scope = new TransactionScope())
                {
                    string command = @"INSERT INTO ACCOUNT(name, company, acessMaxAttempts, validityUserPassword, validInviteUser, validInviteProject) 
                                            VALUES(@name, @company, @acessMaxAttempts, @validityUserPassword, @validInviteUser, @validInviteProject); " +
                                    "SELECT LAST_INSERT_ID();";
                    var result = conn.ExecuteScalar<int>(sql: command, param: account);
                    scope.Complete();
                    return result;
                }

                 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> Update(Account account)
        {
            try
            {
                var conn = _db.Connection;
                string command = @"UPDATE ACCOUNT SET 
                                    name                 = @name, 
                                    company              = @company, 
                                    acessMaxAttempts     = @acessMaxAttempts, 
                                    validityUserPassword = @validityUserPassword, 
                                    validInviteUser      = @validInviteUser, 
                                    validInviteProject   = @validInviteProject
                                    WHERE ID             = @id";
                var result = await conn.ExecuteAsync(sql: command, param: account);
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
                string command = @"DELETE FROM ACCOUNT WHERE id = @id";
                var resultado = await conn.ExecuteAsync(sql: command, param: new { id });
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<Account>> Get(PageParams pageParams)
        {
            try
            {
                var conn = _db.Connection;
                var term         = pageParams.Term;
                var orderField   = pageParams.OrderField;
                var orderReverse = pageParams.OrderReverse;

                string query = "SELECT * FROM ACCOUNT ";
                if (term != ""){
                    query = query + "WHERE name     LIKE '%" + @term + "%' " +
                                    "OR    company  LIKE '%" + @term + "%' ";
                }
                
                query = query + "ORDER BY " + @orderField;
                if (orderReverse) {
                    query = query + " DESC ";
                }

                IEnumerable<Account> accounts = (await conn.QueryAsync<Account>(sql: query, param: new {})).ToArray();

                return await PageList<Account>.CreateAsync(accounts, pageParams.PageNumber, pageParams.pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Account> GetById(int id)
        {
            try
            {
                var conn = _db.Connection;
                string query = "SELECT * FROM ACCOUNT WHERE id = @id";
                Account? account = await conn.QueryFirstOrDefaultAsync<Account>(sql: query, param: new { id });
                return account!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}