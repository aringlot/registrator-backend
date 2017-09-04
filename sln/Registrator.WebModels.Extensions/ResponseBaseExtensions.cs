using System.Collections.Generic;
using Registrator.WebModels.Core;

namespace Registrator.WebModels.Extensions
{
    public static class ResponseBaseExtensions
    {
        public static T AddModelError<T>(this T response, string field, int code, string description)
            where T : ResponseBase
        {
            if (!response.Errors.ContainsKey(field))
            {
                response.Errors.Add(field, new Dictionary<int, string>());
            }

            if (!response.Errors[field].ContainsKey(code))
            {
                response.Errors[field].Add(code, description);
            }
            else
            {
                response.Errors[field][code] = description;
            }

            return response;
        }
    }
}
