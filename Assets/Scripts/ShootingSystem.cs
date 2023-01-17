using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public GameObject Bullets;
    public GameObject Barrel;

    public bool Shooting;

    [SerializeField] ParticleSystem inkParticle;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            inkParticle.Play();
            Shooting = true;
            //if (Shooting == true)
            //{
            //    Invoke(nameof(Shootings), .2f);
            //}
        }
        else if (Input.GetMouseButtonUp(0))
        {
            inkParticle.Stop();
            Shooting = false;
        }
    }
    private void Shootings()
    {
        GameObject bulletObject = Instantiate(Bullets);
        bulletObject.transform.position = Barrel.transform.position + transform.forward;
        bulletObject.transform.forward = Barrel.transform.forward;
    }
   
}
