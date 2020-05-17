using ASPNET.DTO;
using AspNetdbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNET.BLL
{
    public class CommentsBLL : ICommentsBLL
    {
        private readonly AspContext _aspContext;
        public CommentsBLL(AspContext aspContext)
        {
            _aspContext = aspContext;
        }

        public Comments AddComments(Comments comments)
        {
            try
            {
                var res = _aspContext.Comments.Add(comments);
                _aspContext.SaveChanges();
                return res.Entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Comments> GetAll()
        {
            return _aspContext.Comments.ToList();
        }
    }
    public interface ICommentsBLL
    {
        Comments AddComments(Comments post);
        List<Comments> GetAll();


    }
}
