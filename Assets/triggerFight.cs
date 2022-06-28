using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerFight : MonoBehaviour
{
    public GameObject triggerdObj;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            triggerdObj.GetComponent<InstantiateDialog>().ShowDialogue = true;
            Destroy(this.gameObject);
        }
    }
}
