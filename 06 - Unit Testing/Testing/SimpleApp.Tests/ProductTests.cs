using SimpleApp.Models;

namespace SimpleApp.Tests;

public class ProductTests
{
    [Fact]
    public void CanChangeProductName()
    {
        // Arrange                      (traducido: Preparar)
        var p = new Product { Name = "Test", Price = 100M };
        // Act                          (traducido: Actuar)
        p.Name = "New Name";
        //Assert                        (traducido: Afirmar)
        Assert.Equal("New Name", p.Name);
    }

    [Fact]
    public void CanChangeProductPrice()
    {
        // Arrange                      (traducido: Preparar)
        var p = new Product { Name = "Test", Price = 100M };
        // Act                          (traducido: Actuar)
        p.Price = 200M;
        //Assert                        (traducido: Afirmar)
        Assert.Equal(200M, p.Price);
    }
}
