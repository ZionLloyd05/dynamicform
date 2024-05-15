using System.Diagnostics.CodeAnalysis;

namespace DynamicForm.Bases;

public record Result<T>
{

    [MemberNotNullWhen(true, "Error")]
    [MemberNotNullWhen(false, "Value")]
    public bool HasError
    {
        [MemberNotNullWhen(true, "Error")]
        [MemberNotNullWhen(false, "Value")]
        get
        {
            return Error != null;
        }
    }

    public T? Value { get; }

    public Error? Error { get; }

    private Result(T value)
    {
        Value = value;
        Error = null;
    }

    public Result(Error error)
    {
        Error = error;
        Value = default(T);
    }

    public static Result<T> Create(T value)
    {
        return new Result<T>(value);
    }

    public static implicit operator Result<T>(T value)
    {
        return new Result<T>(value);
    }

    public static implicit operator Result<T>(Error error)
    {
        return new Result<T>(error);
    }
}

public record Result
{

    [MemberNotNullWhen(true, "Error")]
    public bool HasError
    {
        [MemberNotNullWhen(true, "Error")]
        get
        {
            return Error != null;
        }
    }

    public Error? Error { get; }

    private Result()
    {
    }

    private Result(Error error)
    {
        Error = error;
    }

    public static implicit operator Result(Error error)
    {
        return new Result(error);
    }

    public static implicit operator Result(Success _)
    {
        return new Result();
    }
