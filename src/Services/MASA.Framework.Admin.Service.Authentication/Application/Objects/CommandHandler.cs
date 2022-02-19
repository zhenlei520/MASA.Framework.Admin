namespace MASA.Framework.Admin.Service.Authentication.Application.Objects;

public class CommandHandler
{
    private readonly IObjectRepository _repository;

    public CommandHandler(IObjectRepository repository)
    {
        _repository = repository;
    }

    [EventHandler]
    public async Task AddObjectAsync(ObjectCommand.AddCommand command)
    {
        if (await _repository.ExistAsync(command.Request.Code))
            throw new UserFriendlyException("duplicate resource");

        var objectItem = new Domain.Aggregate.ObjectAggregate.Object(command.Creator, command.Request.Code, command.Request.Name,
            command.Request.State, command.Request.ObjectType);
        command.Request.ObjectItems.ForEach(permission =>
        {
            objectItem.AddPermission(permission.Name, permission.ObjectIdentifies, permission.Action, permission.PermissionType);
        });
        await _repository.AddAsync(objectItem);
        await _repository.UnitOfWork.SaveChangesAsync();
    }

    [EventHandler]
    public async Task EditObjectAsync(ObjectCommand.EditCommand command)
    {
        var objectItem = await _repository.FindAsync(command.Request.ObjectId);
        if (objectItem == null)
            throw new UserFriendlyException("The current object does not exist", Code.NOT_FIND_ERROR);

        objectItem.Update(command.Request.Name, command.Request.State);
        await _repository.UpdateAsync(objectItem);
        await _repository.UnitOfWork.SaveChangesAsync();
    }

    [EventHandler]
    public async Task DeleteObjectAsync(ObjectCommand.DeleteCommand command)
    {
        await _repository.RemoveAsync(o => o.Id == command.Request.ObjectId);
        await _repository.UnitOfWork.SaveChangesAsync();
    }


    [EventHandler]
    public async Task BatchDeleteAsync(ObjectCommand.BatchDeleteCommand command)
    {
        await _repository.RemoveAsync(o => command.Request.ObjectIds.Contains(o.Id));
        await _repository.UnitOfWork.SaveChangesAsync();
    }
}
