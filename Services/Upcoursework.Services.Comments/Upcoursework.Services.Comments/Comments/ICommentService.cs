using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.DTOs.AuthorDtos;
using Upcoursework.DTOs.CommentDtos;

namespace Upcoursework.Services.Comments.Comments;
public interface ICommentService
{
    Task<IEnumerable<CommentGetDto>> GetAll();
    Task<CommentGetDto> GetById(Guid id);
    Task<CommentGetDto> Create(CommentCreateDto model);
    Task Delete(Guid id);
}
