using FluentValidation;

namespace CanditateTesting.HernanySantos.Models
{
    public class Source : BaseLog
    {
        public Source ToSource(string model) 
        {
            var sourceFormat = FormatData(model);

            return new Source
            {
                ResponseSize = Convert.ToInt32(sourceFormat[0]),
                StatusCode = Convert.ToInt32(sourceFormat[1]),
                CacheStatus = sourceFormat[2],
                UriPath = sourceFormat[3], // Quebrar
                TimeTaken = sourceFormat[4],
            };
        }

        public string[] FormatData(string data) 
        {
            return data.Split('|');
        }

        public override bool IsValid() 
        {
            return new SourceValidation().Validate(this).IsValid;
        }
    }

    public class SourceValidation : AbstractValidator<Source> 
    {
        public SourceValidation()
        {
            RuleFor(source => source.ResponseSize)
                .NotEmpty();
            RuleFor(source => source.StatusCode)
                .NotEmpty();
            RuleFor(source => source.CacheStatus)
                .NotEmpty();
            RuleFor(source => source.UriPath)
                .NotEmpty();
            RuleFor(source => source.TimeTaken)
                .NotEmpty();
        }

        public static bool ValidateStatusCode(string value) 
        {
            int statusCode;
            return Int32.TryParse(value, out statusCode);
        }
    }
}