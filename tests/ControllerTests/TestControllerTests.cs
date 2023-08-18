using AzurePipelinesPOC.Controllers;

namespace AzurePipelinesPOCTests;

public class TestControllerTests
{
    private TestController _testController;
    
    [SetUp]
    public void Setup()
    {
        _testController = new TestController();
    }

    [Test]
    public void Test1()
    {
        var response = _testController.Get();

        Assert.That(response, Is.EqualTo("Success!"));
    }
}