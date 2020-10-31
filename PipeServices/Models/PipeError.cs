using PipeServices.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PipeServices.Models
{
    public class PipeError
    {
        public ErrorType ErrorType { get; set; }
        public string ErrorMessage { get; set; }
    }
}
