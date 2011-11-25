using StructureMap;
using DebtMan.TestRepositories;

namespace DebtMan.WebApp
{
    internal class StructureMapBootstrapper
    {
        public static void Initialise()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new TestRepositoriesRegistry()));
        }
    }
}
