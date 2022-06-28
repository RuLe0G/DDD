using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHuman : IDamageable
{
    public void Talk();
    public void SmallTalk();
    public void Die();

}
