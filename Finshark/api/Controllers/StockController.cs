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
using api.Interfaces;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StockController(ApplicationDbContext applicationDbContext,
            IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<Stock> stocks = await _stockRepository.GetAllAsync();

            IEnumerable<StockDTO> stockDTOs = stocks.Select( s => s.ToStockDTO());

            return Ok(stockDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            Stock? stock = await _stockRepository.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStockRequestDTO stockDTO)
        {
            Stock stockModel = await _stockRepository.CreateAsync(stockDTO);
            
            return CreatedAtAction(nameof(GetByIdAsync), new { id = stockModel.Id}, stockModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateStockRequestDto stockDTO)
        {
            Stock? stockModel = await _stockRepository.UpdateAsync(id, stockDTO);

            if (stockModel == null)
                return NotFound();

            return Ok(stockModel.ToStockDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            Stock? stockModel = await _stockRepository.DeleteAsync(id);

            if (stockModel == null)
                return NotFound();

            return NoContent();
        }
    }
}