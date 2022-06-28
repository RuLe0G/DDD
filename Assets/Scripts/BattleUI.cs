using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{

    //public List<Skills> skills;
    public ActiveSkill[] skills;
    public Entities activePlayer;
    public GameObject skillContainer;
    public SkillView temp;
    public Text APText;

    public Camera cameraCam;
    public LayerMask mask;
    private Ray ray;

    public bool skillClicked = false;
    private ActiveSkill tempSkill;

    private void Start()
    {
        SwapPlayer();
    }

    public void APUpadeate()
    {
        APText.text = activePlayer.cStats.actionPoints.ToString();
    }

    public void SwapPlayer()
    {        
        var children = new List<GameObject>();
        foreach (Transform child in skillContainer.transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));

        skills = activePlayer.MySkills;
        for (int i = 1; i < skills.Length; i++)
        {
            AddSkill(skills[i]);
        }
    }

    private void AddSkill(ActiveSkill skill)
    {
        var view = Instantiate(temp, skillContainer.transform);
        view.SkillButtonClick += onSkillButtonClick;
        view.Render(skill);
    }

    private void onSkillButtonClick(ActiveSkill skill, SkillView view)
    {
        if (skillClicked)
        {
            skillClicked = false;
            this.tempSkill = null;
        }
        skillClicked = true;
        this.tempSkill = skill;

    }
    public void FixedUpdate()
    {
        if (skillClicked)
        {
            ray = cameraCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    tryActivSkill(tempSkill);
                }
            }
        }
    }
    private void tryActivSkill(ActiveSkill skill)
    {
        if (skill.isMovement)
        {
            StartCoroutine(activePlayer.UseSkill(activePlayer.GetComponent<Player>().transform));

        }
        else
        {
            //StartCoroutine(activePlayer.UseSkill(skill, activePlayer.GetComponent<Player>().transform));
            StartCoroutine(activePlayer.UseSkill(skill, activePlayer.GetComponent<Player>().enemies[0].transform));
        }
    }
}
