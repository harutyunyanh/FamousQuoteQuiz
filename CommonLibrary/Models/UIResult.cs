using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class UIResult<T>
    {
        public UIResultStatus Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public UIResult(UIResultStatus status, T data)
        {
            this.Status = status;
            this.Data = data;
        }
        public UIResult(UIResultStatus status, Error error)
        {
            this.Status = status;
            this.Message = error.Code + error.Message;
        }
        public UIResult(UIResultStatus status, string message)
        {
            this.Status = status;
            this.Message = message;
        }
        public UIResult(UIResult<string> subResult)
        {
            Status = subResult.Status;
            Message = subResult.Message;
        }
        public bool IsSuccessful() => Status == UIResultStatus.Success;

        public UIResult()
        {
        }
    }
}
