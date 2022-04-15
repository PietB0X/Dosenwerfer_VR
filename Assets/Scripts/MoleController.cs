using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleController : MonoBehaviour
{
    public int index;
    public GameObject startingPosition;
    public float speed = 0.0f;
    public GameObject mole;
    private bool isShowing = false;


    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.tag);

        if (collider.CompareTag("Hammer"))
        {
            GameManagerRummel.instance.score++;
            HideMole();
            Debug.Log(GameManagerRummel.instance.score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerRummel.instance.currentIndex == index)
        {
            if (!isShowing) ShowMole();

            if (mole.transform.position.y > (startingPosition.transform.position.y + 0.15f) && speed > 0.0f)
                HideMole();
            else if (mole.transform.position.y < (startingPosition.transform.position.y) && speed < 0.0f)
                ResetMole();
            UpdatePosition();
        }
    }



    public void ShowMole()
    {
        isShowing = true;
        speed = +GameManagerRummel.instance.moleSpeed;
        mole.GetComponent<SphereCollider>().enabled = true;
    }

    public void HideMole()
    {
        speed = -GameManagerRummel.instance.moleSpeed;
        mole.GetComponent<SphereCollider>().enabled = false;
    }

    public void ResetMole()
    {
        speed = 0.0f;
        GameManagerRummel.instance.currentIndex = -1;
        isShowing = false;
    }

    public void UpdatePosition()
    {
        Vector3 newPosition = mole.transform.position + new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
        mole.transform.position = newPosition;
    }
}
