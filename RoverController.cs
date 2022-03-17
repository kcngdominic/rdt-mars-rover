using RoverNS;

namespace RoverControllerNS
{
  public class RoverController
  {
    int xBound;
    int yBound;
    List<Rover> rovers = new List<Rover>();
    public RoverController(string textInput)
    {
      parseInput(textInput);
    }

    // parse input to store up
    void parseInput(string textInput)
    {
      string[] lines = textInput.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

      // first line is boundaries
      string[] bounds = lines[0].Split(' ');
      if (bounds.Length != 2)
      {
        throw new Exception(String.Format("Unable to parse size of plateau: {0}", lines[0]));
      }
      if (Int32.TryParse(bounds[0], out int x) && Int32.TryParse(bounds[1], out int y))
      {
        xBound = x;
        yBound = y;
      }
      else
      {
        throw new Exception(String.Format("Unable to parse size of plateau: {0}", lines[0]));
      }

      // for each two lines, create a rover and save that command for it
      if (lines.Length % 2 == 0)
      {
        throw new Exception("Uneven number of lines for each rover");
      }
      for (int i = 1; i < lines.Length; i += 2)
      {
        string[] initPosition = lines[i].Split(' ');
        string commands = lines[i + 1];
        if (initPosition.Length != 3)
        {
          throw new Exception(String.Format("Unknown initial position: {0}", lines[i]));
        }
        if (commands.Length == 0)
        {
          throw new Exception(String.Format("Empty command at line: {0}", i + 2));
        }
        if (Int32.TryParse(initPosition[0], out int xRover) && Int32.TryParse(initPosition[1], out int yRover) && Enum.TryParse(initPosition[2], out direction dir))
        {
          rovers.Add(new Rover((i - 1) / 2, xRover, yRover, dir, commands, xBound, yBound));
        }
        else
        {
          throw new Exception(String.Format("Unknown initial position: {0}", lines[i]));
        }
      }

      return;
    }
    public string getRoverPositionStr()
    {
      return String.Join('\n', rovers.Select(r => r.getState()));
    }
    public void calculate()
    {
      foreach (Rover r in rovers)
      {
        r.execCmd();
      }
    }
  }
}