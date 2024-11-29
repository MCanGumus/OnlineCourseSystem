using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared
{
    public class ServiceResult
    {
        [JsonIgnore] public HttpStatusCode Status { get; set; }
        public Microsoft.AspNetCore.Mvc.ProblemDetails? Fail { get; set; }
        [JsonIgnore] public bool IsSuccess => Fail is null;
        [JsonIgnore] public bool IsFail => !IsSuccess;

        public static ServiceResult SuccessAsNoContent()
        {
            return new ServiceResult { Status = HttpStatusCode.NoContent };
        }

        public static ServiceResult ErrorAsNotFound()
        {
            return new ServiceResult
            {
                Fail = new Microsoft.AspNetCore.Mvc.ProblemDetails { Title = "Not Found", Detail = "The requested resource was not found." },
                Status = HttpStatusCode.NotFound
            };
        }

        public static ServiceResult ErrorFromProblemDetails(ApiException exception)
        {
            if (string.IsNullOrEmpty(exception.Content))
            {
                return new ServiceResult
                {
                    Fail = new Microsoft.AspNetCore.Mvc.ProblemDetails() { Title = exception.Message },
                    Status = exception.StatusCode,
                };
            }

            var problemDetails =
                JsonSerializer.Deserialize<Microsoft.AspNetCore.Mvc.ProblemDetails>(exception.Content, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });

            return new ServiceResult
            {
                Fail = problemDetails,
                Status = exception.StatusCode,
            };
        }

        public static ServiceResult Error(Microsoft.AspNetCore.Mvc.ProblemDetails problemDetails, HttpStatusCode statusCode)
        {
            return new ServiceResult
            {
                Fail = problemDetails,
                Status = statusCode,
            };
        }

        public static ServiceResult Error(string title, string description, HttpStatusCode statusCode)
        {
            return new ServiceResult
            {
                Fail = new Microsoft.AspNetCore.Mvc.ProblemDetails
                {
                    Title = title,
                    Detail = description,
                    Status = statusCode.GetHashCode()
                },
                Status = statusCode,
            };
        }

        public static ServiceResult Error(string title, HttpStatusCode statusCode)
        {
            return new ServiceResult
            {
                Fail = new Microsoft.AspNetCore.Mvc.ProblemDetails
                {
                    Title = title,
                    Status = statusCode.GetHashCode()
                },
                Status = statusCode,
            };
        }

        public static ServiceResult ErrorFromValidation(IDictionary<string, object> errors)
        {
            return new ServiceResult
            {
                Fail = new Microsoft.AspNetCore.Mvc.ProblemDetails
                {
                    Title = "Validation errors occured.",
                    Detail = "Please chect the errors property for more details",
                    Extensions = errors,
                    Status = HttpStatusCode.BadRequest.GetHashCode()
                },
                Status = HttpStatusCode.BadRequest,
            };
        }

    }

    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }
        public string? UrlAsCreated { get; set; }

        public static ServiceResult<T> SuccessAsOk(T Data)
        {
            return new ServiceResult<T>
            {
                Status = HttpStatusCode.OK,
                Data = Data
            };
        }

        public static ServiceResult<T> SuccessAsCreated(T Data, string url)
        {
            return new ServiceResult<T>
            {
                UrlAsCreated = url,
                Status = HttpStatusCode.Created,
                Data = Data
            };
        }

        public new static ServiceResult<T> ErrorFromProblemDetails(ApiException exception)
        {
            if (string.IsNullOrEmpty(exception.Content))
            {
                return new ServiceResult<T>
                {
                    Fail = new Microsoft.AspNetCore.Mvc.ProblemDetails() { Title = exception.Message },
                    Status = exception.StatusCode,
                };
            }

            var problemDetails =
                JsonSerializer.Deserialize<Microsoft.AspNetCore.Mvc.ProblemDetails>(exception.Content, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });

            return new ServiceResult<T>
            {
                Fail = problemDetails,
                Status = exception.StatusCode,
            };
        }
        
        public new static ServiceResult<T> Error(Microsoft.AspNetCore.Mvc.ProblemDetails problemDetails, HttpStatusCode statusCode)
        {
            return new ServiceResult<T>
            {
                Fail = problemDetails,
                Status = statusCode,
            };
        }
        
        public new static ServiceResult<T> Error(string title, string description, HttpStatusCode statusCode)
        {
            return new ServiceResult<T>
            {
                Fail = new Microsoft.AspNetCore.Mvc.ProblemDetails{ 
                    Title = title,
                    Detail = description,
                    Status = statusCode.GetHashCode()
                },
                Status = statusCode,
            };
        }
        
        public new static ServiceResult<T> Error(string title, HttpStatusCode statusCode)
        {
            return new ServiceResult<T>
            {
                Fail = new Microsoft.AspNetCore.Mvc.ProblemDetails
                {
                    Title = title,
                    Status = statusCode.GetHashCode()
                },
                Status = statusCode,
            };
        }
        
        public new static ServiceResult<T> ErrorFromValidation(IDictionary<string, object> errors)
        {
            return new ServiceResult<T>
            {
                Fail = new Microsoft.AspNetCore.Mvc.ProblemDetails
                {
                    Title = "Validation errors occured.",
                    Detail = "Please chect the errors property for more details",
                    Extensions = errors,
                    Status = HttpStatusCode.BadRequest.GetHashCode()
                },
                Status = HttpStatusCode.BadRequest,
            };
        }
    }
}
