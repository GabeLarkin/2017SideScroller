using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinButton : MonoBehaviour {

    public GameObject youWinSign;

    public void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
        if(player != null)
        {
            Wincondition();
        }
    }

    void Wincondition()
    {
        youWinSign.SetActive(true);
    }

}
