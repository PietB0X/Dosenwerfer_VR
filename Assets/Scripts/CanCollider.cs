using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanCollider : MonoBehaviour
{
  void OnTriggerEnter(Collider collider)
  {
        if (collider.CompareTag("Bound"))
        {
            GameManager.instance.hits++;

        }

    }
}
