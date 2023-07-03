using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Untis.Net.Results;
public class TextException : Exception {
    public TextException(string? message) : base(message) {
    }
}
