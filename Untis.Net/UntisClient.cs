using System.Text;
using System.Text.Json;

using Untis.Net.Results;
using Untis.Net.UntisHttp.Requests;
using Untis.Net.UntisHttp.Responses;
using Untis.Net.UntisHttp.Responses.Homeworks;
using Untis.Net.UntisObjects;

namespace Untis.Net;
public class UntisClient : IAsyncDisposable {
    private readonly HttpClient _httpClient;
    private bool _isLoggedIn;
    private readonly RequestFactory _requestFactory;
    private SessionInformation _sessionInformation;

    public string SchoolName { get; }
    public string ClientName { get; }

    public UntisClient(string schoolName, string schoolUrl, string clientName = "WebUntisDotNet") {
        SchoolName = schoolName;
        ClientName = clientName;

        _httpClient = new HttpClient() {
            BaseAddress = new Uri($"https://{schoolUrl}/")
        };

        _requestFactory = new RequestFactory(clientName);
    }
    private async Task<Result<T>> Request<T>(Request request) {
        string json = request.ToJson();
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PostAsync($"WebUntis/jsonrpc.do?school={SchoolName}", content);
        if (!response.IsSuccessStatusCode) {
            return default;
        }

        string jsonResponse = await response.Content.ReadAsStringAsync();
        Result<SuccessResponse<T>> responseResult = Response.Parse<T>(jsonResponse);

        if(!responseResult.TryGetValue(out SuccessResponse<T>? responseValue)) {
            if (responseResult.TryToErrorResult(out Result<Results.ErrorResponse> errorResult)) {
                return errorResult;
            }

            return Result.Error("Unknown error");
        }

        if(responseValue is null || responseValue.Result is null) {
            return Result.Error("response value was NULL");
        }

        return Result.Ok( responseValue.Result);
    }


    private void ValidateOperation() {
        if (!_isLoggedIn) {
            throw new InvalidOperationException("You need to log in first with LoginAsync");
        }
    }

    private async Task<Result<T>> SimpleRequest<T>(string method) {
        ValidateOperation();

        Request request = _requestFactory.CreateRequest(method);
        return await Request<T>(request);
    }

    private async Task<Result<UntisTimeTable>> TimeTableRequest(ulong personId, int personType, DateOnly startDate, DateOnly endDate) {
        var options = new TimeTableRequestOptions() {
            Id = (ulong)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            StartDate = startDate,
            EndDate = endDate,
            User = new UntisUser() {
                Id = personId,
                Type = personType
            },
            ShowLsText = true,
            ShowStudentGroup = true,
            ShowLsNumber = true,
            ShowSubstText = true,
            ShowBooking = true,
            ShowInfo = true,

            ClassFields = new string[] { "id", "name", "longname", "externalkey" },
            RoomFields = new string[] { "id", "name", "longname", "externalkey" },
            SubjectFields = new string[] { "id", "name", "longname", "externalkey" },
            TeacherFields = new string[] { "id", "name", "longname", "externalkey" }
        };
        Request request = _requestFactory.CreateRequest("getTimetable")
                                     .AddParameter("options", options);

        Result<UntisTimeTablePart[]> partsResult = await Request<UntisTimeTablePart[]>(request);
        if(partsResult.TryToErrorResult(out Result<Results.ErrorResponse> errorResult)) {
            return errorResult;
        }

        UntisTimeTablePart[]? parts = partsResult.GetValueOrThrow();

        if(parts is null) {
            return Result.Error("Unknown Error");
        }

        return Result.Ok(new UntisTimeTable(parts));
    }

    /// <summary>
    /// Login to your untis account
    /// </summary>
    /// <param name="username">Your Untis username</param>
    /// <param name="password">Your Untis password</param>
    /// <returns><see langword="true"/> if the login was successful otherwise false</returns>
    public async Task<bool> LoginAsync(string username, string password) {
        Request request = _requestFactory.CreateRequest("authenticate")
                                     .AddParameter("user", username)
                                     .AddParameter("password", password)
                                     .AddParameter("client", ClientName);
        Result<SessionInformation> informationResult = await Request<SessionInformation>(request);

        if (!informationResult.TryGetValue(out SessionInformation? information) || information is null) {
            return false;
        }

        _sessionInformation = information;
        _isLoggedIn = true;
        return true;
    }

    /// <summary>
    /// Logs the client out of the account
    /// </summary>
    /// <returns><see langword="true"/> if the logout was successful otherwise false</returns>
    public async Task<bool> LogoutAsync() {
        Request request = _requestFactory.CreateRequest("logout");
        Result<object> requestResult = await Request<object>(request);
        if (!requestResult.Success) {
            return false;
        }

        _isLoggedIn = false;
        return true;
    }

    public Task<Result<UntisClass[]>> GetClassesAsync() => SimpleRequest<UntisClass[]>("getKlassen");
    public Task<Result<UntisRoom[]>> GetRoomsAsync() => SimpleRequest<UntisRoom[]>("getRooms");
    public async Task<Result<UntisHolidays[]>> GetHolidaysAsync() => await SimpleRequest<UntisHolidays[]>("getHolidays");
    public Task<Result<UntisTeacher[]>> GetTeachersAsync() => SimpleRequest<UntisTeacher[]>("getTeachers");
    public Task<Result<UntisStudent[]>> GetStudentsAsync() => SimpleRequest<UntisStudent[]>("getStudents");
    public Task<Result<UntisSubject[]>> GetSubjectsAsync() => SimpleRequest<UntisSubject[]>("getSubjects");

    public async Task<Result<UntisTimeTableDay>> GetTimetableForDateAsync(DateOnly date, ulong id = ulong.MaxValue, int type = int.MaxValue) {
        if (id == ulong.MaxValue)
            id = _sessionInformation.PersonId;
        if (type == int.MaxValue)
            type = _sessionInformation.PersonType;

        var result = await TimeTableRequest(id, type, date, date);
        if(!result.TryGetValue(out var value)) {
            if(result.TryToErrorResult(out var errorResult)) {
                return errorResult;
            }

            return Result.Error("Unknown Error");
        }

        return value.GetDay(date);
    }


    public async Task<Result<UntisTimeTable>> GetTimetableForRangeAsync(DateOnly rangeStart, DateOnly rangeEnd, ulong id = ulong.MaxValue, int type = int.MaxValue) {
        if (id == ulong.MaxValue)
            id = _sessionInformation.PersonId;
        if (type == int.MaxValue)
            type = _sessionInformation.PersonType;
        return await TimeTableRequest(id, type, rangeStart, rangeEnd);
    }

    public Task<Result<UntisTimeTableDay>> GetOwnClassTimetableForDateAsync(DateOnly date) => GetTimetableForDateAsync(date);
    public Task<Result<UntisTimeTable>> GetOwnClassTimetableForRangeAsync(DateOnly rangeStart, DateOnly rangeEnd) => GetTimetableForRangeAsync(rangeStart, rangeEnd);

    public async Task<Result<UntisTimeGrid>> GetTimegridAsync() {
        Result<UntisTimegridDay[]> daysResult = await SimpleRequest<UntisTimegridDay[]>("getTimegridUnits");

        if(!daysResult.TryGetValue(out var days)) {
            if(daysResult.TryToErrorResult(out var errorResult)) {
                return errorResult;
            }

            return Result.Error("Unknown Error");
        }

        return Result.Ok(new UntisTimeGrid() { Days = days });
    }

    public async Task<Result<UntisHomeWork[]>> GetHomeworksAsync(DateOnly rangeStart, DateOnly rangeEnd) {
        Result<UntisSubject[]> subjectsResult = await GetSubjectsAsync();
        if (!subjectsResult.TryGetValue(out UntisSubject[]? subjects) || subjects is null) { 
            if(subjectsResult.TryToErrorResult(out var errorResult)) {
                return errorResult;
            }

            return Result.Error("Unknown Error");
        }

        string url = $"/WebUntis/api/homeworks/lessons?startDate={UntisTimeConverter.ConvertDateToUntis(rangeStart)}&endDate={UntisTimeConverter.ConvertDateToUntis(rangeEnd)}";
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        HomeworkResponse? parsedContent = JsonSerializer.Deserialize<HomeworkResponse>(await response.Content.ReadAsStringAsync());
        if (parsedContent is null) {
            return Result.Error("Api returned NULL");
        }

        if (parsedContent.Data.Lessons is null) {
            return Result.Error("Api returned NULL for lessons");
        }

        UntisHomeWorkIntern[]? homeworks = parsedContent.Data.Homeworks;

        if(homeworks is null) {
            return Result.Error("Api returned NULL for homeworks");
        }

        IEnumerable<UntisHomeWork> parsedHomeworks = homeworks.Select(x => x.JoinLessonHomework(parsedContent.Data.Lessons, subjects))
                                                               .Where(x => x is not null);

        return Result.Ok(parsedHomeworks.ToArray());
    }

    async ValueTask IAsyncDisposable.DisposeAsync() {
        await LogoutAsync();
        _httpClient?.Dispose();
        GC.SuppressFinalize(this);
    }
}
