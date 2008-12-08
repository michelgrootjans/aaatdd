using System.Configuration;
using FluentNHibernate.AutoMap;
using FluentNHibernate.Cfg;
using Snacks.Domain;
using Snacks.Domain.Entities;
using Snacks.Presentation;
using Utilities.Containers;
using Utilities.Repository;
using Configuration=NHibernate.Cfg.Configuration;

namespace Snacks
{
    public static class ApplicationStartup
    {
        public static void Run()
        {
            InitializeNHibernate();
            InitializeContainer(InitializeRepository());
        }

        private static void InitializeContainer(IRepository repository)
        {
            Container.Initialize(new DictionaryContainer());

            Container.Register(new PresenterFactory());

            Container.Register(new SnackTasks(repository));
            Container.Register(new SnackViewMapper());
            Container.Register(new SnackDtoMapper());
        }

        private static IRepository InitializeRepository()
        {
            var repository = new InMemoryRepository();
            repository.Save(new User(0){Id = 1, Name = "Michel"});
            return repository;
        }

        private static void InitializeNHibernate()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            var config = MsSqlConfiguration.MsSql2005
                .ConnectionString.Is(connectionString)
                .UseReflectionOptimizer()
                .Cache.UseQueryCache()
                .ConfigureProperties(new Configuration());


            var persistenceModel = AutoPersistenceModel
                .MapEntitiesFromAssemblyOf<Snack>()
                .Where(t => t.Namespace == "Snacks.Entities");
            persistenceModel.Configure(config);
        }
    }
}