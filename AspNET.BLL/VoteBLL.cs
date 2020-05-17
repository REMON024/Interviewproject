using ASPNET.DTO;
using AspNetdbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNET.BLL
{
    public class VoteBLL : IVoteBLL
    {
        private readonly AspContext _aspContext;
        public VoteBLL(AspContext aspContext)
        {
            _aspContext = aspContext;
        }

        public Vote AddVote(Vote vote)
        {
            try
            {
                var res = _aspContext.Vote.Add(vote);
                _aspContext.SaveChanges();
                return res.Entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Vote> GetAll()
        {
            return _aspContext.Vote.ToList();
        }
    }
    public interface IVoteBLL
    {
        Vote AddVote(Vote post);
        List<Vote> GetAll();


    }
}
