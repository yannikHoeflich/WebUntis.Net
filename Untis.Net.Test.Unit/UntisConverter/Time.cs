using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using Untis.Net.Results;
using Untis.Net.UntisObjects.Converter;

namespace Untis.Net.Test.Unit.UntisConverter;
internal class Time {
    private Dictionary<int, TimeOnly?> _testCases;
    private UntisTimeConverter _converter;

    [SetUp]
    public void SetUp() {
        _converter = new UntisTimeConverter();
        _testCases = new Dictionary<int, TimeOnly?>() {
            {-13_12, null },
            {-1, null },
            {24_01, null },
            {25_15, null },
            {12_61, null },
            {12_65, null },
            {24_00, null },
            {00_00, new TimeOnly(0, 0) },
            {00_01, new TimeOnly(0, 1) },
            {13_12, new TimeOnly(13, 12) },
            {09_15, new TimeOnly(9, 15) },
            {21_59, new TimeOnly(21, 59) },
            {23_59, new TimeOnly(23, 59) },
            {01_59, new TimeOnly(1, 59) },
        };
    }

    [Test]
    public void IntToDateOnly() {
        foreach (var testCase in _testCases) {
            int number = testCase.Key;
            TimeOnly? expectedValue = testCase.Value;

            Result<TimeOnly> result = _converter.ParseInt(number);

            if (result.TryGetError(out Exception? error) && expectedValue is not null) {
                Assert.Fail(ErrorMessage(testCase, error));
                continue;
            }

            if (expectedValue is null) {
                Assert.That(result.Success, Is.False);
                continue;
            }

            if (expectedValue is TimeOnly expected) {
                if (!result.TryGetValue(out TimeOnly value)) {
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
            TimeOnly? unfilteredValue = testCase.Value;
            int expected_value = testCase.Key;

            if (unfilteredValue is not TimeOnly value) {
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

    private static string ErrorMessage(KeyValuePair<int, TimeOnly?> testCase, Exception? error)
        => ErrorMessage(testCase, error?.Message ?? "Exception is NULL");

    private static string ErrorMessage(KeyValuePair<int, TimeOnly?> testCase, string errorMessage)
        => $"{testCase.Key} <-> {testCase.Value?.ToString() ?? "Error"}: {errorMessage}";
}
