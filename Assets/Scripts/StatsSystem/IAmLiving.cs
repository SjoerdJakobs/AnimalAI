using UnityEngine;
using System.Collections;

public interface IAmLiving
{
    void TakeDamage(float damage);

    void GetEaten(Animal eatingEntity);

    void Eat();
}
