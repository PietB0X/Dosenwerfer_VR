using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallController : MonoBehaviour
{
    public GameObject endGameText;

    // total count of balls thrown 
    public static int ballsLanded = 0;

    // "thrown": ball made it through the throw detection wall
    public bool wasThrown = false;
    // "landed": ball was thrown AND hit any bound
    public bool hasLanded = false;

    void Start()
    {
        endGameText.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
         if (collider.gameObject.CompareTag("ThrowDetector")){
             wasThrown = true;
        }
        if (collider.gameObject.CompareTag("Bound") && wasThrown)
        {
            hasLanded = true;
            ballsLanded++;
            if (ballsLanded > 2)
            {
                StartCoroutine(endGame());
            }
        }
    }

    private IEnumerator endGame()
    {
        endGameText.SetActive(true);
        Debug.Log("### GAME ENDED! ###");

        // reset the game after 3 seconds
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);       
    }
}