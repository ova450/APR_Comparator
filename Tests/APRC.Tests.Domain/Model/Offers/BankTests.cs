using APRC.Core.Domain.Model.Offers;
using Xunit;

namespace APRC.Tests.Domain.Model.Offers;

public class BankTests
{
    [Fact]
    public void NewBank_HasEmptyCollections()
    {
        var bank = new Categories { Name = "Test Bank" };

        Assert.Empty(bank.Offers);
        Assert.Empty(bank.Spreads);
        Assert.Equal("Test Bank", bank.Name);
    }
}
