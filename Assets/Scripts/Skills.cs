using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : ScriptableObject
{
    public new string name;
    [TextArea()]
    public string description;
    public Sprite sprite;
}
