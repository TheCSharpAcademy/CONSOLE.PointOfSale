using KebPOS;
using KebPOS.Models;

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

    [Test]
    public void CheckStringLength_ValidLength_ReturnsTrue()
    {
        //Arrange 
        string stringToCheck = "SampleProduct";
        int nameLengthLimit = 15;
        //Act
        bool result = Validation.CheckStringLength(stringToCheck, nameLengthLimit);
        //Assert
        Assert.IsTrue(result);
    }
    [Test]
    public void CheckStringLength_ValidLength_ReturnsFalse()
    {
        //Arrange 
        string stringToCheck = "SampleProduct";
        int nameLengthLimit = 12;
        //Act
        bool result = Validation.CheckStringLength(stringToCheck, nameLengthLimit);
        //Assert
        Assert.IsFalse(result);
    }
    [Test]
    public void CheckDuplicateProductName_ReturnsTrue()
    {
        //Arrange 
        Product product = new Product();
        product.Name = "Yogurt Kebab";

        //Act
        bool result = Validation.CheckDuplicateProductName(product);

        //Assert
        Assert.IsTrue(result);
    }
    [Test]
    public void CheckDuplicateProductName_ReturnsFalse()
    {
        //Arrange 
        Product product = new Product();
        product.Name = "There should not be a product with this name";

        //Act
        bool result = Validation.CheckDuplicateProductName(product);

        //Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void CheckValid_ReturnTrue()
    {
        //Arrange 
        decimal price = (decimal)10.01;

        //Act
        bool result = Validation.CheckValid(price);

        //Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void CheckValid_ReturnFalse()
    {
        //Arrange 
        decimal price = (decimal)10.123;

        //Act
        bool result = Validation.CheckValid(price);

        //Assert
        Assert.IsFalse(result);

    }

    [Test]
    public void CheckPrice_PosPrice_ReturnsTrue()
    {
        // Arrange
        decimal validPrice = (decimal)10.00;

        // Act
        bool result = Validation.CheckPrice(validPrice);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void CheckPrice_NegativePrice_ReturnsFalse()
    {
        // Arrange
        decimal invalidPrice = (decimal)-5.00;

        // Act
        bool result = Validation.CheckPrice(invalidPrice);

        // Assert
        Assert.IsFalse(result);
    }
    [Test]
    public void CheckPrice_NonNegativePrice_ReturnsTrue()
    {
        // Arrange
        decimal validPrice = (decimal)0.00;

        // Act
        bool result = Validation.CheckPrice(validPrice);

        // Assert
        Assert.IsTrue(result);
    }
}