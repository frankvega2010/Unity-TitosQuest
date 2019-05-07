using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviourSingleton<PlayerController>
{
    public Vector3 target;
    public GameObject tube;
    public LayerMask rayCastLayer;
    public float rayDistance;

    private Vector3 posPlayer;
    private Vector3 posTarget;
    private Vector3 posPlayerCannon;
    private Vector3 posTargetCannon;
    private string targetName;
    //private float reachTargetTime;
    //private float reachedTargetRot;
    //private bool switchOnce = false;
    //private bool switchOnce2 = false;

    public override void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //reachTargetTime = Time.deltaTime * 1.2f;
        rotateToTarget();
        //checkReachedTarget();

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

    public void switchTarget(Vector3 newTarget, string name)
    {
        target = newTarget;
        targetName = name;
    }

    private void rotateToTarget()
    {
        if(target != null)
        {
            posPlayer = new Vector3(transform.position.x, 0, transform.position.z);
            posTarget = new Vector3(target.x, 0, target.z);
        }
        else
        {
            posPlayer = new Vector3(0, 0, 0);
            posTarget = new Vector3(0, 0, 0);
        }

        if (target != null)
        {
            posPlayerCannon = new Vector3(0, tube.transform.position.y, tube.transform.position.z);
            posTargetCannon = new Vector3(0, target.y, target.z);
        }
        else
        {
            posPlayerCannon = new Vector3(0, 0, 0);
            posTargetCannon = new Vector3(0, 0, 0);
        }

        

        Quaternion movingToTargetCannon = Quaternion.identity;
        movingToTargetCannon.SetLookRotation(posTargetCannon - posPlayerCannon, Vector3.up);

        Quaternion movingToTarget = Quaternion.identity;
        movingToTarget.SetLookRotation(posTarget - posPlayer, transform.up);

        transform.rotation = Quaternion.Slerp(transform.rotation, movingToTarget, Time.deltaTime * 1.2f);
        tube.transform.localRotation = Quaternion.Slerp(tube.transform.localRotation, movingToTargetCannon, Time.deltaTime * 1.5f);
    }

    //private void checkReachedTarget()
    //{
    //    Debug.Log(reachedTargetRot);

    //    if (reachedTargetRot > 0.8f)
    //    {
    //        if(!switchOnce)
    //        {
    //            GetComponent<MeshRenderer>().material.color = Color.black;
    //            switchOnce = true;
    //        }
            
    //    }
    //    else if (reachedTargetRot < 0.8f)
    //    {
    //        if (!switchOnce2)
    //        {
    //            GetComponent<MeshRenderer>().material.color = Color.white;
    //            switchOnce2 = true;
    //        }
            
    //    }
    //}
}
