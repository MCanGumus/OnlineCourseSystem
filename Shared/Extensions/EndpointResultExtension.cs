﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Extensions
{
    public static class EndpointResultExtension
    {
        public static IResult ToResult(this ServiceResult result)
        {
            return result.Status switch
            {
                HttpStatusCode.NoContent => Results.NoContent(),
                HttpStatusCode.NotFound => Results.NotFound(result.Fail!),
                _ => Results.Problem(result.Fail!)
            };
        }

        public static IResult ToResult<T>(this ServiceResult<T> result)
        {
            return result.Status switch
            {
                HttpStatusCode.OK => Results.Ok(),
                HttpStatusCode.Created => Results.Created(),
                HttpStatusCode.NotFound => Results.NotFound(result.Fail!),
                _ => Results.Problem(result.Fail!)
            };
        }
    }
}