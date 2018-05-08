using Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Api.Controllers
{
    /// <summary>
    /// Class HelloWorldController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class HelloWorldController : Controller
    {
        /// <summary>
        /// Initializes static members of the <see cref="HelloWorldController"/> class.
        /// </summary>
        static HelloWorldController()
        {
            Hellos = new List<HelloWorldModel>();
        }

        /// <summary>
        /// Gets or sets the hellos.
        /// </summary>
        /// <value>The hellos.</value>
        private static ICollection<HelloWorldModel> Hellos { get; set; }

        /// <summary>
        /// Gets the hellos.
        /// </summary>
        /// <returns>A collection of hellos.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<HelloWorldModel>), 200)]
        [SwaggerOperation(operationId: "GetHelloWorlds")]
        public IActionResult Get()
        {
            return this.Ok(Hellos);
        }

        /// <summary>
        /// Posts the specified name to create a hello.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>A instance of a hello.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(HelloWorldModel), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [SwaggerOperation(operationId: "CreateHelloWorld")]
        public IActionResult Post([FromBody]string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return this.BadRequest("name is required.");
            }

            var helloWorldModel = new HelloWorldModel()
            {
                Name = name,
                Message = $"Hello, {name}! How do you do?"
            };

            Hellos.Add(helloWorldModel);

            return this.Ok(helloWorldModel);
        }
    }
}