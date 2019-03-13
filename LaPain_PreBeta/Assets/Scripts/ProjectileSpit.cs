using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpit : MonoBehaviour
{
    public int damage;

    public float speed;
    public float lifeTime;
    public float distance;

    SnekoMovement snekoMovement;

    PlaceHolder_Health playerHealth;
    GameObject player;

    private Vector3 targetLocation;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        snekoMovement = GameObject.Find("Sneko").GetComponent<SnekoMovement>();
        player = GameObject.Find("Player");
        if (player != null)
        {
            playerHealth = GameObject.Find("Player").GetComponent<PlaceHolder_Health>();
            targetLocation = -(transform.position - player.transform.position);           
        }
        
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player") && player != null)
            {
                playerHealth.TakeDamage(damage);
                DestroyProjectile();
            }           
        }

        //transform.Translate(new Vector2(player.transform.position.x, player.transform.position.y) * speed * Time.deltaTime);
        transform.Translate(targetLocation * speed * Time.deltaTime, Space.World);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}