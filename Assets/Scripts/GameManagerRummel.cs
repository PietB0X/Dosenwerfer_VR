using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManagerRummel : MonoBehaviour

{
    public static GameManagerRummel instance;

    public TextMeshProUGUI hitsText;

    //  Liste Maulwürfe
    List<GameObject> moles = new List<GameObject>();

    //  List Positionen
    List<GameObject> startingPositions = new List<GameObject>();

    private int currentIndex = -1;
    public float moleSpeed = 0.2f;
    private float speed = 0.0f;

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

        //  update moles position (random mole)
    }

    // Update is called once per frame
    void Update()
    {
        if (currentIndex == -1)
        {
            currentIndex = (int)(Random.value * 9) + 1;
            speed = +moleSpeed;
        }



    }

    public void updateMole(int index, GameObject mole, GameObject startingPosition)
    {
        if (index != currentIndex)
        {
            return;
        }

        if (mole == null)
        {
            Debug.Log("mole == null");
        }

        if (startingPosition == null)
        {
            Debug.Log("position == null");
        }

        if(mole.transform.position.y < (startingPosition.transform.position.y + 0.15f) && speed > 0.0f)
        {
            speed = +moleSpeed;

        } else if(mole.transform.position.y > (startingPosition.transform.position.y + 0.15f) && speed > 0.0f)  //  toggle direction
        {
            speed = -moleSpeed;
        }
        else if(mole.transform.position.y < (startingPosition.transform.position.y) && speed < 0.0f)
        {
            speed = 0.0f;
            currentIndex = -1;
        }

        Vector3 newPosition = mole.transform.position + new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
        mole.transform.position = newPosition;
    }
}
