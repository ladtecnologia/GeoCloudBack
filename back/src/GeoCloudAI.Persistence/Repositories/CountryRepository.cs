using Dapper;
using GeoCloudAI.Domain.Classes;
using GeoCloudAI.Persistence.Data;
using GeoCloudAI.Persistence.Contracts;

namespace GeoCloudAI.Persistence.Repositories
{
    public class CountryRepository: ICountryRepository
    {
        private DbSession _db;

        public CountryRepository(DbSession dbSession)
        {
            _db = dbSession;
        }

        public async Task<List<Country>> Get(string term)
        {
            try
            {
                var conn = _db.Connection;

                string query = @"SELECT * FROM COUNTRY ";
                if (term != ""){
                    query = query + "WHERE name      LIKE '%" + @term + "%' "+
                                    "OR    acronym2  LIKE '%" + @term + "%' "+
                                    "OR    acronym3  LIKE '%" + @term + "%' ";
                }
                query = query + "ORDER BY name ";
                
                var countries = (await conn.QueryAsync<Country>(sql: query)).ToList();
            
                return countries;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Country> GetById(int id)
        {
            try
            {
                var conn = _db.Connection;
                string query = "SELECT * FROM COUNTRY WHERE id = @id";
                Country? country = await conn.QueryFirstOrDefaultAsync<Country>(sql: query, param: new { id });
                return country!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}