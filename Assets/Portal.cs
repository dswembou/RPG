using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private int sceneToLoad = -1;
    [SerializeField] Transform spawnPoint;
    [SerializeField] private float fadeOutTime = 1f;
    [SerializeField] private float fadeInTime = 2f;
    [SerializeField] private float fadeWaitTime = 1f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Transition());
        }
        
    }

    IEnumerator Transition()
    {
        DontDestroyOnLoad(gameObject);

        Fader fader = FindObjectOfType<Fader>();
        yield return fader.FadeOut(fadeOutTime);
        yield return SceneManager.LoadSceneAsync(sceneToLoad);
        
        Portal otherPortal = GetOtherPortal();
        UpdatePlayer(otherPortal);

        yield return new WaitForSeconds(fadeWaitTime);
        yield return fader.FadeIn(fadeInTime);
        
        Destroy(gameObject);
    }

    private void UpdatePlayer(Portal otherPortal)
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<NavMeshAgent>().Warp(otherPortal.spawnPoint.position);
        player.transform.rotation = otherPortal.spawnPoint.rotation;
    }

    private Portal GetOtherPortal()
    {
        foreach (Portal portal in FindObjectsOfType<Portal>())
        {
            if (portal == this) continue;

            return portal;
        }

        return null;
    }
}
