﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperStoneScissors
{
    [Serializable]
    public class GameAlreadyCompletedException : Exception
    {
        public GameAlreadyCompletedException() { }
        public GameAlreadyCompletedException(string message) : base(message) { }
        public GameAlreadyCompletedException(string message, Exception inner) : base(message, inner) { }
        protected GameAlreadyCompletedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}