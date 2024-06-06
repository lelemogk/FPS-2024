using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponModel weapon;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletImpact;
    int megazine;

    MeshRenderer meshRenderer;
    MeshFilter meshFilter;

    // Start is called before the first frame update
    void Start()
    {
         meshRenderer = GetComponentInChildren<MeshRenderer>();
         meshFilter = GetComponentInChildren<MeshFilter>();

        megazine = weapon.MagazineCap;

        meshFilter.mesh = weapon.Model;
        meshRenderer.material = weapon.Material;
    }

    private IEnumerator FireCoroutine()
    {
        // Verifica se pode disparar

        // Reduz a muni��o do carregador
        // Define o tempo para o pr�ximo disparo

        // Dispara proj�teis com o tempo entre cada disparo
    }


    
    void Update()
    {
        
    }
}
