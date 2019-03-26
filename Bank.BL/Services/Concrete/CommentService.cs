using System;
using System.Collections.Generic;
using System.Linq;
using Bank.BL.Services.Abstract;
using Bank.DAL.Models;
using Bank.DAL.Repositories;
using Microsoft.Extensions.Logging;
using static Bank.Common.Constants.ErrorMessages;

namespace Bank.BL.Services.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<CommentService> _logger;

        public CommentService(IUnitOfWork uow, ILoggerFactory loggerFactory)
        {
            _uow = uow;
            _logger = loggerFactory.CreateLogger<CommentService>();
        }

        public void Create(Comment comment)
        {
            if (string.IsNullOrWhiteSpace(comment.Header))
                throw new ArgumentException(ParameterIsRequired(nameof(comment.Header)));
            
            if (string.IsNullOrWhiteSpace(comment.Description))
                throw new ArgumentException(ParameterIsRequired(nameof(comment.Description)));

            _uow.Repository<Comment>().Add(comment);
            _uow.SaveChanges();
            
            _logger.LogDebug("Comment was created");
        }

        public IEnumerable<Comment> GetFirst10Comments()
        {
            return _uow.Repository<Comment>().GetQueryable().ToList().TakeLast(10);
        }
    }
}