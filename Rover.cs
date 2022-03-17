namespace RoverNS
{
  public enum direction
  {
    N,
    E,
    S,
    W
  };

  public class Rover
  {
    int id;
    int xCoor;
    int yCoor;
    direction facing;
    string commands;
    int xBound;
    int yBound;

    public Rover(int roverId, int x, int y, direction dir, string cmds, int xB, int yB)
    {
      id = roverId;
      xCoor = x;
      yCoor = y;
      facing = dir;
      commands = cmds;
      xBound = xB;
      yBound = yB;
    }

    public string getState()
    {
      return String.Format("{0} {1} {2}", xCoor, yCoor, facing);
    }

    // process a series of commands
    public void execCmd()
    {
      foreach (char cmd in commands)
      {
        step(cmd);
      }
      commands = "";
    }

    // process one command
    void step(char cmd)
    {
      if (cmd.Equals('L'))
      {
        facing = (direction)(((int)facing + 3) % 4);
      }
      else if (cmd.Equals('R'))
      {
        facing = (direction)(((int)facing + 1) % 4);
      }
      else if (cmd.Equals('M'))
      {
        switch (facing)
        {
          case direction.N:
            yCoor++;
            break;
          case direction.E:
            xCoor++;
            break;
          case direction.S:
            yCoor--;
            break;
          case direction.W:
            xCoor--;
            break;
          default:
            throw new Exception(String.Format("Unknown direction: {0}", facing));
        }
        // check if we are out of bound
        if (xCoor < 0 || xCoor > xBound || yCoor < 0 || yCoor > yBound)
        {
          throw new Exception(String.Format("Rover {0} goes out of bound", id));
        }
      }
      else
      {
        // throw some error here
        throw new Exception(String.Format("Unknown action: {0}", cmd));
      }
    }
  }
}