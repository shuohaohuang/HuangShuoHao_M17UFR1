using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public SpikeProjectile launcherPrefab;

    [SerializeField]
    int startAfterSecs,
        repeatEachSecs;

    void Start()
    {
        StartCoroutine(DelayStart());
    }

    private IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(startAfterSecs);
        yield return Shoot();
    }
    private IEnumerator Shoot()
    {


        launcherPrefab.GetProjectile(
            this.transform.forward,
            this.transform.position,
            this.transform.rotation
        );

        yield return new WaitForSeconds(repeatEachSecs);

        yield return Shoot();
    }

}
