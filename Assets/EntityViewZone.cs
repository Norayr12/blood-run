using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class EntityViewZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<EnemyBase>(out EnemyBase entity))
        {
            Debug.Log(entity);
        }
    }
}
