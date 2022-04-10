using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallController : MonoBehaviour
{

    // total count of balls thrown 

    // "thrown": ball made it through the throw detection wall
    private bool wasThrown = false;
    public static int balls = 2;



    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.tag);

        if (collider.CompareTag("ThrowDetector")){
             wasThrown = true;
            Debug.Log(wasThrown);
        }
        if (collider.CompareTag("Bound") && wasThrown)
        {
            GameManager.instance.ResetBall();
            balls--;
            wasThrown = false;
            Debug.Log(balls);
        }
    }

}
