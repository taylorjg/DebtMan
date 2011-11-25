using DebtMan.DomainModel.Repositories;
using StructureMap.Configuration.DSL;

namespace DebtMan.TestRepositories
{
    public class TestRepositoriesRegistry : Registry
    {
        public TestRepositoriesRegistry()
        {
            IDebtorRepository debtorRepository = TestData.CreateDebtorRepository();
            For<IDebtorRepository>().Use(debtorRepository);
        }
    }
}
