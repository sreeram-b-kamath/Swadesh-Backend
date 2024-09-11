﻿using Application.Dto_s;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IMenuItemService
    {
        Task<MenuItem> PostToMenuAsync(PostToMenuDto dto);
        Task<List<GetMenuItemDto>> GetMenuItemsByRestarauntIdAsync(int restarauntId);
        Task<bool> DeleteMenuItemAsync(int menuItemId);

        Task<bool> UpdateMenuItemAsync(int menuItemId, PostToMenuDto dto);
        Task<GetMenuItemDto> GetMenuItemByIdAsync(int menuItemId);

    }
}
