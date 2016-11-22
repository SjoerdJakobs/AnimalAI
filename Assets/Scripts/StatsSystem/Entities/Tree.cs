using UnityEngine;
using System.Collections;

public class Tree : Plant {
    override protected void Death()
    {
        base.Death();
        DestroyObject(gameObject);
    }
}
