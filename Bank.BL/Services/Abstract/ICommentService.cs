using System.Collections;
using System.Collections.Generic;
using Bank.DAL.Models;
using Bank.DAL.Repositories;

namespace Bank.BL.Services.Abstract
{
    public interface ICommentService
    {
        void Create(Comment comment);
        IEnumerable<Comment> GetFirst10Comments();
    }
}