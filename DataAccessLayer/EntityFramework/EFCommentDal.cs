using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.EntityFramework
{
    public class EFCommentDal : EfRepositoryBase<Comment, Context>, ICommentDal
    {
        public List<Comment> GetCommentsByUser(string name, int pageNumber, int pageSize)
        {
            using var context = new Context();

            var Comments = context.Comments.Include(x => x.Blog).Include(x => x.AppUser)
                .Where(x => x.AppUser.Name == name)
                .OrderByDescending(x => x.CreatedTime)
                .Skip((pageNumber - 1) * pageSize) 
                .Take(pageSize).ToList();

            return Comments;
        }

        public int TotalCountsByUser(string name)
        {
            using var context = new Context();
            var CommentsCount = context.Comments.Include(x => x.Blog).Include(x => x.AppUser)
                .Where(x => x.AppUser.Name == name).Count();

            return CommentsCount;
        }
    }
}
