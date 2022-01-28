using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Dictionary Settings")]
    public List<string> clipName = new List<string>();
    public List<AudioClip> clipList = new List<AudioClip>();
    private Dictionary<string, AudioClip> clipLib = new Dictionary<string, AudioClip>();

    [Header("Pool Settings")]
    public GameObject prefabToPool;
    public int amountToPool;
    private List<GameObject> pooledPrefabs = new List<GameObject>();

    void Start()
    {
        instance = this;

        for (int i = 0; i < clipName.Count; i++)
            clipLib.Add(clipName[i], clipList[i]);

        CreateInstances();
    }

    public void PlaySound(string clip, Vector3 position, float volume = 1)
    {
        GameObject prefab = GetPoolObject();

        if (prefab == null) return;

        prefab.transform.position = position;
        prefab.SetActive(true);

        AudioSource prefabAudioSource = prefab.GetComponent<AudioSource>();

        prefabAudioSource.clip = clipLib[clip];
        prefabAudioSource.volume = volume;
        prefabAudioSource.Play();

        StartCoroutine(BackToPool(prefab, clipLib[clip].length));
    }

    public void PlaySound(AudioClip clip, Vector3 position, out float duration, float volume = 1)
    {
        GameObject prefab = GetPoolObject();

        if (prefab == null)
        {
            duration = 0;
            return;
        }

        prefab.transform.position = position;
        prefab.SetActive(true);

        AudioSource prefabAudioSource = prefab.GetComponent<AudioSource>();

        prefabAudioSource.clip = clip;
        prefabAudioSource.volume = volume;
        prefabAudioSource.Play();

        StartCoroutine(BackToPool(prefab, clip.length));

        duration = clip.length;
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

    public void PlaySound(string clip, GameObject parent, float volume = 1)
    {
        GameObject prefab = GetPoolObject();

        if (prefab == null) return;

        #region Configure Prefab
        prefab.transform.position = parent.transform.position;
        prefab.transform.parent = parent.transform;
        prefab.SetActive(true);
        #endregion

        #region Configure AudioSource
        AudioSource prefabAudioSource = prefab.GetComponent<AudioSource>();

        prefabAudioSource.clip = clipLib[clip];
        prefabAudioSource.volume = volume;
        prefabAudioSource.Play();
        #endregion

        StartCoroutine(BackToPool(prefab, clipLib[clip].length, true));
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
