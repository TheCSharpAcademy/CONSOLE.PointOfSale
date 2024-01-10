using KebPOS;
using KebPOS.Models;
using KebPOS.DbContexts;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

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
    public void AddProduct_ShouldAddProductToDatabase()
    {
        // Arrange
        var product = new Product
        {
            Name = "TestProduct",
            Price = 10.99m,
            Description = "Test Description"
        };

        // Act
        KebabController.AddProduct(product);

        // Assert
        using (var context = new KebabContext())
        {
            var retrievedProduct = context.Products.Find(product.Id);
            Assert.IsNotNull(retrievedProduct);
            Assert.AreEqual(product.Name, retrievedProduct.Name);
        }
    }
}