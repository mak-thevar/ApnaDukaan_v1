﻿using ApnaDukaan_v1.DAL.DBContext;
using ApnaDukaan_v1.DAL.Entities;
using ApnaDukaan_v1.DAL.Repositories.Interface;

namespace ApnaDukaan_v1.DAL.Repositories.Impl
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(ApnaDukaanContext dbContext) : base(dbContext)
        {
        }
    }
}
