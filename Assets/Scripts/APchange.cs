using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class APchange : MonoBehaviour
{
    public Text APText;
    public void APUpadeate(int value)
    {
        APText.text = value.ToString();
    }
}
