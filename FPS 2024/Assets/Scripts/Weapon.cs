using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponModel weapon;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletImpact;
    int magazine, bulletForShoot;
    float timeToShoot;
    int fireRate;
    float spread;

    MeshRenderer meshRenderer;
    MeshFilter meshFilter;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshFilter = GetComponentInChildren<MeshFilter>();
        
        magazine = weapon.MagazineCap;
        timeToShoot = weapon.TimeBetweenShoots;
        bulletForShoot = weapon.BulletsForrShoot;
        spread = weapon.Spread;

        meshFilter.mesh = weapon.Model;
        meshRenderer.material = weapon.Material;
    }

    private IEnumerator FireCoroutine()
    {
        magazine--; 

        if (Time.time > timeToShoot)
        {

            timeToShoot = Time.time + 1 / fireRate;

            for (int i = 0; i < bulletForShoot; i++)
            {
                Shoot();
                yield return new WaitForSeconds(timeToShoot);
            }
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        Vector3 direction = Vector3.forward * Time.deltaTime;
        float range = weapon.Range + weapon.Spread;

        if (Physics.Raycast(firePoint.position, direction, out hit, range))
        {
            Collider obj = hit.transform.GetComponent<Collider>();
            if (obj != null)
            {
                Debug.Log(obj.gameObject.name);
                Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }

        Debug.DrawLine(firePoint.position, firePoint.position + direction * range);
    }
    private IEnumerator ReloadCoroutine()
    {
        if ()
        {

        }
    }

    private void Update()
    {
        
    }
}

