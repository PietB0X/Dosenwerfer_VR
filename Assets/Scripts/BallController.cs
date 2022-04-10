using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallController : MonoBehaviour
{

    // total count of balls thrown 

    // "thrown": ball made it through the throw detection wall
    public bool wasThrown = false;


    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.tag);

        if (collider.CompareTag("ThrowDetector")){
             wasThrown = true;
        }
        if (collider.CompareTag("Bound") && wasThrown)
        {
            GameManager.instance.ResetBall();
            GameManager.instance.balls--;
        }
    }

}
