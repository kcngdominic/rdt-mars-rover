// See https://aka.ms/new-console-template for more information

namespace Test
{
  class Program
  {
    static void Main(string[] args)
    {
      char[] fluff = { '\n', ' ' };
      foreach (int index in Enumerable.Range(1, 1))
      {
        string testInput = File.ReadAllText(String.Format(@".\testcase\in{0}.txt", index)).Trim(fluff);
        string testOutput = RoverController.RoverController.calculate(testInput).Trim(fluff);
        string testTarget = File.ReadAllText(String.Format(@".\testcase\out{0}.txt", index)).Trim(fluff);
        Console.WriteLine(String.Format("Test {0}: {1}", index, String.Compare(testOutput, testTarget) == 0 ? "Pass" : "Fail"));
      }
    }
  }
}