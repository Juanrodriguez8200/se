using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootForce = 5f;
    public bool shootToRight = true;
    public float projectileLifetime = 3f;
    public float shootingDuration = 3f;
    public float restDuration = 4f;

   
    void Start()
    {
        StartCoroutine(AutoShoot());
    }

    private IEnumerator AutoShoot()
    {
        while (true)
        {
          

            float shootingTimer = 0f;

            while (shootingTimer < shootingDuration)
            {
                Shoot();
                yield return new WaitForSeconds(projectileLifetime);
                shootingTimer += projectileLifetime;
            }

           
            yield return new WaitForSeconds(restDuration);
        }
    }

    private void Shoot()
    {
        Vector2 shootDirection = shootToRight ? Vector2.right : Vector2.left;
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = shootDirection * shootForce;
        Destroy(projectile, projectileLifetime);

    }
}
