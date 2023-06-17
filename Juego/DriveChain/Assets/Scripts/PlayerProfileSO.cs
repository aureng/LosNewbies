using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "Player/CharacterStats")]
public class PlayerProfileSO : ScriptableObject
{
    public int SpeedProfile = 5;
    public int Ataque = 5;
    public int Defensa = 5;
}
