using UnityEngine;
using System.Collections;

public class FakeLoadScreen : MonoBehaviour
{
    public GameObject loadingScreen; 
    public float loadDuration = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FakeLoad());
        }
    }

    IEnumerator FakeLoad()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(loadDuration);
        loadingScreen.SetActive(false);
    }
}