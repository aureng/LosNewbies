using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "Player/CharacterStats")]
public class PlayerProfileSO : ScriptableObject
{
    public int speed = 5;
    public int att = 5;
    public int def = 5;
    public int life = 100;
    public int xperience = 0;
    public int skillsPoints=3;
}
