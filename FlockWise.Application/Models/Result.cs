using System.Net;

namespace FlockWise.Application.Models;

public sealed class Result<T>
{
    public int StatusCode { get; init; } = (int)HttpStatusCode.OK;
    public T? Data { get; init; }
    public string[] Errors { get; init; } = [];

    public bool IsSuccess => StatusCode is >= 200 and < 300 && Errors.Length == 0;
    
    public static Result<T> Ok(T data, int statusCode = (int)HttpStatusCode.OK) =>
        new() { StatusCode = statusCode, Data = data };

    public static Result<T> Error(string message, int statusCode = (int)HttpStatusCode.BadRequest) =>
        new() { StatusCode = statusCode, Errors = [message] };

    public static Result<T> NotFound(string? message = null) =>
        new() { StatusCode = (int)HttpStatusCode.NotFound, Errors = message is null ? [] : [message] };
}
