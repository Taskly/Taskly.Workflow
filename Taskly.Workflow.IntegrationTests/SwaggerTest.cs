using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taskly.Workflow.WebApi;

namespace Taskly.Workflow.IntegrationTests
{
    [TestClass]
    public class SwaggerTest
    {
        [TestMethod]
        public async Task SwaggerResponseIsCorrect()
        {
            var factory = new WebApplicationFactory<Startup>();
            HttpClient client = factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/swagger");
            response.EnsureSuccessStatusCode();

            response = await client.GetAsync("/api-docs/swagger/v1.0/swagger.json");
            var responseString = await response.Content.ReadAsStringAsync();

            string infoTitle;
            using (JsonDocument document = JsonDocument.Parse(responseString))
            {
                infoTitle = document.RootElement.GetProperty("info").GetProperty("title").GetString();
            }

            Assert.AreEqual("WorkflowService API", infoTitle);
        }
    }
}
