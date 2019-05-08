using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerController player;

    public delegate void EnemyKilledAction(Enemy enemy);
    public delegate void EnemyOffLevel(Enemy enemy);
    public EnemyKilledAction OnEnemyDeath;
    public EnemyOffLevel OnEnemyOutLevelBounds;
    public GameObject proyectileAffected;

    // Start is called before the first frame update
    void Start()
    {
        proyectileAffected = null;
        player = PlayerController.Get();
    }

    private void Update()
    {
        transform.position = transform.position + transform.up * -1 * 2 * Time.deltaTime;
    }

    private void OnMouseDown()
    {
        player.switchTarget(gameObject.transform,gameObject.name);
    }

    private void KillAction()
    {
        if (OnEnemyDeath != null)
            OnEnemyDeath(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "missile")
        {
            proyectileAffected = collision.gameObject;
            KillAction();
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "limit")
        {
            if (OnEnemyOutLevelBounds != null)
                OnEnemyOutLevelBounds(this);
        }
    }
}
