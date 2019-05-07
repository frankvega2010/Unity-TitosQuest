using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.Get();
    }

    private void OnMouseDown()
    {
        player.switchTarget(gameObject.transform.position,gameObject.name);
    }
}
