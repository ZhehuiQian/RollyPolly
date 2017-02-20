using UnityEngine;
using System.Collections;

public class Winning : MonoBehaviour {

    Player player;
    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        if (col.gameObject.tag == "Player" && gm.points > 0)
        {
            gm.reachdestination = true;
        }
    }
}
