using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationshipSettingPractice.EFClass
{
    public class Article
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        //一篇文章有多篇评论
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
