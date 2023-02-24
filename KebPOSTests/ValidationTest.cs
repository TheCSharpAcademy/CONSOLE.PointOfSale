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

    [TestCase("y")]
    [TestCase("yes")]
    [TestCase("n")]
    [TestCase("no")]
    public void IsValidAnswer_ShouldReturnTrue(string input)
    {
        var result = Validation.IsValidAnswer(input);

        Assert.IsTrue(result);
    }

    [TestCase("")]
    [TestCase("    ")]
    [TestCase("!*&")]
    [TestCase("faf")]
    [TestCase(" bacon")]
    [TestCase("ham ")]
    [TestCase(" eggs ")]
    [TestCase("-111")]
    [TestCase("12")]
    [TestCase("yess")]
    [TestCase("noo")]
    [TestCase("Y")]
    [TestCase("Yes")]
    [TestCase("YeS")]
    [TestCase("yeS")]
    [TestCase("N")]
    [TestCase("NO")]
    [TestCase(" yes")]
    [TestCase("n ")]
    [TestCase(" no ")]
    [TestCase("n0")]
    [TestCase("y3s")]
    public void IsValidAnswer_ShouldReturnFalse(string input)
    {
        var result = Validation.IsValidAnswer(input);

        Assert.IsFalse(result);
    }
}