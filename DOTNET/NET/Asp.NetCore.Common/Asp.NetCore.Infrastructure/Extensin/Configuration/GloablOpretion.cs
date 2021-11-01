using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Asp.NetCore.Infrastructure.Extensin
{
    public class GloablOpretion
    {
        public static IConfiguration Configuration { get; set; }
    }
}