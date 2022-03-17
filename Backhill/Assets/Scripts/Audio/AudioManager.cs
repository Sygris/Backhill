using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Pool Settings")]
    public GameObject prefabToPool;
    public int amountToPool;
    private List<GameObject> pooledPrefabs = new List<GameObject>();

    void Start()
    {
        instance = this;

        CreateInstances();
    }

    public void PlaySound(AudioClip clip, Vector3 position, float volume = 1)
    {
        GameObject prefab = GetPoolObject();

        if (prefab == null) return;

        prefab.transform.position = position;
        prefab.SetActive(true);

        AudioSource prefabAudioSource = prefab.GetComponent<AudioSource>();

        prefabAudioSource.clip = clip;
        prefabAudioSource.volume = volume;
        prefabAudioSource.Play();

        StartCoroutine(BackToPool(prefab, clip.length));
    }

    private void CreateInstances()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject go = Instantiate(prefabToPool, gameObject.transform);
            go.SetActive(false);
            pooledPrefabs.Add(go);
        }
    }

    private GameObject GetPoolObject()
    {
        for (int i = 0; i < pooledPrefabs.Count; i++)
        {
            if (pooledPrefabs[i].gameObject.transform.parent == gameObject.transform)
                if (!pooledPrefabs[i].gameObject.activeInHierarchy)
                    return pooledPrefabs[i];
        }

        return null;
    }

    public void DisablePool()
    {
        foreach (GameObject prefab in pooledPrefabs)
        {
            prefab.transform.parent = gameObject.transform;
            prefab.SetActive(false);
        }
    }

    IEnumerator BackToPool(GameObject prefab, float seconds, bool unparent = false)
    {
        yield return new WaitForSeconds(seconds);

        if (unparent)
        {
            prefab.transform.parent = gameObject.transform;
        }

        prefab.SetActive(false);
    }
}
