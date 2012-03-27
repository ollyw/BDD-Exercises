﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperStoneScissors
{
    [Serializable]
    public class GameNotCompletedException : Exception
    {
        public GameNotCompletedException() { }
        public GameNotCompletedException(string message) : base(message) { }
        public GameNotCompletedException(string message, Exception inner) : base(message, inner) { }
        protected GameNotCompletedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
