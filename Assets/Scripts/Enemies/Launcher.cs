using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcher : MonoBehaviour
{
    public SpikeProjectile launcherPrefab;

    [SerializeField]
    int startAfterSecs,
        repeatEachSecs;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(startAfterSecs);

        while (true)
        {
        launcherPrefab.GetProjectile(
            this.transform.forward,
            this.transform.position,
            this.transform.rotation
        );

            yield return new WaitForSeconds(repeatEachSecs);
        }
    }
}
