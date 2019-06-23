using TODOApp.Interface.SearchCriteria.Base;

namespace TODOApp.Interface.SearchCriteria
{
	public class TodoItemSearchCriteria : ISearchCriteria<long>
	{
		public long Id { get; set; }
	}
}
