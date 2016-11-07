using UnityEngine;
using System.Collections;

public class Tree : LivingEntity {
    override protected void Death()
    {
        base.Death();
        DestroyObject(gameObject);
    }
}
