using Application.Dto_s;
using Application.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class IngredientsService : IIngredientsService
    {
        public readonly ApplicationDBContext _context;
        public readonly IMapper _mapper;
        public IngredientsService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetingredientsDto>> GetIngredientsAsync()
        {
            try
            {
                var Ingredients = await _context.Ingredients.ToListAsync();
                return _mapper.Map<List<GetingredientsDto>>(Ingredients);
            }
            catch (Exception ex)
            {
                return new List<GetingredientsDto>();
            }

            
        }
    }
}
