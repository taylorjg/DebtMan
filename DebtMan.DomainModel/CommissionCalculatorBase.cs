namespace DebtMan.DomainModel
{
    /// <summary>
    /// An application of the Strategy design pattern.
    /// </summary>
    public abstract class CommissionCalculatorBase
    {
        public abstract decimal CalculateManagementFee(Debtor debtor);
    }
}
