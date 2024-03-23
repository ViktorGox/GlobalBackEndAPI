﻿using GlobalBackEndAPI.RegressionTesting.Models;

namespace GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces
{
    public interface IModuleRepository
    {
        ICollection<Module> GetModules();
        Module GetModule(int id);
    }
}