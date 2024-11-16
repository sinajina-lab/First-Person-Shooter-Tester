using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyActions : MonoBehaviour
{


    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float hitPoints;
    [SerializeField] protected float health;
    [SerializeField] protected Animator animator;
    [SerializeField] protected GameObject enemyModel;
    [SerializeField] protected GameObject coinPrefabs;

    private void Start()
    {
        
    }
    protected virtual void AttackPlayer()
    {

    }
    protected virtual void DropCoins()
    {
        //get the coinCount
        //instantia coinPrefabs for each coin
        
    }
}
