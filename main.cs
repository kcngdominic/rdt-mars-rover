// using RoverNS;
using RoverControllerNS;

// See https://aka.ms/new-console-template for more information
namespace RdtMarsRover
{

  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        RoverController myCon = new RoverController(File.ReadAllText(String.Format(@".\testcase\in{0}.txt", 3)));
        Console.WriteLine(myCon.getRoverPositionStr());
        myCon.calculate();
        Console.WriteLine(myCon.getRoverPositionStr());
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
  }
}