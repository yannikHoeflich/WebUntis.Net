using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Untis.Net.Results;
public readonly partial struct Result {
    public static Result<SuccessResponse> Ok() => new(new SuccessResponse());
    public static Result<T> Ok<T>(T value) => new(value);
    public static Result<ErrorResponse> Error(Exception error) => new(error);
    public static Result<ErrorResponse> Error(string error) => new(new TextException(error));
}
