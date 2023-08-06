using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Character owner;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var other = collision.GetComponent<Character>();

        if (other != null && other != owner)
        {
            other.HP.Value -= owner.Attack.Value;

            if(other.HP.Value <= 0)
            {
                owner.EXP.Value += 10;
                Destroy(other.gameObject);
            }
        }
    }
}
