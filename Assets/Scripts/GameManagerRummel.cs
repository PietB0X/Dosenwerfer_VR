using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManagerRummel : MonoBehaviour

{
    public static GameManagerRummel instance;
    public TextMeshProUGUI scoreText;
    List<GameObject> moles = new List<GameObject>();  //  Liste Maulwürfe
    List<GameObject> startingPositions = new List<GameObject>();   //  List Positionen

    [HideInInspector] public int currentIndex = -1;
    [HideInInspector] public int score = 0;
    public float moleSpeed = 0.2f;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //  loop maulwürfe und staringpositoins
        for(int i = 1; i <= 9; i++)
        {
            moles.Add(GameObject.Find("Maulwurf " + i));
            startingPositions.Add(GameObject.Find("StartingPosition ( " + (i-1) + ")"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Wähle neuen Mole aus, wenn keiner aktiv ist
        if (currentIndex == -1)
        {
            //  update moles position (random mole)
            currentIndex = (int)(Random.value * 9) + 1;    
        }
    }
}
