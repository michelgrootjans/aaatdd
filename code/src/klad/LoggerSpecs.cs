using bdddoc.core;
using Observation = NUnit.Framework.TestAttribute;

namespace BDD
{
    [Concern(typeof(Logger))]
    public class When_told_to_get_a_log_for_a_given_type : StaticContextSpecification
    {
        private ILog result;
        private ILog log;
        private ILogger underlying_logger;

        protected override void establish_context() {
            log = an<ILog>();
            underlying_logger = an<ILogger>();

            Logger.Initialize(underlying_logger);
            underlying_logger.when_told_to(x => x.LogFor<int>()).Return(log);
        }

        protected override void because() {
            result = Logger.LogFor<int>();
        }

        [Observation]
        public void should_forward_the_request_to_the_underlying_logger() {
            underlying_logger.was_told_to(x => x.LogFor<int>());
        }

        [Observation]
        public void should_return_the_log_from_the_underlying_logger() {
            result.should_be_equal_to(log);
        }

    }

    public interface ILogger
    {
        ILog LogFor<T>();
    }

    public interface ILog
    {
    }

    public static class Logger
    {
        private static ILogger underlying_logger;

        public static ILog LogFor<T>() {
            return underlying_logger.LogFor<T>();
        }

        public static void Initialize(ILogger logger) {
            underlying_logger = logger;
        }
    }
}