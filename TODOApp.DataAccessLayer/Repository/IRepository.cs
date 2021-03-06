﻿
using System.Linq;

namespace TODOApp.DataAccessLayer.Repository
{
	public interface IRepository<Type, PrimaryKeyType>
	{
		Type Get(PrimaryKeyType pOId);

		PrimaryKeyType Create(Type pEntity);

		bool Update(Type pEntity);

		bool Delete(PrimaryKeyType pOId);

		IQueryable<Type> GetAll();
	}
}
