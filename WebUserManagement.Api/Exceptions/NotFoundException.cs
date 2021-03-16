﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUserManagement.Api.Exceptions
{
    public class NotFoundException : CustomApiException
    {
        public NotFoundException(string message) : base(StatusCode.NotFound, message)
        {
        }
    }
}