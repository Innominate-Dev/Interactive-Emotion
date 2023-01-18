using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public GameObject Bullets;
    public GameObject Barrel;

    public static bool PlayerShooting;

    [SerializeField] ParticleSystem inkParticle;

    void Start()
    {
        PlayerShooting = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            inkParticle.Play();
            PlayerShooting = true;
            if (PlayerShooting == true)
            {
                StartCoroutine(BulletShooting());
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            inkParticle.Stop();
            PlayerShooting = false;
        }
    }
    private void Shootings()
    {
        GameObject bulletObject = Instantiate(Bullets);
        bulletObject.transform.position = Barrel.transform.position + transform.forward;
        bulletObject.transform.forward = Barrel.transform.forward;
    }
    IEnumerator BulletShooting()
    {
        for (var i = 0; i < 10; i++)
        {
            //StartCoroutine(BulletShooting());
            GameObject bulletObject = Instantiate(Bullets);
            bulletObject.transform.position = Barrel.transform.position + transform.forward;
            bulletObject.transform.forward = Barrel.transform.forward;
            yield return new WaitForSeconds(1f);
        }
    }
}
