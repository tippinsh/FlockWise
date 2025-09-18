using System.Net;

namespace FlockWise.Application.Models;

public sealed class Result<T>
{
    public int StatusCode { get; init; } = (int)HttpStatusCode.OK;
    public T? Data { get; private init; }
    public string? ErrorMessage { get; private init; }

    public bool IsSuccess => StatusCode is >= 200 and < 300 && string.IsNullOrEmpty(ErrorMessage);
    
    public static Result<T> Ok(T data, int statusCode = (int)HttpStatusCode.OK) =>
        new() { StatusCode = statusCode, Data = data };

    public static Result<T> Error(string message, int statusCode = (int)HttpStatusCode.BadRequest) =>
        new() { StatusCode = statusCode, ErrorMessage = message };

    public static Result<T> NotFound(string? message = null) =>
        new() { StatusCode = (int)HttpStatusCode.NotFound, ErrorMessage = message };
}
