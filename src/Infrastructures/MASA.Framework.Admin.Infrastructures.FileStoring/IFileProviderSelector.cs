﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASA.Framework.Admin.Infrastructure.FileStoring
{
    public interface IFileProviderSelector
    {
        IFileProvider Get(string containerName);
    }
}
