﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
    {
        var result = await _productService.GetProducts();
        return Ok(result);
    }

    [HttpGet("admin"), Authorize(Roles = "Admin")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAdminProducts()
    {
        var result = await _productService.GetAdminProducts();
        return Ok(result);
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
    {
        var result = await _productService.GetProduct(productId);
        return Ok(result);
    }

    [HttpGet("category/{categoryUrl}")]
    public async Task<ActionResult<ServiceResponse<ProductSearchResult>>> GetProductsByCategory(string categoryUrl)
    {
        var result = await _productService.GetProductsByCategory(categoryUrl);
        return Ok(result);
    }

    [HttpGet("search/{searchText}/{page}")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> SearchProducts(string searchText, int page = 1)
    {
        var result = await _productService.SearchProducts(searchText, page);
        return Ok(result);
    }

    [HttpGet("searchsuggestions/{searchText}")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsSearchSuggestions(string searchText)
    {
        var result = await _productService.GetProductSearchSuggestions(searchText);
        return Ok(result);
    }

    [HttpGet("featured")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProducts()
    {
        var result = await _productService.GetFeaturedProducts();
        return Ok(result);
    }
}
