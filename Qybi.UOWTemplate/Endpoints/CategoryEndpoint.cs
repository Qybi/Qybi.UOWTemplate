using Microsoft.AspNetCore.Http.HttpResults;
using Qybi.UOWTemplate.DataAccess.Abstractions;
using Qybi.UOWTemplate.Helpers;
using Qybi.UOWTemplate.Models.DTO;

namespace Qybi.UOWTemplate.Endpoints;

public static class CategoryEndpoint
{
    public static IEndpointRouteBuilder MapCategoryEndPoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("api/v1/categories")
            .WithOpenApi()
            .WithTags("Categories");
        group.MapGet("/", GetAllCategoriesAsync)
            .WithName("GetAllCategories");
        group.MapGet("/{id:int}", GetCategoryByIdAsync)
            .WithName("GetCategoryById");
        group.MapPost("/", CreateCategoryAsync)
            .WithName("CreateCategory");
        group.MapPut("/{id:int}", UpdateCategoryAsync)
            .WithName("UpdateCategory");
        group.MapDelete("/{id:int}", DeleteCategoryAsync)
            .WithName("DeleteCategory");
        return builder;
    }
    private static async Task<Ok<IEnumerable<CategoryDTOStrict>>> GetAllCategoriesAsync(IUnitOfWork _uow)
    {
        var ents = await _uow.Categories.GetAllAsync();
        var results = ToDTOMapper.MapList(ents, ToDTOMapper.MapStrict);
        return TypedResults.Ok(results);
    }
    private static async Task<Results<Ok<CategoryDTOStrict>, NotFound>> GetCategoryByIdAsync(IUnitOfWork _uow, int id)
    {
        var ent = await _uow.Categories.GetById(id);
        if (ent == null)
        {
            return TypedResults.NotFound();
        }
        var result = ToDTOMapper.MapStrict(ent);
        return TypedResults.Ok(result);
    }
    private static async Task<Created<CategoryDTOStrict>> CreateCategoryAsync(IUnitOfWork _uow, CategoryDTOStrict categoryDto)
    {
        var category = ToEntityMapper.Map(categoryDto);
        _uow.Categories.Add(category);
        await _uow.CommitAsync();
        var result = ToDTOMapper.MapStrict(category);
        return TypedResults.Created($"/api/v1/categories/{category.Id}", result);
    }
    private static async Task<Results<Ok<CategoryDTOStrict>, NotFound>> UpdateCategoryAsync(IUnitOfWork _uow, int id, CategoryDTOStrict categoryDto)
    {
        var category = _uow.Categories.GetById(id);

        if (category == null)
        {
            return TypedResults.NotFound();
        }

        var updatedCategory = ToEntityMapper.Map(categoryDto) with { Id = id };

        _uow.Categories.Update(updatedCategory);
        await _uow.CommitAsync();
        var result = ToDTOMapper.MapStrict(updatedCategory);
        return TypedResults.Ok(result);
    }
    private static async Task<Results<NoContent, NotFound>> DeleteCategoryAsync(IUnitOfWork _uow, int id)
    {
        var category = await _uow.Categories.GetById(id);
        if (category == null)
        {
            return TypedResults.NotFound();
        }

        _uow.Categories.Delete(category);
        await _uow.CommitAsync();

        return TypedResults.NoContent();
    }
}
