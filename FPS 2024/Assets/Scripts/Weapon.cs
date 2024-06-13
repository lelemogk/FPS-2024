using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletImpact;
    int magazine, bulletsForShoot;
    float timeToShoot;
    int fireRate;
    float spread;
    int currentMagazine;
    int ammo;

    MeshRenderer meshRenderer;
    MeshFilter meshFilter;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshFilter = GetComponentInChildren<MeshFilter>();
        
        magazine = weaponData.MagazineCap;
        timeToShoot = weaponData.TimeBetweenShoots;
        bulletsForShoot = weaponData.BulletsForShoot;
        spread = weaponData.Spread;

        meshFilter.mesh = weaponData.Model;
        meshRenderer.material = weaponData.Material;
    }

    void Fire()
    {
        StartCoroutine(FireCoroutine());
    }

    private IEnumerator FireCoroutine()
    {
        //Verifica se pode disparar
        if (Time.time >= timeToShoot)
        {
            timeToShoot = Time.time + 1 / weaponData.FireRate;

            for (int i = 0; i < weaponData.BulletsForShoot; i++)
            {
                if(currentMagazine > 0)
                {
                    currentMagazine--;
                    Shoot();
                    yield return new WaitForSeconds(weaponData.TimeBetweenShoots);
                }
            }
        }
    }

    private void Shoot()
    {
        // Variável para armazenar o que foi atingido
        RaycastHit hit;
        // Direção do disparo, considerando a dispersão da arma
        Vector3 direction = firePoint.forward + new Vector3(Random.Range(-weaponData.Spread, weaponData.Spread), Random.Range(-weaponData.Spread, weaponData.Spread), 0);
        // Verifica se acertou algo na direção do disparo dentro do alcance
        if (Physics.Raycast(firePoint.position, direction, out hit, weaponData.Range))
        {
            Instantiate(bulletImpact,hit.point, Quaternion.identity);
            // Desenha uma linha para visualizar o trajeto do projétil
            Debug.DrawLine(firePoint.position, direction * weaponData.Range);
        }

    }
    void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        if (currentMagazine < weaponData.MagazineCap && ammo > 0)
        {

        }
    }

    private void Update()
    {
        
    }
}

