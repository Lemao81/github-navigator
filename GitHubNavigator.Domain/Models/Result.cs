namespace GitHubNavigator.Domain.Models;

public sealed class Result<T>
{
    private Result()
    {
    }

    public T? Value { get; set; }
    public string? Error { get; set; }

    public bool IsSuccess => Value is not null;

    public static Result<T> Success(T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));

        return new Result<T> { Value = value };
    }

    public static Result<T> Failure(string error)
    {
        if (error == null) throw new ArgumentNullException(nameof(error));

        return new Result<T> { Error = error };
    }
}
