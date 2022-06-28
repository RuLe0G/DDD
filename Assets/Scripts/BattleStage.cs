using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, AITURN, WON, LOST }
public class BattleStage : MonoBehaviour
{
    public BattleState state;
    //public Entities[] order;
    public GameObject[] Entities;
    public GameObject Char;

    private int turn = 0;

    private void Start()
    {
        state = BattleState.START;
        Entities = GameObject.FindGameObjectsWithTag("Entities");
        //order = SortOrder();
    }

    public void Action()
    {
        //some action

        //Check for end battle;
    }

    private Entities[] SortOrder()
    {
        Entities[] temp = new Entities[Entities.Length];

        for (int i = 0; i < Entities.Length; i++)
        {
            Entities[i].GetComponent<Entities>().DrawInitiative();
            //Сортировка
            temp[i] = Entities[i].GetComponent<Entities>();
        }        
        return temp;
    }

    public void NextTurn()
    {
        
    }
}
