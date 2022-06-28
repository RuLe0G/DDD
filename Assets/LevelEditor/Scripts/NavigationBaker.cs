using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationBaker : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            other.GetComponent<Player>().charAnims.SetBool("movSpeed", false);
            other.gameObject.GetComponent<Player>().lr.positionCount = 0;
            Destroy(this.gameObject);
        }
    }
}
