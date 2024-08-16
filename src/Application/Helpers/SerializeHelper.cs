using System.Text.Json;

namespace Application.Helpers
{
    public static class SerializeHelper
    {
        public static async Task<byte[]> SerializeForFile<T>(T data)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
            };

            var jsonString = JsonSerializer.Serialize(data, options);

            var bytes = System.Text.Encoding.UTF8.GetBytes(jsonString);

            return await Task.FromResult(bytes);
        }
    }
}
