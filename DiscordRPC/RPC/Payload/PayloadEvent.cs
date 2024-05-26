﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace DiscordRPC.RPC.Payload
{
	/// <summary>
	/// Used for Discord IPC Events
	/// </summary>
	internal class EventPayload : IPayload
    {
        private static readonly JsonSerializerOptions JsonOpts = new()
            { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault, NumberHandling = JsonNumberHandling.AllowReadingFromString };
        
		/// <summary>
		/// The data the server sent too us
		/// </summary>
		[JsonPropertyName("data")]
		public JsonElement Data { get; set; }

		/// <summary>
		/// The type of event the server sent
		/// </summary>
		[JsonPropertyName("evt"), JsonConverter(typeof(JsonStringEnumConverter<ServerEvent>))]
		public ServerEvent? Event { get; set; }

        /// <summary>
        /// Creates a payload with empty data
        /// </summary>
		public EventPayload() : base() {  }

        /// <summary>
        /// Creates a payload with empty data and a set nonce
        /// </summary>
        /// <param name="nonce"></param>
		public EventPayload(long nonce) : base(nonce) {  }
        
		/// <summary>
		/// Gets the object stored within the Data
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public T GetObject<T>()
		{
            return Data.Deserialize<T>(JsonOpts);
        }

        /// <summary>
        /// Converts the object into a human readable string
        /// </summary>
        /// <returns></returns>
		public override string ToString()
		{
			return "Event " + base.ToString() + ", Event: " + (Event.HasValue ? Event.ToString() : "N/A");
		}
	}
	

}
