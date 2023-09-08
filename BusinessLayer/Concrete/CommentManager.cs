using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            this.commentDal=commentDal;
        }

        public void Add(Comment comment)
        {
           commentDal.Add(comment);
        }

        public void Delete(Comment comment)
        {
            commentDal.Delete(comment); 
        }

        public void Update(Comment comment)
        {
            commentDal.Update(comment); 
        }
    }
}
