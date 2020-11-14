using System.Threading.Tasks;
using GraphQL_API.Entities;

using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using GraphQL.SystemTextJson;
using GraphQL.NewtonsoftJson;

namespace GraphQL_API.GraphQL
{
  [Route(Startup.GraphQlPath)]
  [ApiController]

  public class GraphQLController : Controller
  {
    private readonly cindy_okino_warehouseContext _db;
    
    public GraphQLController(cindy_okino_warehouseContext db) => _db = db;

    [HttpPost]

    public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
    {
        var schema = new Schema{
          Query = new InterventionQuery(_db)
        };

      var result = await new DocumentExecuter().ExecuteAsync(_ =>
      {
        _.Schema = schema;
        _.Query = query.Query;
        _.OperationName = query.OperationName;
        _.Inputs = query.Variables;
      });

      if(result.Errors?.Count > 0)
      {
        return BadRequest();
      }

      return Ok(result);
      }
  }


}