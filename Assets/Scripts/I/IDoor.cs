using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDoor : IInteractible, IDamageable
{
    public void FlipOpen();

}
