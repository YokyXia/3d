using System.Collections.Generic;
//using Unity.Mathematics;

public class GlobalData
{
    private GlobalData()
    {

    }

    private static GlobalData _instance;
    public static GlobalData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GlobalData();
            }
            return _instance;
        }
    }

  //  public bool qte { get; set; } =false;
    public bool qteSuccess { get; set;} =false;
    public bool suberMode { get; set; } = false;

    public bool timeFreeze { get; set; } = false;

    public bool normal { get; set; } = true;

    public int enegy { get; set; } = 100;
}