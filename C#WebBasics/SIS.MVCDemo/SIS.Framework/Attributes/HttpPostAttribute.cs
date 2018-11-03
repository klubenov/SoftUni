﻿using System;
using SIS.Framework.Attributes.Contracts;

namespace SIS.Framework.Attributes
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToUpper() == "POST")
            {
                return true;
            }

            return false;
        }
    }
}
