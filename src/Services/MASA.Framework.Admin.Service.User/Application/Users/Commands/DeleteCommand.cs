namespace MASA.Framework.Admin.Service.User.Application.Users.Commands;

public record DeleteCommand : Command
{
    public Guid Id { get; set; }
}

