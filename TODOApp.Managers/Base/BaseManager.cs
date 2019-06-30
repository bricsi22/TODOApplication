using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TODOApp.Interface.SearchCriteria.Base;

namespace TODOApp.Managers.Base
{
	public abstract class BaseManager<EFEntity, RepositoryInteface, ViewModel, SearchCriteria, PrimaryKeyType> where SearchCriteria : ISearchCriteria<PrimaryKeyType>
	{
		protected EFEntity entity;
		protected readonly RepositoryInteface repository;
		protected ViewModel viewModel;
		protected IMapper mapper;

		protected BaseManager(RepositoryInteface repository, IMapper mapper, SearchCriteria searchCriteria)
		{
			this.repository = repository;
			this.mapper = mapper;
			this.SearchCriteriaProperty = searchCriteria;
		}

		public abstract ViewModel GetViewModel(SearchCriteria searchCriteria, IUrlHelper urlHelper = null);

		public void SetEntity(EFEntity entity)
		{
			this.entity = entity;
		}

		public SearchCriteria SearchCriteriaProperty { get; protected set; }
	}
}
