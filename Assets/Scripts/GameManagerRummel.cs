using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManagerRummel : MonoBehaviour

{
    public static GameManagerRummel instance;
    public TextMeshProUGUI scoreText;
    public GameObject endGameText;

    List<GameObject> moles = new List<GameObject>();  //  Liste Maulwürfe
    List<GameObject> startingPositions = new List<GameObject>();   //  List Positionen

    [HideInInspector] public int currentIndex = -1;
    [HideInInspector] public int score = 0;
    public float moleSpeed = 0.2f;
    float cntdnw = 100.0f;
    public TextMeshProUGUI timeText;
    private bool GameEnded = false;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //  loop maulwürfe und staringpositoins
        for (int i = 1; i <= 9; i++)
        {
            moles.Add(GameObject.Find("Maulwurf " + i));
            startingPositions.Add(GameObject.Find("StartingPosition ( " + (i - 1) + ")"));
        }
    }


    public IEnumerator EndGame()
    {
        endGameText.SetActive(true);
        Debug.Log("### GAME ENDED! ###");


        // reset the game after 3 seconds
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    // Update is called once per frame
    void Update()
    {
        //Wähle neuen Mole aus, wenn keiner aktiv ist
        if (currentIndex == -1 && GameEnded == false)
        {
            //  update moles position (random mole)
            currentIndex = (int)(Random.value * 9) + 1;
        }
        scoreText.text = "Score: " + score;

        if (cntdnw > 0)
        {
            cntdnw -= Time.deltaTime;
        }
        double b = System.Math.Round(cntdnw, 2);
        timeText.text = b.ToString();
        if (cntdnw < 0)
        {
            GameEnded = true;
            StartCoroutine(EndGame());
            Debug.Log("Completed");
        }

    }
}
