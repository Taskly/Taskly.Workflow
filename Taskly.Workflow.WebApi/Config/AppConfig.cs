namespace Taskly.Workflow.WebApi.Config
{
    public class AppConfig
    {
        public AppConfig()
        {
            Mongo = new MongoConfig();
        }

        public MongoConfig Mongo { get; }
    }
}
