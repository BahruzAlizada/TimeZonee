using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            this.blogDal= blogDal;
        }

        public void Activity(int id)
        {
           blogDal.Activity(id);
        }

        public void Add(Blog blog)
        {
           blogDal.Add(blog);
        }

        public List<Blog> GetAll()
        {
            return blogDal.GetAll();
        }

        public Blog GetById(int id)
        {
            return blogDal.Get(x=>x.Id == id);
        }

        public void Update(Blog blog)
        {
            blogDal.Update(blog);
        }
    }
}
