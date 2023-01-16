using System.Text;
using CanditateTesting.HernanySantos.Models;

namespace CanditateTesting.HernanySantos.Helpers
{
    public static class Mapper
    {
        public static List<Target> ConvertToAgora(string data) 
        {
            return ConvertToTarget(ConvertToSource(data));
        }

        public static List<Source> ConvertToSource(string responseData) 
        {
            var lstSource = new List<Source>();

            string[] lines = responseData.Split(
                new string[] {Environment.NewLine},
                StringSplitOptions.None
            );

            foreach (string item in lines) 
            {
                if (string.IsNullOrEmpty(item) == false) 
                {
                    lstSource.Add(new Source().ToSource(item));
                }
            }

            return lstSource;
        }

        public static List<Target> ConvertToTarget(List<Source> lstSource) 
        {
            var lstTarget = new List<Target>();

            if(lstSource?.Any()==true)
            {
                foreach (var source in lstSource) 
                {
                    lstTarget.Add(new Target().ToTarget(source));
                }
            }

            return lstTarget;
        }

        public static string ConvertToText(List<Target> lstTarget) 
        {
            var targetText = new StringBuilder();

            foreach (var target in lstTarget) 
            {
                targetText.AppendLine(target.ToFormatLog());
            }

            return targetText.ToString();
        }
    }
}