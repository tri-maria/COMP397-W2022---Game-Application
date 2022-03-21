using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataScriptableObject", menuName = "Scriptable Objects")]

public class PlayerDataScriptableObject : ScriptableObject
{
    private string m_playerID = "A123456";
    public string playerID {
        get
        {
            return m_playerID;
         }
    }
    public string name;
    public int health;
    public Vector3 position;
    public Quaternion rotation;


}
