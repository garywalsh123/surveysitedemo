using System.Runtime.Serialization;

namespace SurveySite.Infrastructure
{
    public class SurveyException : Exception
    {
        public SurveyException()
        {
        }

        public SurveyException(string message) : base(message)
        {
        }

        public SurveyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SurveyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
