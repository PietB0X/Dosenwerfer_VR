using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanCollider : MonoBehaviour
{
  //total of knocked down cans
  public static int knockdownCount = 0;
  
  //UI text displaying knockdown value
  public TextMeshProUGUI countText;
  //track knockdown status s.t. only first ground collision counts as can knockdown
  private bool isKnockedDown = false;

  void OnCollisionEnter(Collision collision)
  {
      if (collision.collider.CompareTag("Bound") && !isKnockedDown)
          handleKnockdown();
  }

  private void handleKnockdown()
  {
      isKnockedDown = true;
      knockdownCount++;
      Debug.Log("Collision #" + knockdownCount.ToString());
      Debug.Log(countText.ToString());
      countText.text = "Knockdowns: " + knockdownCount.ToString();
  }
}
