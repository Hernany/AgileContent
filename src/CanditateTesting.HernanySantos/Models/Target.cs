namespace CanditateTesting.HernanySantos.Models
{
    public class Target : BaseLog
    {
        private readonly string PROVIDER = "MINHA CDN";
        public string? Provider { get; private set; }

        public Target ToTarget(Source source) 
        {
            var uriPathFormat = FormatUriPath(source.UriPath);

            return new Target
            {
                Provider = FormatProvider(PROVIDER),
                ResponseSize = source.ResponseSize,
                StatusCode = source.StatusCode,
                HttpMethod = uriPathFormat != null ? uriPathFormat[0] : null,
                UriPath = uriPathFormat != null ? uriPathFormat[1] : null,
                TimeTaken = source.TimeTaken,
                CacheStatus = source.CacheStatus
            };
        }

        public string? FormatProvider(string? data) 
        {
            return $"\"{data}\" ";
        }

        public string[]? FormatUriPath(string? data) 
        {
            data = data.Replace("\"", "");
            var result = data.Split(' ');
            return data != null ? result : null;
        }

        public string ToFormatLog() 
        {
            return $@"{this.Provider}  {this.HttpMethod}  {this.StatusCode}  {this.UriPath}  {this.TimeTaken}  {this.ResponseSize} {this.CacheStatus}";
        }
    }
}