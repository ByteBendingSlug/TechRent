﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechRent.Entities;

namespace TechRent.Shared.FeatureContracts
{
    public interface ICreateCommand
    {
        Task Execute(Item item);
    }
}