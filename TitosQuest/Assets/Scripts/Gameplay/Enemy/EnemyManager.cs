using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviourSingleton<EnemyManager>
{
    public int maxEnemies;
    public GameObject enemy;
    public GameObject proyectileNotDestroyed;
    public GameObject droppedItem;

    private List<Enemy> enemies = new List<Enemy>();
    private Missile proyectile;
    private GameManager GameMgr;
    public override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    private void Start()
    {
        GameMgr = GameManager.Get();

        for (int i = 0; i < maxEnemies; i++)
        {
            GameObject go = Instantiate(enemy, new Vector3(Random.Range(270.0f, 290.0f), Random.Range(135.0f,180.0f), 1280), Quaternion.identity);
            Enemy e = go.GetComponent<Enemy>();
            e.name = "Enemy " + i;
            e.OnEnemyDeath = KillEnemy;
            e.OnEnemyOutLevelBounds = DestroyEnemy;
            enemies.Add(e);
        }
    }
    
    public int getEnemiesLeft()
    {
        return enemies.Count;
    }

    private void KillEnemy(Enemy e)
    {
        MeshRenderer enemyMeshRenderer = e.GetComponent<MeshRenderer>();
        Missile missileToDestroy = e.proyectileAffected.GetComponent<Missile>();

        GameMgr.addPoints();
        enemyMeshRenderer.material.color = Color.red;
        enemies.Remove(e);
        missileToDestroy.DestroyMissile();
        DropItem(e);
        Destroy(e.gameObject);
    }

    private void DropItem(Enemy e)
    {
        droppedItem.SetActive(true);

        GameObject droppedItemCopy = Instantiate(droppedItem, new Vector3(e.transform.position.x, e.transform.position.y, e.transform.position.z), Quaternion.identity);
        droppedItem.SetActive(false);
    }

    private void DestroyEnemy(Enemy e)
    {
        Missile proyectileToDestroy;

        if (proyectileNotDestroyed)
        {
            proyectileToDestroy = proyectileNotDestroyed.GetComponent<Missile>();
            proyectileToDestroy.DestroyMissile();
        }

        GameMgr.substractPoints();
        enemies.Remove(e);
        Destroy(e.gameObject);
    }
}
