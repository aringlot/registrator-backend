using System.Collections.Generic;

namespace Registrator.WebModels.Core
{
    public abstract class ResponseBase
    {
        protected ResponseBase()
        {
            Errors = new Dictionary<string, Dictionary<int, string>>();
        }

        public Dictionary<string, Dictionary<int, string>> Errors { get; private set; }
    }
}
