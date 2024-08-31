
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IRestaurantService
    {
        public Task<RestuarantUserGetDto> GetRestaurantByIdAsync(int id);
    }
}
