using APRC.Core.Domain.Model.Offers;
using Xunit;

namespace APRC.Tests.Domain.Model.Offers;

// Todo: проверить и исправить!
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
