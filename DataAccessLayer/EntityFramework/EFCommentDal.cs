using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.EntityFramework
{
    public class EFCommentDal : EfRepositoryBase<Comment,Context>,ICommentDal
    {
    }
}
