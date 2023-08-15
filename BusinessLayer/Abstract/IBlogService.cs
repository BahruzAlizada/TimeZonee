using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        List<Blog> GetAll();
        Blog GetById(int id);
        void Add(Blog blog);
        void Update(Blog blog);
    }
}
