using System.Text.Json;
using System.Text.Json.Serialization;

namespace DiscordRPC.RPC.Payload;

/// <summary>
/// The payload that is sent by the client to discord for events such as setting the rich presence.
/// <para>
/// SetPrecense
/// </para>
/// </summary>
internal class ArgumentPayload : IPayload
{
    /// <summary>
    /// The data the server sent too us
    /// </summary>
    [JsonPropertyName("args")]
    public JsonElement Arguments { get; set; }
		
    public ArgumentPayload() {  }
    public ArgumentPayload(long nonce) : base(nonce) { }
    public ArgumentPayload(object args, long nonce) : base(nonce)
    {
        SetObject(args);
    }

    /// <summary>
    /// Sets the object stored within the data.
    /// </summary>
    /// <param name="obj"></param>
    public void SetObject(object obj)
    {
        Arguments = JsonSerializer.SerializeToElement(obj);
    }

    /// <summary>
    /// Gets the object stored within the Data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetObject<T>()
    {
        return Arguments.Deserialize<T>();
    }

    public override string ToString()
    {
        return "Argument " + base.ToString();
    }
}