using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage", menuName = "Stage Objects/Stage", order = 0)]
public class StageScriptableObject : ScriptableObject
{
    public Map[] maps;
}
