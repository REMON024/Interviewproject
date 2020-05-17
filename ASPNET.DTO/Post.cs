using System;
using System.Collections.Generic;
using System.Text;

namespace ASPNET.DTO
{
   public class Post
    {
        public int PostID { get; set; }
        public string PostContent { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }

        public int NumberOfComments { get; set; }

        public List<Comments> Comments { get; set; }



    }
}
