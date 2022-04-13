using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moleManager : MonoBehaviour
{
    public int index;
    public GameObject startingPosition;
    public GameObject mole;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameManagerRummel.instance.updateMole(index, mole, startingPosition);
        
    }
}
