﻿using Core.DataAccess;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IRepositoryBase<Blog>
    {
    }
}
