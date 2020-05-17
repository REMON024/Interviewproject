using System;
using System.Collections.Generic;
using System.Text;

namespace ASPNET.DTO.VM
{
   public class VMGroupData
    {
        public string Content { get; set; }
        public string User { get; set; }
        public DateTime PostTime { get; set; }

        public List<VMComments> lstVMComments { get; set; }

    }

    public class VMComments
    {
        public string Comments { get; set; }
        public string User { get; set; }
        public DateTime CommentsTime { get; set; }
        public int NumberofLike { get; set; }
        public int NumberofDisLike { get; set; }





    }
}
