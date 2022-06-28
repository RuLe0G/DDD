using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SkillView : MonoBehaviour
{
    public Image sprite;
    public Button skillButton;
    public Text APtext;

    private ActiveSkill skill;

    public event UnityAction<ActiveSkill, SkillView> SkillButtonClick;
    public void Render(ActiveSkill skill)
    {
        this.skill = skill;
        this.sprite.sprite = skill.sprite;
        this.APtext.text = skill.apCost.ToString();
    }

    private void OnEnable()
    {
        skillButton.onClick.AddListener(onButtonClick);
    }
    private void OnDisable()
    {
        skillButton.onClick.RemoveListener(onButtonClick);
    }

    private void onButtonClick()
    {
        SkillButtonClick?.Invoke(skill, this);
    }
}
