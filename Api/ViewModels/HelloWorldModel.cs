using Newtonsoft.Json;

namespace Api.ViewModels
{
    /// <summary>
    /// Class HelloWorldModel.
    /// </summary>
    public class HelloWorldModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}