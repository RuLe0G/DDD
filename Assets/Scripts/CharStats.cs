using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharStats : MonoBehaviour
{
    public int actionPoints;
    public int actionPoinsMax = 12;

    public int INT;
    public int STR;
    public int CON;
    public int DEX;

    public float armor;
    public float magResist;

    public float HP;
    public float maxHP;

    public float physicalDamage;
    public float magicalDamage;


    public float[] elementResist = new float[]
        {
            1f,
            1f,
            1f,
            1f,
            1f
            };

        public void Awake()
    {
        CalcStat();
        HP = maxHP;
    }

    public void CalcStat()
    {
        armor = (float)CON / 2 + (float)DEX / 2 + 10;
        magResist = (float)INT * 3;
        maxHP = (float)CON * 2 + 15;
        magicalDamage = (float)INT * 2.5f;
        physicalDamage = (float)STR * 2.5f;
    }

    public float CalcDamagePhysical(float incomingDamage, StatusElements element = StatusElements.None)
    {
        float arm = armor;
        if (element != StatusElements.None)
        {
            arm *= (elementResist[((int)element)] > 0f ? elementResist[((int)element)] : 0f);
        }
        var outp = Mathf.Round(incomingDamage * (100 / (100 + arm)));
        HP -= outp;
        if (HP <= 0)
        {
            this.gameObject.GetComponent<Entities>().inBattle = false;
            this.gameObject.GetComponent<movement>().alive = false;
            this.gameObject.GetComponent<Entities>().charAnims.SetTrigger("Death");
        }
        else
        this.gameObject.GetComponent<Entities>().charAnims.SetTrigger("Impact");
        DamageUI.Instance.AddText((int)outp, new Vector3(transform.position.x,transform.position.y+1.5f, transform.position.z));
        return outp;
    }
    public float CalcDamageMagic(float incomingDamage, StatusElements element = StatusElements.None)
    {
        float arm = magResist;
        if (element != StatusElements.None)
        {
            arm *= (elementResist[((int)element)] > 0f ? elementResist[((int)element)] : 0f);
        }
        var outp = Mathf.Round(incomingDamage * (100 / (100 + arm)));
        HP -= outp;
        this.gameObject.GetComponent<Entities>().charAnims.SetTrigger("Impact");
        DamageUI.Instance.AddText((int)outp, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));
        return outp;
    }



    /// <summary>
    /// <param name="stat">stat - номер характеристики(1 - INT, 2 - STR, 3 - CON, 4 - DEX)</param>
    /// <param name="val">прирост (для уменьшения добавить минус)</param>
    public void СhangeStat(int stat, int val)
    {
        switch (stat)
        {
            case 1:
                INT += val;
                break;
            case 2:
                STR += val;
                break;
            case 3:
                CON += val;
                break;
            case 4:
                DEX += val;
                break;
        }
    }    
}

