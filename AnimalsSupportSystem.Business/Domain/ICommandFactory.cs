﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsSupportSystem.Business.Domain
{
    public interface ICommandFactory
    {
        IMedicalCommand CreateCommand(object commandType);
    }
}
