using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{

    private string playerName;
    private int playerSprite;
    private Dictionary<string, float> playerProgression;

    public Player()
    {
        playerProgression = new Dictionary<string, float>();
        playerProgression["Guide"] = 0;
        playerProgression["Kaoru"] = 0;
        playerProgression["BaristaBird"] = 0;
    }

    public void SetProgression(string name, float points)
    {
        playerProgression[name] = points;
    }

    public string PlayerName
    {
        set
        {
            playerName = value;
        }
        get
        {
            return playerName;
        }
    }

    public Dictionary<string, float> PlayerProgression
    {
        get
        {
            return playerProgression;
        }
    }

    public int PlayerSprite
    {
        get
        {
            return playerSprite;
        }
        set
        {
            playerSprite = value;
        }
    }
}