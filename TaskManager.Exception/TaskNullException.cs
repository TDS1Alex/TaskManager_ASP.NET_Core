using System;

namespace TaskManager.Exceptions
{
    public class TaskNullException : Exception
    {
        public TaskNullException(string message)
            : base(message) { }
    }
}
