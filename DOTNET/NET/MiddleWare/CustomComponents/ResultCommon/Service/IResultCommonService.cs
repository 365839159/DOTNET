using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomComponents.ResultCommon.Service
{
    public interface IResultCommonService
    {
        ObjectResult ResultCommon(object obj);
    }
}
