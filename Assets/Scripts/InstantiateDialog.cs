using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDialog : MonoBehaviour
{
    public TextAsset ta;
    public Dialog dialog;
    public int currentNode;
    public bool ShowDialogue;

    public GUISkin skin;

    public int buttonHeight = 50;

    public Entities[] entities;

    void Start()
    {
        dialog = Dialog.Load(ta);
        skin = Resources.Load("Skin") as GUISkin;
    }


    void OnGUI()
    {
        GUI.skin = skin;
        if (ShowDialogue)
        {
            GUI.Box(new Rect(Screen.width / 2 - 500, Screen.height - 500, 1000, 400), "");
            GUI.Label(new Rect(Screen.width / 2 - 450, Screen.height - 480, 900, 120), dialog.nodes[currentNode].NpcText);
            for (int i = 0; i < dialog.nodes[currentNode].answers.Length; i++)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 450, Screen.height - 300 + (buttonHeight+2) * i, 900, buttonHeight), dialog.nodes[currentNode].answers[i].text))
                {
                    if (dialog.nodes[currentNode].answers[i].fight == "true")
                    {
                        foreach (Entities e in entities)
                        {
                            e.StartBattle();
                        }
                    }
                    if (dialog.nodes[currentNode].answers[i].end == "true")
                    {
                        ShowDialogue = false;
                    }
                    currentNode = dialog.nodes[currentNode].answers[i].nextNode;
                }
            }
        }

    }
    public void ShowDialogSc()
    {
        ShowDialogue = true;
    }
    public void ShowLateDialogSc(float targetTime)
    {
        StartCoroutine(showLateDialog(targetTime));
        
    }

    private IEnumerator showLateDialog(float targ)
    {
        float t = 0;
        while (t < targ)
        {
            yield return null;
            t += Time.deltaTime;
            if (t >= targ)
            {
                ShowDialogue = true;
            }
        }
    }
}
