namespace cd_backend_web.Models
{
	public class VideoGame
	{
		public int Id { get; set; } = 0;
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Genre { get; set; } = string.Empty;
		public bool Active { get; set; } = true;
	}
}
