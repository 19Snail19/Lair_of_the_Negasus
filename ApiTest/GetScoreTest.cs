using Negasus.Console;
using Negasus.Console.Tools;

namespace ApiTest;

[TestClass]
public sealed class GetScoreTest()
{
    [TestMethod]
    public void GetScore_IsNotNull_ReturnsTrue()
    {
        var result = HiScore.GetScore();
        
        Assert.IsNotNull(result);
    }
}
