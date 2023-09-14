using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.EntityFramework
{
    public class EFBlogDal : EfRepositoryBase<Blog, Context>, IBlogDal
    {
        public void Activity(int id)
        {
            using(var context = new Context())
            {
                Blog blog = context.Blogs.FirstOrDefault(x => x.Id == id);
                if(blog.IsDeactive)
                    blog.IsDeactive=false;
                else
                    blog.IsDeactive=true;

                context.SaveChanges();
            }
        }
    }
}
