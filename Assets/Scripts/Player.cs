using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Player controller and behavior


public class Player : MonoBehaviour {

    private Rigidbody2D rigi;
    public float maxSpeed = 10f;
    public float jumpPower = 100.0f;
   // public float bouncePower = 100.0f;
    public float bounceSpeed = 5f;
   // public bool touch = false;
    public bool bounce = false;
    public bool bounce_vertical = false;
    

    private GameMaster gm;
	void Start () {
        gm = GameObject.FindWithTag("GameMaster").GetComponent <GameMaster>();
	
	}

 


	//// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigi = GetComponent<Rigidbody2D>();

            rigi.AddForce(new Vector2(0, jumpPower));
        }

        if (bounce)
        {
            StartCoroutine(Bounce());
        }

        if (bounce_vertical)
        {
            StartCoroutine(Bounce_Vertical());
        }

    }
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
       // float moveAlongY = Input.GetAxis("Vertical");

        rigi = GetComponent<Rigidbody2D>();
        
            rigi.velocity = new Vector2(move * maxSpeed, rigi.velocity.y);

        //if (touch == true)
        //{
        //    rigi.velocity = new Vector2(move * bounceSpeed * (-1), rigi.velocity.y);
        //}
       
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Heart"))
        {
            Destroy(col.gameObject);
            gm.points += 1;
        }

        //if (col.CompareTag("Spring"))
        //{
        //    touch = true;
        //}
    }

    //void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.CompareTag("Spring"))
    //    {
    //        touch = false;
    //    }
    //}

    IEnumerator Bounce()
    {
        rigi.AddForce(new Vector2(0, bounceSpeed * 4));
        yield return new WaitForSeconds(0.5f);
        rigi.AddForce(new Vector2(0, bounceSpeed * -4));
        bounce = false;

    }

    IEnumerator Bounce_Vertical()
    {
        rigi.AddForce(new Vector2(bounceSpeed * 4, 0));
        yield return new WaitForSeconds(0.5f);
        rigi.AddForce(new Vector2(bounceSpeed * -4,0));
        bounce = false;

    }

}
