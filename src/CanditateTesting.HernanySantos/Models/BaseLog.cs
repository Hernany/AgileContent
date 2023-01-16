using FluentValidation.Results;

namespace CanditateTesting.HernanySantos.Models
{
    public abstract class BaseLog
    {
        public string? HttpMethod { get; set; }
        public int StatusCode { get; set; }
        public string? UriPath { get; set; }
        public string? TimeTaken { get; set; }
        public int ResponseSize { get; set; }
        public string? CacheStatus { get; set; }
        public ValidationResult ValidationResult { get; protected set; }
        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}