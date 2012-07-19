using DebtMan.DomainModel.Repositories;
using StructureMap.Configuration.DSL;

namespace DebtMan.TestRepositories
{
    public class TestRepositoriesRegistry : Registry
    {
        public TestRepositoriesRegistry()
        {
            var debtorRepository = TestData.CreateDebtorRepository();
            For<IDebtorRepository>().Use(debtorRepository);
        }
    }
}
