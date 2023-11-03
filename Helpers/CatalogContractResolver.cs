using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;
using TechnicalTask1_DotNetCourse.Models;

namespace TechnicalTask1_DotNetCourse.Helpers
{
    public class CatalogContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.DeclaringType == typeof(Catalog) && property.PropertyName == "CatalogId")
            {
                property.ShouldDeserialize = instance => false; 
            }

            return property;
        }
    }
}
