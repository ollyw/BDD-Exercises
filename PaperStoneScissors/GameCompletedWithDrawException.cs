using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperStoneScissors
{
    [Serializable]
    public class GameCompletedWithDrawException : Exception
    {
        public GameCompletedWithDrawException() { }
        public GameCompletedWithDrawException(string message) : base(message) { }
        public GameCompletedWithDrawException(string message, Exception inner) : base(message, inner) { }
        protected GameCompletedWithDrawException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
