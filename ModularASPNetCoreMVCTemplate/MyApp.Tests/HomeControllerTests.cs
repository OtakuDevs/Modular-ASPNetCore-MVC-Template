using ModularASPNetCoreMVCTemplate.Controllers;
using NUnit.Framework;

namespace MyApp.Tests;

[TestFixture]
public class HomeControllerTests
{
    private HomeController _homeController = null!;

    //add mock the service if exists
    // private Mock<IExampleService> _mockExampleService

    [SetUp]
    public void SetUp()
    {
        _homeController = new HomeController();
    }

    [Test]
    public void Index_ReturnsViewResult()
    {
        //Write your test here
        var result = _homeController.Index();
    }
}