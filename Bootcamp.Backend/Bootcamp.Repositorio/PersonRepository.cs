using Bootcamp.Modelo;
using Bootcamp.ViewModel;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Repositorio
{
    public class PersonRepository : iPersonRepository
    {
        private readonly string _connectionString;
        

        public PersonRepository(IConfiguration configuration) 
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }
        public async Task<int> Create(Person person)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Name", person.Name);
            parameters.Add("@Lastname", person.Lastname);
            parameters.Add("@DocumentTypeId", person.DocumentTypeId);
            parameters.Add("@DocumentNumber", person.DocumentNumber);
            parameters.Add("@Birthday", person.Birthday);


            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Ins_Person]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return result; 

        }

        public async Task<int> Delete(int id)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Delete_Person]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }

        /*
        public async Task<IEnumerable<PersonViewModel>> GetAll()
        {
            IEnumerable<PersonViewModel> result = new List<PersonViewModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<PersonViewModel>("[dbo].[Usp_Select_Person]", commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }
        */
        public async Task<int> Update(Person person)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Id", person.Id);
            parameters.Add("@Name", person.Name);
            parameters.Add("@Lastname", person.Lastname);
            parameters.Add("@DocumentTypeId", person.DocumentTypeId);
            parameters.Add("@DocumentNumber", person.DocumentNumber);
            parameters.Add("@Birthday", person.Birthday);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Update_Person]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
