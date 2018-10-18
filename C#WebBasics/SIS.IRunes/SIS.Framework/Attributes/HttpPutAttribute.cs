﻿using System;
using SIS.Framework.Attributes.Contracts;

namespace SIS.Framework.Attributes
{
    public class HttpPutAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToUpper() == "PUT")
            {
                return true;
            }

            return false;
        }
    }
}
