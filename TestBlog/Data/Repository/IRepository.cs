using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBlog.Models;

namespace TestBlog.Data.Repository
{
    public interface IRepository
    {
        Post GetPost(int id);
        List<Post> GetAllPosts();
        void RemovePost(int id);
        void AddPost(Post post);
        void UpdatePost(Post post);
        Task<bool> SaveChangesAsync();
    }
}
