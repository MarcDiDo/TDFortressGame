using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitpoints = 3;
    [SerializeField] int currentHitpoints = 0;
    [SerializeField] int difficultyRampUp = 1;

    Enemy enemy; 
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitpoints = maxHitpoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitpoints--;

        if (currentHitpoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitpoints += difficultyRampUp;
            enemy.RewardGold();
        }
    }
}
