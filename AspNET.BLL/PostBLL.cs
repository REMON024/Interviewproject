using ASPNET.DTO;
using AspNetdbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNET.BLL
{
   public class PostBLL: IPostBLL
    {
        private readonly AspContext _aspContext;
        public PostBLL(AspContext aspContext)
        {
            _aspContext = aspContext;
        }

        public Post AddPost(Post post)
        {
            try
            {
                var res = _aspContext.Post.Add(post);
                _aspContext.SaveChanges();
                return res.Entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Post> GetAll()
        {
           return _aspContext.Post.ToList();
        }
    }
    public interface IPostBLL
    {
        Post AddPost(Post post);
        List<Post> GetAll();


    }
}
