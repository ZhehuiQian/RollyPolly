using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    Player player;
    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();

    }

    // Use this for initialization
    void OnCollisionEnter2D(Collision2D col)
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        if (col.gameObject.tag == "Player")
        {
            gm.touchObstacle = true;
        }
    }
}
