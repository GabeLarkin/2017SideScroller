using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.GetOut();
        }
    }
}
