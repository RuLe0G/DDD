using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipHUD : MonoBehaviour
{
    public Image portrait;
    public Text Name;
    public Text HP;

	public void SetHUD(Entities Chel)
	{
		portrait.sprite = Chel.portrait;
		Name.text = Chel.Name;
		HP.text = "HP: " + Chel.cStats.HP.ToString();
	}
}
