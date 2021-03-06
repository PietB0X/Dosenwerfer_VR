using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour

{
    public static GameManager instance;

    public int hits = 0;

    public TextMeshProUGUI hitsText;

    public GameObject endGameText;
    public GameObject ball;
    public GameObject startingPosition;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hitsText.text = "Knockdowns: " + hits/2;
    }

    public void ResetBall()
    {
        if (BallController.balls != 0)
        {
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            ball.transform.position = startingPosition.transform.position;
        }
        else
        {
            StartCoroutine(EndGame());
        }
    }


    public IEnumerator EndGame()
    {
        endGameText.SetActive(true);
        Debug.Log("### GAME ENDED! ###");

        BallController.balls = 3;

        // reset the game after 3 seconds
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Application.LoadLevel(Application.loadedLevel);

    }


}
