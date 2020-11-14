using System.Linq;
using GraphQL_API.Entities;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using GraphQL;

namespace GraphQL_API.GraphQL
{
  public class InterventionQuery : ObjectGraphType
  {
    public InterventionQuery(cindy_okino_warehouseContext db)
    {
      Field<InterventionType>(
        name: "intervention",

        arguments: new QueryArguments(
          new QueryArgument<IntGraphType> { Name = "id" }), ///MAYBE IdGraphType

        resolve: context =>
        {
          var id = context.GetArgument<int>("id");  ///MAYBE int
          
          var intervention = db
            .FactInterventions
            .FirstOrDefault(i => i.Id == id);
          return intervention;
        });

      Field<ListGraphType<InterventionType>>(
        name: "interventions",
        
        resolve: context =>
        {
          var interventions = db.FactInterventions;
          return interventions.ToList();
        });
    }
  }
}