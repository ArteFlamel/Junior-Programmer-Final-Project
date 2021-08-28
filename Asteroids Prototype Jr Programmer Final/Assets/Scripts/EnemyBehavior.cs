using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Rigidbody m_RigidBody;
    private int enemyLevel;
    

    public void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();

    }


    public virtual void EnemyRandomMovement()
    {
        float randomDirection = Random.Range(-90.0f, 90.0f);
        Vector3 forceDir = new Vector3(randomDirection, 1, 0);
        forceDir.Normalize();
        m_RigidBody.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
    }
    

    public virtual void BreakApart()
    {
        GameManager.Instance.EnemySpawner(enemyLevel);
    }

    public virtual void Damager()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
    public void Destroyed()
    {

    }
  

}
