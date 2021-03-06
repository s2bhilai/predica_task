using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Management_Api.Extensions
{
    public static class StreamExtensions
    {
        public static T ReadAndDeserializeFromJson<T>(this Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            if (!stream.CanRead)
                throw new NotSupportedException("Cant read from this stream");

            using (var streamReader = new StreamReader(stream))
            {
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                    var jsonSerializer = new JsonSerializer();
                    return jsonSerializer.Deserialize<T>(jsonTextReader);
                }
            }
        }
    }
}
