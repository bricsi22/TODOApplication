using System.ComponentModel.DataAnnotations;

namespace TODOApp.DataAccessLayer.Models
{
    public class TodoItem
    {
		[Key]
		public long Id { get; set; }

		public string Name { get; set; }

		public string DeadLine { get; set; }

		public string Description { get; set; }

		public string UserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
	}
}
