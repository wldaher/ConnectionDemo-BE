using cd_backend_web.Models;
using cd_backend_web.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace cd_backend_web.Controllers
{
	[ApiController]
	// The [controller] route means that the class name minus 'Controller' will be used as the route.
	[Route("[controller]")]
	public class BookController : ControllerBase
	{
		private readonly ILogger<BookController> _logger;
		private readonly BookRepository _bookRepository;

		// logger and configuration are automatically provided by ASP.NET for Dependency Injection
		public BookController(ILogger<BookController> logger, IConfiguration configuration)
		{
			this._logger = logger;
			// This would normally be created using Dependency Injection in the Program.cs file.
			// For simplicity, DI is being ignored in favor of direct creation
			this._bookRepository = new BookRepository(configuration);
		}

		// An Http attribute with no parameter becomes the default route for that attribute.
		// Therefore only one empty attribute for each controller route can be used
		[HttpGet]
		// The vast majority of controller endpoints should be marked async, as they eventually make outside calls or access databases (which should be async calls)
		public async Task<IEnumerable<Book>> GetBooksAsync()
		{
			return await this._bookRepository.GetBooksAsync();
		}

		// This post has no route param, so it will use the same route as GetBooksAsync, but a different method
		[HttpPost]
		public async Task<Book> ToggleReadAsync(Book book)
		{
			return await this._bookRepository.ToggleReadAsync(book);
		}
	}
}