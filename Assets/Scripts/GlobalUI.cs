using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalUI : MonoBehaviour
{
    public Entities activePlayer;
    public GameObject batUI;
    public BattleUI BUI;
    public Button walkBut;

    public void Awake()
    {
        activePlayer = FindObjectOfType<Player>();
    }

    public void StartFight()
    {
        activePlayer.GetComponent<movement>().enabled = false;
        batUI.SetActive(true);
        Setup();
    }
    public void FinishFight()
    {
        activePlayer.GetComponent<movement>().enabled = true;
        batUI.SetActive(false);
    }

    public void Setup()
    {
        BUI.activePlayer = this.activePlayer;
        BUI.SwapPlayer();
        walkBut.onClick.AddListener(SetPlayer);
    }
    void SetPlayer()
    {
        activePlayer.GetComponent<Player>().Action();
    }

}
