using System;
using System.Collections.Generic;
using System.Text;

namespace ASPNET.DTO
{
   public class Vote
    {
        public int VoteID { get; set; }
        public bool LikeORDislike { get; set; }
        public int CommentsID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public Comments Comments { get; set; }

        

    }
}
