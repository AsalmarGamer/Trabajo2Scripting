using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerUnit", menuName = "PlayerUnit")]
public class Units : ScriptableObject
{
    public new string name;

    public int HP;
    public int AtkPoints;
    public int DefPoints;

    public Sprite _sprite;

    public int PM;
    public int PA;

    public void TakeDMG()
    {

    }
    public void Move()
    {

    }

    public void Attack()
    {

    }

    public void Ultimate()
    {

    }

    public void Die()
    {

    }
}
