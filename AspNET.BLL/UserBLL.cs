using ASPNET.DTO;
using ASPNET.DTO.VM;
using AspNetdbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNET.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly AspContext _aspContext;
        public UserBLL(AspContext aspContext)
        {
            _aspContext = aspContext;
        }

        public User AddComments(User user)
        {
            try
            {
                var res = _aspContext.User.Add(user);
                _aspContext.SaveChanges();
                return res.Entity;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<User> GetAll()
        {
            return _aspContext.User.ToList();
        }

        public PaginationResponse GetUserPostDetails(PostFilterPagination postFilter)
        {

            PaginationResponse paginationResponse = new PaginationResponse();

            List<VMGroupData> lstVMGroupData = new List<VMGroupData>();
            VMGroupData vMGroupData = new VMGroupData();
            var res = _aspContext.Post.Select(b=> new Post(){ 
            
            Comments=b.Comments,
            NumberOfComments=b.Comments.Count,
            CreatedBy=b.CreatedBy,
            CreatedTime=b.CreatedTime,
            PostContent=b.PostContent,
            PostID=b.PostID,
            
            }).ToList();

            foreach (var item in res)
            {
                foreach (Comments items in item.Comments)
                {
                    Comments comments = _aspContext.Comments.Where(p => items.CommentsID == p.CommentsID).Select(b => new Comments()
                    {

                        Vote = b.Vote,
                    }).FirstOrDefault();

                    items.NumberOfLike = comments.Vote.Count(p => p.CommentsID == items.CommentsID && p.LikeORDislike == true);
                    items.NumberOfLike = comments.Vote.Count(p => p.CommentsID == items.CommentsID && p.LikeORDislike == false);



                }

            }
            postFilter.Pagination.totalItems = res.Count;
            paginationResponse.Data = res.Skip((postFilter.Pagination.currentPage - 1) * postFilter.Pagination.itemsPerPage)
                        .Take(postFilter.Pagination.itemsPerPage).GroupBy(p=>p.PostID).ToList();
            paginationResponse.Pagination = postFilter.Pagination;
           

            return paginationResponse;
        }
    }
    public interface IUserBLL
    {
        User AddComments(User post);
        List<User> GetAll();
        PaginationResponse GetUserPostDetails(PostFilterPagination postFilter);


    }
}
