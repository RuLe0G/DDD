using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Help : MonoBehaviour
{
    public InstantiateDialog dlg;
    public GlobalUI fight;
    public Entities h;
    public Entities e;


    public

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            dlg.ShowDialogue = true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            fight.StartFight();
            h.inBattle = true;
            e.inBattle = true;

        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            fight.FinishFight();
            h.inBattle = false;
            e.inBattle = false;

        }
    }
}
