using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bank.DAL.Models;

namespace Bank.Web.ViewModels
{
    public class CommentModel
    {
        [Required]
        public string Header { get; set; }
        
        [Required]
        public string Description { get; set;  }

        public Comment To(int id)
        {
            return new Comment
            {
                Header = Header,
                Description = Description,
                ClientId = id
            };
        }

        public static CommentModel From(Comment comment)
        {
            return new CommentModel
            {
                Description = comment.Description,
                Header = comment.Header
            };
        }
    }
    
    public class CommentModels
    {
        [Required]
        public string Header { get; set; }
        
        [Required]
        public string Description { get; set;  }

        public IEnumerable<CommentModel> Comments;
    }
}