//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//public class IconGenerator : MonoBehaviour
//{
//    private Camera _camera;

//    public string PathFolder;
//    public List<GameObject> SceneObjects;
//    public List<InventoryItemData> DataObjects;

//    private void Awake()
//    {
//        _camera = GetComponent<Camera>();
//    }

//    [ContextMenu("Screenshot")]
//    private void ProcessScreenshot()
//    {
//        StartCoroutine(Screenshot());
//    }

//    private IEnumerator Screenshot()
//    {
//        for (int i = 0; i < SceneObjects.Count; i++)
//        {
//            GameObject obj = SceneObjects[i];
//            InventoryItemData data = DataObjects[i];

//            obj.gameObject.SetActive(true);
//            yield return null;

//            TakeScreenshot($"{Application.dataPath}/{PathFolder}/{data.Id}_Icon.png");

//            yield return null;
//            obj.gameObject.SetActive(false);

//            Sprite s = AssetDatabase.LoadAssetAtPath<Sprite>($"Assets/{PathFolder}/{data.Id}_Icon.png");
//            if (s != null)
//            {
//                data.Icon = s;
//                EditorUtility.SetDirty(data);
//            }
//            yield return null;
//        }
//    }

//    void TakeScreenshot(string fullPath)
//    {
//        if (_camera == null)
//        {
//            _camera = GetComponent<Camera>();
//        }

//        RenderTexture renderTexture = new RenderTexture(256, 256, 24);
//        _camera.targetTexture = renderTexture;

//        Texture2D screenshot = new Texture2D(256, 256, TextureFormat.RGBA32, false);
//        _camera.Render();

//        RenderTexture.active = renderTexture;
//        screenshot.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);

//        _camera.targetTexture = null;
//        RenderTexture.active = null;

//        if (Application.isEditor)
//            DestroyImmediate(renderTexture);
//        else
//            Destroy(renderTexture);

//        byte[] bytes = screenshot.EncodeToPNG();
//        System.IO.File.WriteAllBytes(fullPath, bytes);

//#if UNITY_EDITOR
//        AssetDatabase.Refresh();
//#endif
//    }
//}
