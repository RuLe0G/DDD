using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPieces : MonoBehaviour
{
    bool awStart = false;
    private void Awake()
    {

        Destroy(gameObject,5f);

    }
    
}
