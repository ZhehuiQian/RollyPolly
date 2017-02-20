using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public int points;

    public Text pointsText;

    public bool touchObstacle;

    public bool reachdestination;


    [SerializeField]
    private GameObject GameOverScreen;

  
    void Update()
    {
        pointsText.text = ("Points: " + points);

        if(touchObstacle == true)
        {
            EndGame();
        }

        if (reachdestination == true)
        {
            EndGame();
        }

    }

    public void EndGame()
    {
        Debug.Log("GAME OVER");
        GameOverScreen.SetActive(true);
    }
}
