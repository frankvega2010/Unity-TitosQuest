using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviourSingleton<PlayerController>
{
    public Transform target;
    public GameObject tube;
    public GameObject turretGameObject;
    public LayerMask rayCastLayer;
    public float rayDistance;

    private Turret playerTurret;
    private Vector3 posPlayer;
    private Vector3 posTarget;
    private Vector3 posPlayerCannon;
    private Vector3 posTargetCannon;
    private string targetName;

    public override void Awake()
    {
        base.Awake();
        playerTurret = turretGameObject.GetComponent<Turret>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        rotateToTarget();

        if (Physics.Raycast(tube.transform.position, tube.transform.forward, out hit, rayDistance, rayCastLayer))
        {
            Debug.DrawRay(tube.transform.position, tube.transform.forward * hit.distance, Color.white);

            string layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            switch (layerHitted)
            {
                case "enemy":
                    if(hit.transform.gameObject.name == targetName)
                    {
                        Debug.DrawRay(tube.transform.position, tube.transform.forward * hit.distance, Color.yellow);
                        playerTurret.Shoot(hit.transform.gameObject);
                        Debug.Log("Can Hit");
                    }
                    break;
            }
        }
        else
        {
            Debug.DrawRay(tube.transform.position, tube.transform.forward * rayDistance, Color.white);
        }
    }

    public void switchTarget(Transform newTarget, string name)
    {
        target = newTarget;
        targetName = name;
    }

    private void rotateToTarget()
    {
        Quaternion movingToTargetCannon = Quaternion.identity;

        if (target != null)
        {
            posPlayer = new Vector3(transform.position.x, 0, transform.position.z);
            posTarget = new Vector3(target.transform.position.x, 0, target.transform.position.z);

            
            movingToTargetCannon.SetLookRotation(posTargetCannon - posPlayerCannon, target.transform.up);
        }
        else
        {

            posPlayer = new Vector3(0, 0, 0);
            posTarget = new Vector3(0, 0, 0);
        }

        if (target != null)
        {
            posPlayerCannon = new Vector3(0, tube.transform.position.y, tube.transform.position.z);
            posTargetCannon = new Vector3(0, target.transform.position.y, target.transform.position.z);
        }
        else
        {
            posPlayerCannon = new Vector3(0, 0, 0);
            posTargetCannon = new Vector3(0, 0, 0);
        }

        Quaternion movingToTarget = Quaternion.identity;
        movingToTarget.SetLookRotation(posTarget - posPlayer, transform.up);

        transform.rotation = Quaternion.Lerp(transform.rotation.normalized, movingToTarget.normalized, Time.deltaTime * 2.0f);
        tube.transform.localRotation = Quaternion.Lerp(tube.transform.localRotation.normalized, movingToTargetCannon.normalized, Time.deltaTime * 10.0f);
    }
}
