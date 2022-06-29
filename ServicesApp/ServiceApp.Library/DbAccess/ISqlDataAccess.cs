﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceApp.Library.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
        Task SaveDataAsync<T>(string storedProcedire, T parameters, string connectionId = "Default");
        Task<IEnumerable<T>> LoadDataAsyncViews<T>(string view, string connectionId = "Default");
    }
}