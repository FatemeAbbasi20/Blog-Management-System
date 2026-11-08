using CodeYad_Blog_CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.DTOs.Posts
{
    public class PostFilterDto: BasePagination
    {
        public List<PostDto> Posts { get; set; }
        public PostFilterParams FilterParams { get; set; }

        public class PostFilterParams
        {
            public int Take { get; set; }
            public int PageId { get; set; }
            public string CategorySlug { get; set; }
            public string Title { get; set; }

        }
    }
}
