using cd_backend_web.Models;
using cd_backend_web.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace cd_backend_web.Controllers
{
	[ApiController]
	// The [controller] route means that the class name minus 'Controller' will be used as the route.
	[Route("[controller]")]
	public class VideoGameController : ControllerBase
	{
		private readonly ILogger<VideoGameController> _logger;
		private readonly VideoGameRepository _videoGameRepository;

		// logger and configuration are automatically provided by ASP.NET for Dependency Injection
		public VideoGameController(ILogger<VideoGameController> logger, IConfiguration configuration)
		{
			this._logger = logger;
			// This would normally be created using Dependency Injection in the Program.cs file.
			// For simplicity, DI is being ignored in favor of direct creation
			this._videoGameRepository = new VideoGameRepository(configuration);
		}

		// An Http attribute with no parameter (or Name parameter) becomes the default route for that attribute.
		// Therefore only one empty attribute for each controller route can be used
		[HttpGet]
		// The vast majority of controller endpoints should be marked async, as they eventually make outside calls or access databases (which should be async calls)
		public async Task<IEnumerable<VideoGame>> GetVideoGamesAsync()
		{
			return await this._videoGameRepository.GetVideoGamesAsync();
		}

		// An Http attribute with a name adds to the controller route - here, it means the route for this action is 'VideoGame\ToggleActive'.
		[HttpPost("ToggleActive")]
		public async Task<VideoGame> ToggleActiveAsync(VideoGame game)
		{
			return await this._videoGameRepository.ToggleActiveAsync(game);
		}
	}
}