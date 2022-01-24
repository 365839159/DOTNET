namespace ElasticSearchSample.ElasticProvider
{
    public static class ElasticExtend
    {
        public static void AddElasticService(this IServiceCollection services)
        {
            services.AddSingleton<IElasticProvider, ElasticProvider>();
        }
    }
}
