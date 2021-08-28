using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Rigidbody m_RigidBody;
    private int enemyLevel;
    private int damage;
    

    public void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        EnemyRandomMovement();

    }


    public virtual void EnemyRandomMovement()
    {
        float randomDirectionX = Random.Range(180,-180);
        float randomDirectionZ = Random.Range(180,-180);
        Vector3 forceDir = new Vector3(randomDirectionX, 0, randomDirectionZ);
        forceDir.Normalize();
        m_RigidBody.AddForce(forceDir * (5f - enemyLevel), ForceMode.VelocityChange);
        m_RigidBody.AddTorque(forceDir* (5f - enemyLevel), ForceMode.Impulse);
    }
    

    public void BreakApart()
    {
        if  (enemyLevel > 1)
        {
        enemyLevel -= 1;
        GameManager.Instance.EnemySpawner(enemyLevel);
        Destroy(gameObject, 0.01f);
        } else if (enemyLevel <= 1)
        {
            Destroy(gameObject, 0.01f);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        damage = enemyLevel;
        var manaCore = collision.collider.GetComponentInParent<ManaCoreBehavior>();       
        if(manaCore != null)
        {
        manaCore.health -= damage;
        Destroy(gameObject, 0.01f);
        }
        
    }

    public void EnemyMovementBoundary()
    {

    }
  

}
