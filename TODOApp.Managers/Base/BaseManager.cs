using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace TODOApp.Managers.Base
{
	public abstract class BaseManager<EFEntity, RepositoryInteface, ViewModel>
	{
		protected EFEntity entity;
		protected RepositoryInteface repository;
		protected ViewModel viewModel;
		protected IMapper mapper;

		protected BaseManager(RepositoryInteface repository, IMapper mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		public abstract ViewModel GetViewModel(IUrlHelper urlHelper = null);
	}
}
