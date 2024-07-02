using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Stock;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StockRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _applicationDbContext.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Stock> CreateAsync(CreateStockRequestDTO stockDTO)
        {
            Stock stockModel = stockDTO.ToStockFromCreateDTO();
            await _applicationDbContext.Stocks.AddAsync(stockModel);
            await _applicationDbContext.SaveChangesAsync();

            return stockModel;
        }
        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDTO)
        {
            Stock? stockModel = await _applicationDbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel == null)
                return null;

            stockModel.Symbol = stockDTO.Symbol;
            stockModel.CompanyName = stockDTO.CompanyName;
            stockModel.Purchase = stockDTO.Purchase;
            stockModel.LastDiv = stockDTO.LastDiv;
            stockModel.Industry = stockDTO.Industry;
            stockModel.MarketCap = stockDTO.MarketCap;

            await _applicationDbContext.SaveChangesAsync();

            return stockModel;
        }
        public async Task<Stock?> DeleteAsync(int id)
        {
            Stock? stockModel = await _applicationDbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel == null)
                return null;

            _applicationDbContext.Stocks.Remove(stockModel);
            await _applicationDbContext.SaveChangesAsync();

            return stockModel;
        }
    }
}