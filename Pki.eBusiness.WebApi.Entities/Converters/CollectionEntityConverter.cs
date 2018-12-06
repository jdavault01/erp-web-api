using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Pki.eBusiness.WebApi.Entities.Converters
{
    public class CollectionEntityConverter<T, Tt> : JsonConverter where T : Tt
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IList<Tt>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            IList<Tt> items = serializer.Deserialize<List<T>>(reader).Cast<Tt>().ToList();
            return items;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(IList<T>));
        }
    }
}