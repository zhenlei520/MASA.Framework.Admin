﻿namespace MASA.Framework.Admin.Service.Dictionary.Application.Dic.Commands
{
    public record AddDicCommand(Domain.Entities.Dic Dic) : Command
    {
        public Domain.Entities.Dic Result { get; set; } = default!;
    }
}
