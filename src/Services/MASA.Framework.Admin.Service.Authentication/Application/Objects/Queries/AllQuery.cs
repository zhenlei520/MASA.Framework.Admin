namespace MASA.Framework.Admin.Service.Authentication.Application.Objects.Queries;

public record AllQuery() : Query<List<ObjectItemResponse>>
{
    public override List<ObjectItemResponse> Result { get; set; } = new List<ObjectItemResponse>();
}
