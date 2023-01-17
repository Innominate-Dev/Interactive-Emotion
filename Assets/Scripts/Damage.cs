using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float DistanceX = 1f;
    public float DistanceY = 1f;

    ShootingSystem Shooter;
    EnemyAI EnemyController;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        Shooter = GetComponent<ShootingSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(DistanceX, DistanceY, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                if (Shooter.Shooting == true)
                {
                    EnemyController.TakeDamage(1);
                }
            }
        }
    }
}
