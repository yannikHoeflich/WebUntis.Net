namespace Untis.Net.Results;
public readonly struct Result<T>{
    private readonly T? _value;
    private readonly Exception? _error;
    public bool Success { get; }

    public static implicit operator Result<T>(Result<ErrorResponse> result) => new(result._error);

    internal Result(T value) {
        Success = true;
        _value = value;
    }

    internal Result(Exception error) {
        Success = false;
        _error = error;
    }

    public T? GetValueOrThrow() {
        return Success
            ? _value
            : throw _error;
    }

    public bool TryGetValue(out T? value) {
        if (!Success) {
            value = default;
            return false;
        }

        value = _value;
        return true;
    }

    public bool TryGetError(out Exception? error) {
        if (Success) {
            error = null;
            return false;
        }

        error = _error;
        return true;
    }

    public bool TryToErrorResult(out Result<ErrorResponse> result) {
        if (Success || _error is null) {
            result = default;
            return false;
        }

        result = new Result<ErrorResponse>(_error);
        return true;
    }
}
