namespace cd_backend_web.Models
{
	public class Book
	{
		public int Id { get; set; } = 0;
		public string Name { get; set; } = string.Empty;
		public string Author { get; set; } = string.Empty;
		public string Format { get; set; } = string.Empty;
		public bool Read { get; set; } = false;
	}
}
