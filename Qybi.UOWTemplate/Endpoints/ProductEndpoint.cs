using Microsoft.AspNetCore.Http.HttpResults;
using Qybi.UOWTemplate.DataAccess.Abstractions;
using Qybi.UOWTemplate.Helpers;
using Qybi.UOWTemplate.Models.DTO;
using Qybi.UOWTemplate.Models.Entities;

namespace Qybi.UOWTemplate.Endpoints;

public static class ProductEndpoint
{
    public static IEndpointRouteBuilder MapProductEndPoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("api/v1/products")
            .WithOpenApi()
            .WithTags("Products");

        group.MapGet("/", GetAllProductsAsync)
            .WithName("GetAllProducts");

        group.MapGet("/{id:int}", GetProductByIdAsync)
            .WithName("GetProductById");

        group.MapPost("/", CreateProductAsync)
            .WithName("CreateProduct");

        group.MapPut("/{id:int}", UpdateProductAsync)
            .WithName("UpdateProduct");

        group.MapDelete("/{id:int}", DeleteProductAsync)
            .WithName("DeleteProduct");

        return builder;
    }

    private static async Task<Ok<IEnumerable<ProductDTO>>> GetAllProductsAsync(IUnitOfWork _uow)
    {
        var ents = await _uow.Products.GetAllWithCategory();
        var results = ToDTOMapper.MapList(ents, ToDTOMapper.Map);
        return TypedResults.Ok(results);
    }

    private static async Task<Results<Ok<ProductDTO>, NotFound>> GetProductByIdAsync(IUnitOfWork _uow, int id)
    {
        var ent = await _uow.Products.GetById(id);
        if (ent == null)
        {
            return TypedResults.NotFound();
        }
        var result = ToDTOMapper.Map(ent);
        return TypedResults.Ok(result);
    }

    private static async Task<Created<ProductDTOStrict>> CreateProductAsync(IUnitOfWork _uow, ProductDTOStrict productDto)
    {
        var product = ToEntityMapper.Map(productDto);

        _uow.Products.Add(product);
        await _uow.CommitAsync();

        var result = ToDTOMapper.MapStrict(product);
        return TypedResults.Created($"/api/v1/products/{product.Id}", result);
    }

    private static async Task<Results<Ok<ProductDTO>, NotFound>> UpdateProductAsync(IUnitOfWork _uow, int id, ProductDTO productDto)
    {
        var product = await _uow.Products.GetById(id);
        if (product == null)
        {
            return TypedResults.NotFound();
        }

        var updatedProduct = ToEntityMapper.Map(productDto) with { Id = id };

        _uow.Products.Update(updatedProduct);
        await _uow.CommitAsync();

        var result = ToDTOMapper.Map(updatedProduct);
        return TypedResults.Ok(result);
    }

    private static async Task<Results<NoContent, NotFound>> DeleteProductAsync(IUnitOfWork _uow, int id)
    {
        var product = await _uow.Products.GetById(id);
        if (product == null)
        {
            return TypedResults.NotFound();
        }

        _uow.Products.Delete(product);
        await _uow.CommitAsync();

        return TypedResults.NoContent();
    }
}
