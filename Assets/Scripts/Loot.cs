﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayLoot.PlaySound();
            GameManager.instance.loot++;
            Destroy(this.gameObject);
        }
    }
}
