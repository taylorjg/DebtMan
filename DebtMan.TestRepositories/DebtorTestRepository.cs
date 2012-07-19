using System.Collections.Generic;
using DebtMan.DomainModel;
using DebtMan.DomainModel.Repositories;

namespace DebtMan.TestRepositories
{
    internal class DebtorTestRepository : GenericTestRepository<Debtor, int>, IDebtorRepository
    {
        public DebtorTestRepository(IEnumerable<Debtor> items)
            : base(items)
        {
        }
    }
}
