using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;
using Untis.Net.Results;

namespace Untis.Net.UntisHttp.Responses;
internal class Response {
    [JsonPropertyName("jsonrpc")]
    public string? Jsonrpc { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    public static Result<SuccessResponse<T>> Parse<T>(string json) {
        try {
            SuccessResponse<T>? result = JsonSerializer.Deserialize<SuccessResponse<T>>(json);

            if(result is null) {
                return Result.Error("The response was NULL");
            }

            return Result.Ok(result);
        } catch {
            ErrorResponse? errorResponse = null;
            try {
                errorResponse = JsonSerializer.Deserialize<ErrorResponse>(json);
            } catch {
                return Result.Error("Invalid Json");
            }

            return Result.Error(errorResponse.Id);
        }
    }
}
