using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundElement : MonoBehaviour
{
    // will be the speed of the different background elements
    [SerializeField]
    private float speed;

    // the transform of the neighbour that we need to snap to when leaving the trigger
    [SerializeField]
    private Transform neighbour;




    //function thats used to move the background elements (called in the gamemanager)
    public void Move()
    {
        // we used smoothDeltaTime cuz we don't want the speed to be depending on the how manytimes we call the move (in update) which will give it a different speed based on the hardware
        // devices that are good will run it in 60 fps, others will run it in 30 fps and so on, instead we want it to be constant.
        transform.Translate(Vector2.left * speed * Time.smoothDeltaTime);
    }

    //function used to snap (reset) the background element at the end of the neighbour
    public void SnapToNeighbour()
    {
        transform.position = new Vector2(neighbour.position.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // give the obstacles it's own rigged body so that it's colliders act like it's separated from the parent"ground"

        if (collision.tag == "Reset")
            SnapToNeighbour();
    }


    
}
