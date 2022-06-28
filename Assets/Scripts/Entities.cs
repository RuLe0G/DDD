using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Entities : MonoBehaviour
{
    public Sprite portrait;
    public GameObject character;
    public Animator charAnims;
    protected NavMeshAgent navMesh;

    public TooltipHUD ToolHud;

    public APchange APText;

    public Camera cameraCam;

    public Entities targetEntity;

    [Header("Battle Related")]
    public CharStats cStats;
    public string Name;

    public Entities[] enemies;
    public Entities[] allies;

    [SerializeField]
    protected ActiveSkill[] mySkills;
    [SerializeField]
    protected PassiveSkill[] myPassives;


    public bool inBattle;
    public ActiveSkill[] MySkills
    {
        get
        {
            return this.mySkills;
        }
    }
    public PassiveSkill[] MyPassives
    {
        get
        {
            return this.myPassives;
        }
    }

    protected Transform skillTarget;
    protected ActiveSkill usedSkill;
    public void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }
    public void Setup()
    {
        this.cStats = new CharStats();

        this.navMesh = base.GetComponent<NavMeshAgent>();
        navMesh.speed = 0f;
    }

    public virtual void StartBattle(BattleStage bs, Entities[] allies, Entities[] enemies)
    {
        //battleStage = bs;
        inBattle = true;
        this.enemies = enemies;
        this.allies = allies;
        this.cStats.actionPoints = this.cStats.actionPoinsMax;

    }
    public virtual void StartBattle()
    {
        inBattle = true;
        this.cStats.actionPoints = this.cStats.actionPoinsMax;

    }
    public virtual void EndBattle()
    {
        inBattle = false;
    }
    public float DrawInitiative()
    {
        return (Random.Range(0, 20) + (cStats.DEX - 10) / 2);
    }

    private void OnMouseEnter()
    {
        if (inBattle)
        {
            ToolHud.gameObject.SetActive(true);
            ToolHud.SetHUD(this);
        }
    }
    private void OnMouseExit()
    {
        if (inBattle)
        {
            ToolHud.gameObject.SetActive(false);
        }
    }

    
    protected virtual IEnumerator DashPull(Vector3 origin, Vector3 target)
    {
        transform.LookAt(target);
        Vector3 targ = (target - base.transform.position) * 0.85f + base.transform.position;
        float tmp = 0f;
        int num;
        for (int ticks = 0; ticks < 100; ticks = num + 1)
        {
            transform.position = Vector3.Lerp(origin, targ, tmp);
            transform.position = new Vector3(transform.position.x, origin.y, transform.position.z);
            yield return new WaitForSeconds(0.01f);
            tmp += 0.025f;
            if (tmp >= 1f)
            {
                break;
            }
            num = ticks;
        }
        navMesh.enabled = true;
        navMesh.destination = transform.position;
        navMesh.isStopped = true;
        yield return new WaitForSeconds(5);
    }

    private int newWalkCost;
    private int walkCost = 1;
    public IEnumerator UseSkill(Transform target)
    {
        
        usedSkill = MySkills[0];

        if (GetComponent<CharStats>().actionPoints - usedSkill.apCost < 0)
        {
            Debug.Log("нет AP");
            goto exit;
        }
        this.newWalkCost = this.walkCost * (((target.position - base.transform.position).magnitude / 2.5f < 1f) ? 1
            : ((int)Mathf.Floor((target.position - base.transform.position).magnitude / 2.5f)));
        if (newWalkCost > cStats.actionPoints)
        {
            newWalkCost = cStats.actionPoints;
        }
        APUpdate(-newWalkCost);
        APText.APUpadeate(GetComponent<CharStats>().actionPoints);

        SMovement(target);

    exit:
        yield break;
    }

    public IEnumerator UseSkill(ActiveSkill skill, Transform target)
    {
        this.usedSkill = skill;

        if (GetComponent<CharStats>().actionPoints -usedSkill.apCost < 0)
        {
            Debug.Log("нет AP");
            goto exit;
        }

        APUpdate(-usedSkill.apCost);
        APText.APUpadeate(GetComponent<CharStats>().actionPoints);

        if (usedSkill.isPhysical)
        {
            transform.LookAt(target.position);
            charAnims.SetTrigger("Attack");
        }


        targetEntity = target.GetComponent<Entities>();
        if (skill.isPhysical)
        {
            Debug.Log("противник - " + targetEntity.Name +
                " получает урон в " + 
                targetEntity.GetComponent<CharStats>().CalcDamagePhysical(skill.CalcDamage(cStats)));
        }


    exit:
        yield return new WaitForSeconds(5);
    }

    protected void SMovement(Transform targ)
    {
        charAnims.SetBool("movSpeed", true);
        transform.LookAt(targ.position);
        //Vector3 target = (targ.position - transform.position) * 0.95f + transform.position;
        //StartCoroutine(DashPull(transform.position, target));
        navMesh.destination = targ.position;
        return;

    }

    public virtual void APUpdate(int value)
    {
        cStats.actionPoints += value;
        cStats.actionPoints = Mathf.Clamp(this.cStats.actionPoints, 0, this.cStats.actionPoinsMax);
    }
}
