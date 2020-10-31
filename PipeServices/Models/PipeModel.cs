using PipeServices.Enums;
using PipeServices.Models;
using System.Collections.Generic;

namespace PipeServices
{
    public class PipeModel
    {
        public Dictionary<PipeAction, string> Result { get; set; } = new Dictionary<PipeAction, string>();
        public List<PipeError> Errors { get; set; } = new List<PipeError>();
    }
}
