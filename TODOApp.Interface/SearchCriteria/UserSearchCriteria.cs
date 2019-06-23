using TODOApp.Interface.SearchCriteria.Base;

namespace TODOApp.Interface.SearchCriteria
{
	public class UserSearchCriteria : ISearchCriteria<string>
	{
		public string Id { get;  set; }
	}
}
