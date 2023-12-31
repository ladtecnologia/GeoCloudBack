using Dapper;

using System.Transactions;
using GeoCloudAI.Domain.Classes;
using GeoCloudAI.Persistence.Data;
using GeoCloudAI.Persistence.Contracts;
using GeoCloudAI.Persistence.Models;
using System.Linq;

namespace GeoCloudAI.Persistence.Repositories
{
    public class ProfileRepository: IProfileRepository
    {
        private DbSession _db;

        public ProfileRepository(DbSession dbSession)
        {
            _db = dbSession;
        }

        public async Task<int> Add(Profile profile)
        {
            try
            {
                var conn = _db.Connection;
                using (TransactionScope scope = new TransactionScope())
                {
                    if (profile.Account == null) {
                        return 0;
                    }
                    var accountId = profile.Account.Id;
                    string command = @"INSERT INTO PROFILE(accountId, name)
                                            VALUES(@accountId, @name); " +
                                    "SELECT LAST_INSERT_ID();";
                    var result = conn.ExecuteScalar<int>(sql: command, param: new {accountId , profile.Name});
                    scope.Complete();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> Update(Profile profile)
        {
            try
            {
                var conn = _db.Connection;
                if (profile.Account == null) {
                        return 0;
                    }
                var accountId = profile.Account.Id;
                string command = @"UPDATE PROFILE SET 
                                    accountId = @accountId,
                                    name      = @name
                                    WHERE id  = @id";
                var result = await conn.ExecuteAsync(sql: command, param: new {accountId , profile.Name, profile.Id});
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
                string command = @"DELETE FROM PROFILE WHERE id = @id";
                var resultado = await conn.ExecuteAsync(sql: command, param: new { id });
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<Profile>> Get(PageParams pageParams)
        {
            try
            {
                var conn = _db.Connection;
                var term         = pageParams.Term;
                var orderField   = pageParams.OrderField;
                var orderReverse = pageParams.OrderReverse;

                string query = @"SELECT P.*, A.id as split1, A.*
                                FROM Profile P 
                                INNER JOIN Account A ON P.accountId = A.id ";
                if (term != ""){
                     query = query + "WHERE P.name LIKE '%" + @term + "%' ";
                }
                if (orderField != ""){
                    query = query + "ORDER BY P." + @orderField;
                    if (orderReverse) {
                        query = query + " DESC ";
                    }
                }

                var res = await conn.QueryAsync<Profile, Account, Profile>(
                    sql: query,
                    map: (profile, account) => {
                        profile.Account = account;
                        return profile;
                    },
                    splitOn: "split1",
                    param: new {});
            
                return await PageList<Profile>.CreateAsync(res, pageParams.PageNumber, pageParams.pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Profile> GetById(int id)
        {
            try
            {
                var conn = _db.Connection;
                string query = @"SELECT P.*, A.id as split1, A.*
                                FROM Profile P 
                                INNER JOIN Account A ON P.accountId = A.id
                                WHERE P.ID = @id";
                var res =  await conn.QueryAsync<Profile, Account, Profile>(
                    sql: query,
                    map: (profile, account) => {
                        profile.Account = account;
                        return profile;
                    },
                    splitOn: "split1",
                    param: new { id });
                return res.First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}