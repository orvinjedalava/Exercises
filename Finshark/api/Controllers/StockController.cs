using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;
using api.DTOs.Stock;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StockController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<Stock> stocks = await _applicationDbContext.Stocks.ToListAsync();

            IEnumerable<StockDTO> stockDTOs = stocks.Select( s => s.ToStockDTO());

            return Ok(stockDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            Stock? stock = await _applicationDbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStockRequestDTO stockDTO)
        {
            Stock stockModel = stockDTO.ToStockFromCreateDTO();
            await _applicationDbContext.Stocks.AddAsync(stockModel);
            await _applicationDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByIdAsync), new { id = stockModel.Id}, stockModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateStockRequestDto stockDto)
        {
            Stock? stockModel = await _applicationDbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel == null)
                return NotFound();

            stockModel.Symbol = stockDto.Symbol;
            stockModel.CompanyName = stockDto.CompanyName;
            stockModel.Purchase = stockDto.Purchase;
            stockModel.LastDiv = stockDto.LastDiv;
            stockModel.Industry = stockDto.Industry;
            stockModel.MarketCap = stockDto.MarketCap;

            await _applicationDbContext.SaveChangesAsync();

            return Ok(stockModel.ToStockDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            Stock? stockModel = await _applicationDbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel == null)
                return NotFound();

            _applicationDbContext.Stocks.Remove(stockModel);
            await _applicationDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}