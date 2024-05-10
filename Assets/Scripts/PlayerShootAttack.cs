using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootAttack : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform pivotRot;
    [SerializeField] float shotDelay;
    [SerializeField] float burstShotCount;
    [SerializeField] float burstDelay;

    [SerializeField] bool toogleClickShooting;

    Camera cam;
    float angle;

    private void Start()
    {
        cam = Camera.main;

        HandlePeriodicShooting();
    }

    void Update()
    {
        GetMouseAngle();
        HandleClickShooting();
    }

    void GetMouseAngle()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        pivotRot.rotation = Quaternion.Euler(0, 0, angle);
    }

    void HandleClickShooting()
    {
        if (!toogleClickShooting) return;
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle));
        }
    }

    void HandlePeriodicShooting()
    {
        StartCoroutine(PeriodicShooting());
    }

    IEnumerator PeriodicShooting()
    {
        yield return new WaitForSeconds(shotDelay);

        while (true)
        {
            for (int i = 0; i < burstShotCount; i++)
            {
                Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle));

                yield return new WaitForSeconds(burstDelay);
            }

            yield return new WaitForSeconds(shotDelay);
        }
    }

    public void MultiplyShotDelay(float multiplier)
    {
        shotDelay *= multiplier;
    }

    public void ChangeBurstCount(int increment)
    {
        burstShotCount += increment;
    }
}
