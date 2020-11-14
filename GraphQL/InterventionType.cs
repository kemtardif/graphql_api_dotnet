using GraphQL_API.Entities;
using GraphQL.Types;

namespace GraphQL_API.GraphQL
{
  public class InterventionType : ObjectGraphType<FactIntervention>
  {
    public InterventionType()
    {

      Field(x => x.Id).Description("Id of Intervention");
      Field(x => x.BuildingId).Description("Building Id of Intervention");
     // Field(x => x.StartDateIntervention);
      //Field(x => x.EndDateIntervention);
      
    }
  }
} 