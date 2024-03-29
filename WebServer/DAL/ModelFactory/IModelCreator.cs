﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebServer.DAL
{
    public interface IModelCreator<T>
    {
        T CreateModel(IDataReader source);
    }
}