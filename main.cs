// using RoverNS;
using RoverControllerNS;
using Test;

// See https://aka.ms/new-console-template for more information
namespace RdtMarsRover
{

  class Program
  {
    static void Main(string[] args)
    {
      if (args.Length == 0)
      {
        Console.WriteLine("Please enter the path to input file or \"test\".");
        return;
      }

      if (args[0] == "test")
      {
        Test.Program.Test();
      }
      else
      {
        RoverController myCon = new RoverController(File.ReadAllText(args[0]));
        myCon.calculate();
        Console.WriteLine(myCon.getRoverPositionStr());
      }
    }
  }
}