using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MovieAssignmentTest.Models
{
    public class MovieModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string? Title { get; set; }

        //[Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }

        [Range(0, 10, ErrorMessage = "Rating should be between 0 and 10.")]
        public float Rating { get; set; }
        public string? Image { get; set; }

        [JsonProperty("created_at")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime UpdatedAt { get; set; }
    }

    public class JsonDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return DateTime.MinValue;

            if (DateTime.TryParseExact(reader.Value.ToString(), "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                return result;

            return DateTime.MinValue;
        }

        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
