using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "SceneDialogueSO")]
public class SceneSO : ScriptableObject
{
    [TextArea]
    public List<string> dialogueLines = new();
    public int cameraPriority;
}
