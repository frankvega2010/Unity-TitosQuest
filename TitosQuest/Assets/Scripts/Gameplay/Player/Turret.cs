using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject missile;
    public bool isFiring;

    private Transform startFrom;
    private EnemyManager enemyMgr;

    private void Start()
    {
        startFrom = GetComponentInParent<Transform>();
        enemyMgr = EnemyManager.Get();
    }

    public void Shoot(GameObject target)
    {
        if (!isFiring)
        {
            isFiring = true;
            missile.SetActive(true);

            GameObject missileCopy = Instantiate(missile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Missile missileComponentCopy = missileCopy.GetComponent<Missile>();
            missileComponentCopy.GetComponent<BoxCollider>().enabled = true;

            missileComponentCopy.target = target.transform.gameObject;
            missileComponentCopy.dirFrom = startFrom.position;
            missileComponentCopy.isFired = true;
            enemyMgr.proyectileNotDestroyed = missileCopy;
        }
    }
}
