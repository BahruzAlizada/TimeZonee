using Core.DataAccess;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.Abstract
{
    public interface ICommentDal : IRepositoryBase<Comment>
    {
        List<Comment> GetCommentsByUser(string name, int pageNumber, int pageSize);
        int TotalCountsByUser(string name);
    }
}
