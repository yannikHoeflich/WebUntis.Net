using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using Untis.Net.Results;
using Untis.Net.UntisObjects.Converter;

namespace Untis.Net.Test.Unit.UntisConverter;
internal class Date {
    private Dictionary<int, DateOnly?> _testCases;
    private UntisDateConverter _converter;

    [SetUp]
    public void SetUp() {
        _converter = new UntisDateConverter();
        _testCases = new Dictionary<int, DateOnly?>() {
            {-2023_12_01, null },
            {-1, null },
            {1, null },
            {2000_10_1, null},
            {2001_01, null },
            {2023_01_01_4, null },
            {2023_13_01, null },
            {2023_01_32, null},
            {2023_00_24 , null},
            {2023_02_29, null },
            {2023_04_00 , null},
            {2023_04_31, null },
            {2000_01_01, new DateOnly(2000, 1, 1) },
            {2008_06_26, new DateOnly(2008, 6, 26) },
            {2014_02_13, new DateOnly(2014, 02, 13) },
            {2023_01_31, new DateOnly(2023, 01, 31) },
            {2023_02_28, new DateOnly(2023, 2, 28) },
            {2023_04_30, new DateOnly(2023, 4, 30) },
            {2023_10_31, new DateOnly(2023, 10, 31) },
            {2023_12_01, new DateOnly(2023, 12, 1) },
            {2024_02_29, new DateOnly(2024, 02, 29) },
            {2025_09_12, new DateOnly(2025, 9, 12) },

        };
    }

    [Test]
    public void IntToDateOnly() {
        foreach(var testCase in _testCases) {
            int number = testCase.Key;
            DateOnly? expectedValue = testCase.Value;

            Result<DateOnly> result = _converter.ParseInt(number);

            if (result.TryGetError(out Exception? error) && expectedValue is not null) {
                Assert.Fail(ErrorMessage(testCase, error));
                continue;
            }

            if (expectedValue is null) {
                Assert.That(result.Success, Is.False);
                continue;
            }

            if(expectedValue is DateOnly expected) {
                if(!result.TryGetValue(out DateOnly value)) {
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
            DateOnly? unfilteredValue = testCase.Value;
            int expected_value = testCase.Key;

            if(unfilteredValue is not DateOnly value) {
                continue;
            }

            Result<int> result = _converter.ToInt(value);
            if(!result.TryGetValue(out int resultValue)) {
                if(result.TryGetError(out var ex)) {
                    Assert.Fail(ErrorMessage(testCase, ex));
                }

                Assert.Fail(ErrorMessage(testCase, "Unknown Error"));
            }

            Assert.That(resultValue, Is.EqualTo(expected_value), ErrorMessage(testCase, "Values is not what expected"));
        }
    }

    private static string ErrorMessage(KeyValuePair<int, DateOnly?> testCase, Exception? error) 
        => ErrorMessage(testCase, error?.Message ?? "Exception is NULL");

    private static string ErrorMessage(KeyValuePair<int, DateOnly?> testCase, string errorMessage)
        => $"{testCase.Key} <-> {testCase.Value?.ToString() ?? "Error"}: {errorMessage}";
}
