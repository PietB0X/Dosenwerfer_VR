using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HammerCollisionScript : MonoBehaviour
{
    public Vector3 PrevPos;
    public Vector3 NewPos;
    public Vector3 ObjVelocity;
    public GameObject Cube;
    public TextMeshProUGUI scoreText;
    private float score = 0f;

    // Start is called before the first frame update
    void Start()
    {
        PrevPos = transform.position;
        NewPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        NewPos = transform.position;  // each frame track the new position
        ObjVelocity = (NewPos - PrevPos) / Time.fixedDeltaTime;  // velocity = dist/time
        PrevPos = NewPos;  // update position for next frame calculation
    }

    void OnTriggerEnter (Collider other)
    {
        
            Debug.Log(ObjVelocity.magnitude/3);
                    
            if (score < ObjVelocity.magnitude/3)
            {
                score = ObjVelocity.magnitude/3;
                //Cube.transform.position = new Vector3(0f, score, 0f);
            }
            scoreText.text = "Score: " + score;
            Cube.GetComponent<Rigidbody>().velocity = new Vector3(0f, ObjVelocity.magnitude/3, 0f);

    }
}
