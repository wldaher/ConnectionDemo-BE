using System.Data.SqlClient;

using cd_backend_web.Models;

using Dapper;

namespace cd_backend_web.Repositories
{
	public class BookRepository
	{
        private readonly string _connString;

        public BookRepository(IConfiguration configuration) 
		{
			// This value is pulled from the currently loaded appsettings.json file.
			// The launch profile used to start the application determines which file is combined with the base appsettings.json file (by default in Visual Studio 'Development' is used)
			// i.e. launching this app will take the values from appsettings.Development.json and merge them with the base appsettings.json, overwriting any existing props in the base file
			// with those found in the environment specific file.  Non-matching properties from either file will both be present in the final configuration
            this._connString = configuration.GetConnectionString("DefaultConnection").ToString();
        }

		public async Task<IEnumerable<Book>> GetBooksAsync()
		{
			using(var connection = new SqlConnection(this._connString))
			{
				connection.Open();

				var sql = "SELECT Id, Name, Author, Format, [Read] FROM ConnectionDemo.dbo.Books";

				// QueryAsync is an extension method from the nuget package Dapper
				// Queries can be made without using Dapper, but it makes SQL queries significantly easier to work with
				var results = await connection.QueryAsync<Book>(sql);

				return results;
			}
		}

		public async Task<Book> ToggleReadAsync(Book book)
		{
			using (var connection = new SqlConnection(this._connString))
			{
				connection.Open();

				var sql = "UPDATE ConnectionDemo.dbo.Books SET [Read] = @Read WHERE Id = @Id";

				var paramDictionary = new Dictionary<string, object?>()
				{
					{ "@Read ", !book.Read },
					{ "@Id", book.Id }
				};

				// ExecuteScalarAsync is an extension method from the nuget package Dapper
				// DynamicParameters is a Dapper class that turns dictionaries into sql parameters
				await connection.ExecuteScalarAsync(sql, new DynamicParameters(paramDictionary));
				book.Read = !book.Read;

				return book;
			}
		}
	}
}
