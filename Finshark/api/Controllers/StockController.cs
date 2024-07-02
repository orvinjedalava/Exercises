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
        public IActionResult GetAll()
        {
            IEnumerable<StockDTO> stocks = _applicationDbContext.Stocks.ToList()
                .Select(s => s.ToStockDTO());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Stock? stock = _applicationDbContext.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDTO());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDTO stockDTO)
        {
            Stock stockModel = stockDTO.ToStockFromCreateDTO();
            _applicationDbContext.Stocks.Add(stockModel);
            _applicationDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id}, stockModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto stockDto)
        {
            Stock? stockModel = _applicationDbContext.Stocks.FirstOrDefault(x => x.Id == id);

            if (stockModel == null)
                return NotFound();

            stockModel.Symbol = stockDto.Symbol;
            stockModel.CompanyName = stockDto.CompanyName;
            stockModel.Purchase = stockDto.Purchase;
            stockModel.LastDiv = stockDto.LastDiv;
            stockModel.Industry = stockDto.Industry;
            stockModel.MarketCap = stockDto.MarketCap;

            _applicationDbContext.SaveChanges();

            return Ok(stockModel.ToStockDTO());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            Stock? stockModel = _applicationDbContext.Stocks.FirstOrDefault(x => x.Id == id);

            if (stockModel == null)
                return NotFound();

            _applicationDbContext.Stocks.Remove(stockModel);
            _applicationDbContext.SaveChanges();

            return NoContent();
        }
    }
}