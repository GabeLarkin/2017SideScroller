using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
        if (player != null)
        {
            gameObject.SetActive(false);
            FindObjectOfType<GM>().SetPoints(FindObjectOfType<GM>().GetPoints() + 1);
        }
    }
}
