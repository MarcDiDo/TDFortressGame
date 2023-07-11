using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] float buildDelay = 1f;

    private void Start()
    {
        StartCoroutine(BuildTower());
    }

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Gold gold = FindObjectOfType<Gold>();

        if (gold == null)
        {
            return false;
        }

        if (gold.CurrentGold >= cost)
        {
            Instantiate(tower, position, Quaternion.identity);
            gold.RemoveGold(cost);
            return true;
        }

        return false;
    }

    IEnumerator BuildTower()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach(Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }
        }
    }
}
