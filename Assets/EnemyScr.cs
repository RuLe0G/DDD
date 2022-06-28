using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : Entities
{
    public bool myTurn;
    public void  makeTurn()
    {
        if (cStats.HP >= 0)
        {


            if (((enemies[0].transform.position - base.transform.position).magnitude / 2.5f) > 1f)
            {
                StartCoroutine(DashPull(transform.position, enemies[0].transform.position));
            }
            myTurn = true;
        }
        else
        {
            this.GetComponent<Entities>().EndBattle();
            enemies[0].EndBattle();
        }
    }
    float timer = 0;
    bool timerReached = false;

    private void Update()
    {
        if (myTurn)
        {
        
            if (cStats.actionPoints > 2)
            {
                if (!timerReached)
                    timer += Time.deltaTime;
                if (!timerReached && timer > 2f)
                {
                    Invoke("inv2", 2.0f);
                    cStats.actionPoints -= 4;
                    timer = 0;
                }
                
            }
            else
            {
                Invoke ("inv1", 2f);
            }
        }
    }
    private void inv1()
    {
        myTurn = false;
        cStats.actionPoints = cStats.actionPoinsMax;
        enemies[0].StartBattle();
    }
    private void inv2()
    {
        StartCoroutine(UseSkill(mySkills[1], enemies[0].transform));
        
    }

    public override void EndBattle()
    {
        inBattle = false;
        ToolHud.gameObject.SetActive(false);
        this.GetComponent<movement>().enabled = true;
    }
}
