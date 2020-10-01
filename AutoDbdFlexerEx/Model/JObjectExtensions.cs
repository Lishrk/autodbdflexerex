using Newtonsoft.Json.Linq;

namespace AutoDbdFlexerEx.Model
{
    public static class JObjectExtensions
    {
        public static void AddOrReplace(this JObject jObject, string propertyName, JToken value)
        {
            jObject.Remove(propertyName);
            jObject.Add(propertyName, value);
        }
    }
}
