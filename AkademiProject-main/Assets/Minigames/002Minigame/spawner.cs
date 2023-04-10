using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mini1
{

    public class spawner : MonoBehaviour
    {
        [SerializeField] GameObject kure;
        [SerializeField] GameObject kare;

        GameObject b;
        GameObject a;

        private void Start()
        {
            StartCoroutine(coroutineA());
        }

        void spawnKare()
        {
            Vector3 pos = new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-4f, 4f), 0f);
            a = Instantiate(kare, pos, Quaternion.identity, this.transform);
        }
        void spawnKure()
        {
            Vector3 pos = new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-4f, 4f), 0f);
            b = Instantiate(kure, pos, Quaternion.identity, this.transform);
        }
        IEnumerator coroutineA()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(Random.Range(0.3f, 1.5f));
                spawnKure();
                yield return new WaitForSeconds(Random.Range(0.3f, 1.5f));
                spawnKare();
            }
        }
    }
}

