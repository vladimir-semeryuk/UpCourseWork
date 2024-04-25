using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.DTOs.AuthorDtos;

namespace Upcoursework.Services.Authors.Authors;
public interface IAuthorService
{
    Task<IEnumerable<AuthorGetDto>> GetAll();
    Task<AuthorGetDto> GetById(Guid id);
    Task<AuthorGetDto> Create(AuthorCreateDto model);
    Task Update(Guid id, AuthorUpdateDto model);
    Task Delete(Guid id);

}
