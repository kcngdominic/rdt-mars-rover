using RoverControllerNS;
namespace Test
{
  class Program
  {
    public static void Test()
    {
      foreach (int index in Enumerable.Range(1, 4))
      {
        string testInput = File.ReadAllText(String.Format(@".\testcase\in{0}.txt", index));
        string testOutput;
        try
        {
          RoverController testCon = new RoverController(testInput);
          testCon.calculate();
          testOutput = testCon.getRoverPositionStr();
        }
        catch (Exception e)
        {
          testOutput = e.Message;
        }
        string testTarget = File.ReadAllText(String.Format(@".\testcase\out{0}.txt", index));
        Console.WriteLine(String.Format("Test {0}: {1}", index, String.Compare(testOutput, testTarget) == 0 ? "Pass" : "Fail"));
      }
    }
  }
}