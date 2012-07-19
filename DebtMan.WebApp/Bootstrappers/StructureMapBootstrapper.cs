using StructureMap;
using DebtMan.TestRepositories;

namespace DebtMan.WebApp.Bootstrappers
{
    internal class StructureMapBootstrapper
    {
        public static void Initialise()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new TestRepositoriesRegistry()));
        }
    }
}
