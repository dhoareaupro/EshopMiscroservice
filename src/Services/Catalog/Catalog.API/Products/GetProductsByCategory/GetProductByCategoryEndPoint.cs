
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductByCategoryResponse(IEnumerable<Product> Category) : IQuery<GetProductByCategoryResult>;
public class GetProductByCategoryEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}",
            async (string category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));
                var response = result.Adapt<GetProductByCategoryResponse>();
                return Results.Ok(response);
            
            })
             .WithName("Get Product by categoryu")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product by category")
        .WithDescription("Get Product by category");
        ;
    }
}
