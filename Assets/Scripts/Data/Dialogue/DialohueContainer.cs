using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Dialogue/DialohueContainer")]
public class DialohueContainer : ScriptableObject
{

    public List< string> line;
    public ActorData actorData;
}
