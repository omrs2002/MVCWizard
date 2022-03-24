using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MVCWizard.Api.Extensions
{
    public static class JsonHelper
    {
        public static T? DynamicDeserialization<T>(string Json, string TokenName) where T : class
        {
            dynamic? data = JsonConvert.DeserializeObject(Json);
            JContainer? Jdata = data;
            if (Jdata != null & Jdata?.Count > 0)
            {
                var SelectedObject = Jdata?.SelectToken(TokenName)?.ToObject<T>();
                return SelectedObject;
            }

            return default;
        }

    }
}
