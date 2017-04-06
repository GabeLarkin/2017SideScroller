using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {
    private int _Lives = 3;
   private int _Points;

    public Text livesvalue;
    public Text scorevalue;
    public GameObject gameOverSign;

    public void SetLives(int newValue)
    {
        _Lives = newValue;
        Debug.Log("Lives now equals " + _Lives);
        livesvalue.text = _Lives.ToString();

        if(_Lives == 0)
        {
            gameOverSign.SetActive(true);
        }
    }

    public int GetLives()
    {
        return _Lives;
    }

    public void SetPoints(int newValue)
    {
        _Points = newValue;
        scorevalue.text = _Points.ToString;
    }

    public int GetPoints()
    {
        return _Points;
    }
}
