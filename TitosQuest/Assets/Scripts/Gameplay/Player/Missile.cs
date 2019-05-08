using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public bool isFired = false;
    public Vector3 dirFrom;
    public float lifespan;

    private Vector3 dir;
    private GameObject objectAffected;
    private Turret playerTurret;

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = dirFrom;
        playerTurret = player.GetComponent<Turret>();
    }

    // Update is called once per frame
    private void Update()
    {

        if (isFired)
        {
            lifespan += Time.deltaTime;
            Quaternion q01 = Quaternion.identity;

            if (target)
            {
                dir = transform.position - target.transform.position;
                q01.SetLookRotation(target.transform.position - transform.position, transform.up);
            }
            else
            {
                Destroy(gameObject);
            }
            
            transform.position = transform.position - dir.normalized * 20.5f * Time.deltaTime;
            transform.rotation = q01;

            if (lifespan > 5)
            {
                lifespan = 0;
                isFired = false;
                playerTurret.isFiring = false;
                Destroy(gameObject);
            }
        }
    }

    public void DestroyMissile()
    {
        isFired = false;
        playerTurret.isFiring = false;
        Destroy(gameObject);
    }
}
