using UnityEngine;
using System.Collections;

public class MovingObstacle : MonoBehaviour {

   public float speed;
    
   private Rigidbody2D rigi;

   public Transform platform;

   public Transform startTransform;

   public Transform endTransform;

    Vector3 direction;
    Transform destination;


    void Start()
    {
        //gm = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
        SetDestination(startTransform);
    }

    void FixedUpdate()
    {
        rigi = GetComponent<Rigidbody2D>();
        rigi.MovePosition(platform.position + direction * speed * Time.fixedDeltaTime);
        if(Vector3.Distance(platform.position,destination.position) < speed * Time.fixedDeltaTime)
        {
            SetDestination(destination == startTransform ? endTransform : startTransform);
        }
    }

    void SetDestination (Transform dest)
    {
        destination = dest;
        direction= (destination.position - platform.position).normalized;
    }

    void OnDrawGizmos()
    {
       Gizmos.DrawWireCube(startTransform.position, platform.localScale);
       Gizmos.DrawWireCube(endTransform.position, platform.localScale);

    }

    // Collide Event
    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    player = GameObject.FindWithTag("Player").GetComponent<Player>();

    //    if (col.gameObject.tag == "Player")
    //    {
    //        gm.touchObstacle = true;
    //    }
    //}
}
