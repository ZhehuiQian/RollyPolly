using UnityEngine;
using System.Collections;

public class Spring_Vertical : MonoBehaviour {

    Player player;

    // Use this for initialization
    void OnCollisionEnter2D(Collision2D col)
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        if (col.gameObject.tag == "Player")
        {
            player.bounce_vertical = true;
        }
    }
}
