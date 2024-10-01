
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProducts;
public record GetProductsRequest(int? PageNumber =1, int? PageSize =10);
public record GetProductsResponse(IEnumerable<Product> products);
public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] GetProductsRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetProductsQuery>();
            var result = await sender.Send(new GetProductsQuery());
            var response = result.Adapt<GetProductsResponse>();
            return Results.Ok(response);
        })
        .WithName("Get Product")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product")
        .WithDescription("Get Product");
        ;
    }
}
