using KebPOS;

namespace KebPOSTests;

[TestFixture]
public class ValidationTest
{
    [TestCase("13")]
    [TestCase("1")]
    [TestCase("17")]
    [TestCase("300")]
    public void IsValidIdInput_ShouldReturnTrue(string id)
    {
        var result = Validation.IsValidIdInput(id);

        Assert.IsTrue(result);
    }

    [TestCase("0")]
    [TestCase("-3")]
    [TestCase("-99")]
    [TestCase("-1")]
    [TestCase("")]
    [TestCase("hello world")]
    [TestCase("36854775807")]
    [TestCase("         ")]
    public void IsValidIdInput_ShouldReturnFalse(string id)
    {
        var result = Validation.IsValidIdInput(id);

        Assert.IsFalse(result);
    }
}