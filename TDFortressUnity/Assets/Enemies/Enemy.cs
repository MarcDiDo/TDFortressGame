using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int goldReward = 25;
    [SerializeField] int goldDamage = 25;

    Gold gold;

    
    void Start()
    {
        gold = FindObjectOfType<Gold>();
    }

    public void RewardGold()
    {
        if(gold == null)
        {
            return;
        }
        gold.AddGold(goldReward);
    }

    public void StealGold()
    {
        if (gold == null)
        {
            return;
        }
        gold.RemoveGold(goldDamage);
    }
}
