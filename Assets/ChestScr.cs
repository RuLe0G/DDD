using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestScr : MonoBehaviour
{
    public Button btn;
    public GameObject label;
    public float Gld;
    public void Interact()
    {
        btn.gameObject.SetActive(false);
        label.GetComponent<TMP_Text>().text = (label.GetComponent<TMP_Text>().text + "(пусто)");
        GoldUI.Instance.AddText(("+" + (int)Gld + " золотых"), new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));
    }
}
