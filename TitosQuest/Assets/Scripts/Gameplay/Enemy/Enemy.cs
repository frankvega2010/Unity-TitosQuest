using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerController player;
    private bool sameCollision = false;
    private bool oldCollision = false;
    private MeshRenderer enemyMeshRenderer;
    private Missile proyectile;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.Get();
        enemyMeshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        transform.position = transform.position + transform.up * -1 * 1 * Time.deltaTime;
    }

    private void OnMouseDown()
    {
        player.switchTarget(gameObject.transform,gameObject.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "missile")
        {
            proyectile = collision.gameObject.GetComponent<Missile>();

            switchColors();
            Invoke("switchToNormal", 0.5f); 
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "missile")
    //    {
    //        oldCollision = false;
    //        switchColorsToNormal();
    //        Debug.Log("Is hit");
    //    }
    //}

    private void switchColors()
    {
        enemyMeshRenderer.material.color = Color.red;
    }

    private void switchToNormal()
    {
        enemyMeshRenderer.material.color = Color.white;
        proyectile.DestroyMissile();
        Destroy(gameObject);
    }
}
