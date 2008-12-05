//using System.Configuration;
//using FluentNHibernate.AutoMap;
//using FluentNHibernate.Cfg;
//using Configuration=NHibernate.Cfg.Configuration;

//namespace Snacks
//{
//    public static class ApplicationStartup
//    {
//        public static void Run()
//        {
//            InitializeNHibernate();
//        }

//        private static void InitializeNHibernate()
//        {
//            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
//            var config = MsSqlConfiguration.MsSql2005
//                .ConnectionString.Is(connectionString)
//                .UseReflectionOptimizer()
//                .Cache.UseQueryCache()
//                .ConfigureProperties(new Configuration());


//            var persistenceModel = AutoPersistenceModel
//                .MapEntitiesFromAssemblyOf<Snack>()
//                .Where(t => t.Namespace == "Snacks.Entities");
//            persistenceModel.Configure(config);
//        }
//    }
//}