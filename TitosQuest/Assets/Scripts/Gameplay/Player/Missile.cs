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
    void Start()
    {
        transform.position = dirFrom;
        playerTurret = player.GetComponent<Turret>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isFired)
        {
            lifespan += Time.deltaTime;
            dir = transform.position - target.transform.position;
            transform.position = transform.position - dir * 3.5f * Time.deltaTime;
            //Debug.Log(dir);

            Quaternion q01 = Quaternion.identity;
            q01.SetLookRotation(target.transform.position - transform.position, transform.up);
            transform.rotation = q01;

            if (lifespan > 10)
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
