using APRComparator.Domain.Entities.Offers;
using Xunit;

namespace APRC.Tests.Domain;

public class BankTests
{
    [Fact]
    public void NewBank_HasEmptyCollections()
    {
        var bank = new Bank { Name = "Test Bank" };

        Assert.Empty(bank.Offers);
        Assert.Empty(bank.Spreads);
        Assert.Equal("Test Bank", bank.Name);
    }
}
