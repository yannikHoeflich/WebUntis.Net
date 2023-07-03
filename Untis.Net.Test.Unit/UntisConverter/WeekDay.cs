using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using Untis.Net.Results;
using Untis.Net.UntisObjects.Converter;

namespace Untis.Net.Test.Unit.UntisConverter;
internal class WeekDay {
    private Dictionary<int, DayOfWeek?> _testCases;
    private UntisDayOfWeekConverter _converter;

    [SetUp]
    public void SetUp() {
        _converter = new UntisDayOfWeekConverter();
        _testCases = new Dictionary<int, DayOfWeek?>() {
            {-1, null },
            {8, null},
            {0, DayOfWeek.Monday },
            {1, DayOfWeek.Tuesday },
            {2, DayOfWeek.Wednesday },
            {3, DayOfWeek.Thursday },
            {4, DayOfWeek.Friday },
            {5, DayOfWeek.Saturday },
            {6, DayOfWeek.Sunday },
        };
    }

    [Test]
    public void IntToDateOnly() {
        foreach (var testCase in _testCases) {
            int number = testCase.Key;
            DayOfWeek? expectedValue = testCase.Value;

            Result<DayOfWeek> result = _converter.ParseInt(number);

            if (result.TryGetError(out Exception? error) && expectedValue is not null) {
                Assert.Fail(ErrorMessage(testCase, error));
                continue;
            }

            if (expectedValue is null) {
                Assert.That(result.Success, Is.False);
                continue;
            }

            if (expectedValue is DayOfWeek expected) {
                if (!result.TryGetValue(out DayOfWeek value)) {
                    Assert.Fail(ErrorMessage(testCase, "Unknown error"));
                }

                Assert.That(value, Is.EqualTo(expected), ErrorMessage(testCase, "Values not equal"));
                continue;
            }

            Assert.Fail(ErrorMessage(testCase, "Unknown error"));
        }
    }

    [Test]
    public void DateOnlyToInt() {
        foreach (var testCase in _testCases) {
            DayOfWeek? unfilteredValue = testCase.Value;
            int expected_value = testCase.Key;

            if (unfilteredValue is not DayOfWeek value) {
                continue;
            }

            Result<int> result = _converter.ToInt(value);
            if (!result.TryGetValue(out int resultValue)) {
                if (result.TryGetError(out var ex)) {
                    Assert.Fail(ErrorMessage(testCase, ex));
                }

                Assert.Fail(ErrorMessage(testCase, "Unknown Error"));
            }

            Assert.That(resultValue, Is.EqualTo(expected_value), ErrorMessage(testCase, "Values is not what expected"));
        }
    }

    private static string ErrorMessage(KeyValuePair<int, DayOfWeek?> testCase, Exception? error)
        => ErrorMessage(testCase, error?.Message ?? "Exception is NULL");

    private static string ErrorMessage(KeyValuePair<int, DayOfWeek?> testCase, string errorMessage)
        => $"{testCase.Key} <-> {testCase.Value?.ToString() ?? "Error"}: {errorMessage}";
}
