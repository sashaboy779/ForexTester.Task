using MongoDB.Bson.Serialization.Conventions;

namespace ProjectAPI.Configurations
{
    public class MongoDBConfigurator
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            RegisterSettings(builder);
            SetUpCamelCaseConvention();
        }

        private static void RegisterSettings(WebApplicationBuilder builder)
        {
            builder.Services.Configure<MongoDBSettings>(
                options =>
                {
                    options.ConnectionString = builder.Configuration.GetSection("MongoDb:ConnectionString").Value;
                    options.Database = builder.Configuration.GetSection("MongoDb:Database").Value;
                });
        }

        private static void SetUpCamelCaseConvention()
        {
            var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);
        }
    }
}
