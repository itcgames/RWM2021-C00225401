﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Enemy
    {
        private player Player;
        private Follow enemyFollow;
        private WanderExplode enemyWE;

        [SetUp]
        public void Setup()
        {
            GameObject playerGameObject =
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
            Player = playerGameObject.GetComponent<player>();

            GameObject enemyFGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/EnemyFollow"));
            enemyFollow = enemyFGameObject.GetComponent<Follow>();

            GameObject enemyWEGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/EnemyExplode"));
            enemyWE = enemyWEGameObject.GetComponent<WanderExplode>();

        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(Player.gameObject);
            Object.Destroy(enemyFollow.gameObject);
            Object.Destroy(enemyWE.gameObject);
        }

        // Enemy Follow------------------------------------------
        [UnityTest]
        public IEnumerator EnemySleepsUntilPlayerInRange()
        {
            enemyFollow.transform.position = Vector3.zero;
            enemyFollow.ignoreCollisions = true;
            enemyFollow.wakeRadius = 10.0f;
            Player.transform.position = Vector3.zero;

            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(enemyFollow.awake);
        }

        [UnityTest]
        public IEnumerator EnemyMovesTowardsPlayerWhenAwake()
        {
            enemyFollow.transform.position = Vector3.zero;
            enemyFollow.awake = true;
            Player.transform.position = new Vector3(2.0f,1.0f,0.0f);
            float distBefore = Vector3.Distance(Player.transform.position, enemyFollow.transform.position);

            yield return new WaitForSeconds(0.5f);

            float distAfter = Vector3.Distance(Player.transform.position, enemyFollow.transform.position);

            Assert.IsTrue(distBefore > distAfter);
        }

        // Enemy Wander Explode-----------------------------------------------------
        [UnityTest]
        public IEnumerator EnemyMoveCounterDecreases()
        {
            float prev = enemyWE.getCounter();
            yield return new WaitForSeconds(0.5f);
            float present = enemyWE.getCounter();
            Assert.IsTrue(prev > present);
        }

        [UnityTest]
        public IEnumerator EnemyMovesTowardsPlayerCounterIsZero()
        {
            float distBefore = Vector3.Distance(Player.transform.position, enemyWE.transform.position);
            enemyWE.setCounter(0);
            yield return new WaitForSeconds(0.5f);
            float distAfter = Vector3.Distance(Player.transform.position, enemyWE.transform.position);
            Assert.IsTrue(distBefore > distAfter);
        }
    }
}
