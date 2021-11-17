using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBlog.Models;

namespace TestBlog.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public Post GetPost(int id)
        {
            return _context.Posts.FirstOrDefault(x=>x.Id==id);
        }
        public List<Post> GetAllPosts()
        {
            return _context.Posts.ToList();
        }
        public void RemovePost(int id)
        {
            _context.Posts.Remove(GetPost(id));
        }
        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
        }
        public void UpdatePost(Post post)
        {
            _context.Posts.Update(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync()>0)
            {
                return true;
            }
            return false;
        }
    }
}
