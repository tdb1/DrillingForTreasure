﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MiteEnemy : Enemy {
    
    public float breakTime;

    public override void Start()
    {
        base.Start();
        InvokeRepeating("MiteMove", breakTime, breakTime);
    }
    public override void Update()
    {
        base.Update();
        
        aiAgent.canMove = canMove;
       // AIDestination.target = target;
        
    }
    public override void OnFollow()
    {
        base.OnFollow();
        //StartCoroutine(WaitAndGo());
    }
    public void MiteMove()
    {
        canMove = !canMove;
        Debug.Log("Changed");
      //StartCoroutine(WaitAndGo());
    }
    public override void OnAttack()
    {
        canMove = false;
        base.OnAttack();
    }
    public override void OnDeath(float WaitBeforeDestroying)
    {
<<<<<<< HEAD
        base.OnDeath(WaitBeforeDestroying);
=======
        base.OnDeath();
        CancelInvoke();
        renderer.sprite = deathSprite;
        Debug.Log("Mite Died");
>>>>>>> parent of a70fd12... Minor Changes. Properly merged with Cedric Branch
    }
    
}

