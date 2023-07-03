using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using Untis.Net.Results;

namespace Untis.Net.Test.Unit;
internal class Results {

    [Test]
    public void TextErrorResult() {
        var result = Result.Error("Test 123");

        Assert.Multiple(() => {
            Assert.That(result.Success, Is.False);
            Assert.That(result.TryGetError(out Exception? exception), Is.True);
            Assert.That(exception is TextException, Is.True);
            Assert.That(exception.Message, Is.EqualTo("Test 123"));
        });
    }

    [Test]
    public void ExceptionErrorResult() {
        var argumentException = new ArgumentException("Test 123");
        var result = Result.Error(argumentException);
        Assert.Multiple(() => {
            Assert.That(result.Success, Is.False);
            Assert.That(result.TryGetError(out Exception? exception), Is.True);
            Assert.That(exception is ArgumentException, Is.True);
            Assert.That(exception.Message, Is.EqualTo("Test 123"));
        });
    }

    [Test]
    public void ErrorResponseResult() {
        var result = Result.Error("Test 123");

        Assert.Multiple(() => {
            Assert.That(result.TryToErrorResult(out Result<ErrorResponse> errorResponse), Is.True);
            Assert.That(errorResponse.Success, Is.False);
            Assert.That(errorResponse.TryGetError(out Exception? exception), Is.True);
            Assert.That(exception is TextException, Is.True);
            Assert.That(exception.Message, Is.EqualTo("Test 123"));
        });
    }

    [Test]
    public void ValueOkResult() {
        var result = Result.Ok(420);
        Assert.Multiple(() => {
            Assert.That(result.Success, Is.True);
            Assert.That(result.TryGetValue(out int value), Is.True);
            Assert.That(value, Is.EqualTo(420));

            Assert.That(result.TryGetError(out _), Is.False);
            Assert.That(result.TryToErrorResult(out _), Is.False);
        });
    }

    [Test]
    public void EmptyOkResult() {
        var result = Result.Ok();
        Assert.Multiple(() => {
            Assert.That(result.Success, Is.True);
            Assert.That(result.TryGetValue(out SuccessResponse? value), Is.True);
            Assert.That(value, Is.Not.Null);
            Assert.That(value?.Success, Is.True);

            Assert.That(result.TryGetError(out _), Is.False);
            Assert.That(result.TryToErrorResult(out _), Is.False);
        });
    }
}
