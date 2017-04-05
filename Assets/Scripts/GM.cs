using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {
    public int lives;
    public int points;

    public Text livesvalue;
    public Text scorevalue;

    public void SetLives(int newValue)
    {
        lives = newValue;
        Debug.Log("Lives now equals " + lives);
        livesvalue.text = lives.ToString();
    }
}
