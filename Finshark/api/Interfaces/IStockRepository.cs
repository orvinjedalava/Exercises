using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Stock;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(CreateStockRequestDTO stockDTO);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDTO);
        Task<Stock?> DeleteAsync(int id);
    }
}