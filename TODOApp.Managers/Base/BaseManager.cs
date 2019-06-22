using Microsoft.AspNetCore.Mvc;

namespace TODOApp.Managers.Base
{
	public abstract class BaseManager<EFEntity, RepositoryInteface, ViewModel>
	{
		protected EFEntity entity;
		protected RepositoryInteface repository;
		protected ViewModel viewModel;

		protected BaseManager(RepositoryInteface repository)
		{
			this.repository = repository;
		}

		public abstract ViewModel GetViewModel(IUrlHelper urlHelper = null);
	}
}
