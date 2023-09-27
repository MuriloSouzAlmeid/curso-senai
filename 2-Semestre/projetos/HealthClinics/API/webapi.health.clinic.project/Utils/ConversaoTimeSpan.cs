using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace webapi.health.clinic.project.Utils
{
    public class ConversaoTimeSpan : Newtonsoft.Json.JsonConverter<TimeSpan>
    {

        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                // Você pode ajustar o formato de serialização aqui, dependendo do formato em que os TimeSpan estão no JSON.
                var timeSpanString = (string)reader.Value!;
                if (TimeSpan.TryParse(timeSpanString, out var timeSpan))
                {
                    return timeSpan;
                }
            }

            return TimeSpan.Zero; // ou outro valor padrão, se necessário
        }


        public override void WriteJson(JsonWriter writer, TimeSpan value, Newtonsoft.Json.JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString()); // Serializa TimeSpan como uma string
        }
    }
}
