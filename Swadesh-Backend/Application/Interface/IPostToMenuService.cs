using Application.Dto_s;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IPostToMenuService
    {
        Task<MenuItem> PostToMenuAsync(PostToMenuDto dto);
    }
}
