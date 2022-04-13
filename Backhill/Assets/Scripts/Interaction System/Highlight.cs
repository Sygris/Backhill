using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    [Header("Highlight Settings")]
    [SerializeField] private Color _highlightColor = new Vector4(89f, 89f, 89f, 255f);

    List<Material> _materials = new List<Material>();

    void Start()
    {
        _highlightColor = new Vector4(89f, 89f, 89f, 255f);

        if (GetComponent<MeshRenderer>() != null)
        {
            // Tries to get the MeshRenderer component from the GameObject
            foreach (var material in GetComponent<MeshRenderer>().materials)
            {
                _materials.Add(material);
            }
        }
        else
        {
            // If the GameObject does not have the MeshRenderer Component it tries to get it from its children
            MeshRenderer[] childrenMeshRenderers = transform.GetComponentsInChildren<MeshRenderer>();
            foreach (var meshRenderer in childrenMeshRenderers)
            {
                foreach (var material in meshRenderer.materials)
                {
                    _materials.Add(material);
                }
            }
        }
    }

    public void Select()
    {
        foreach (var material in _materials)
        {
            material.SetColor("_Emission", _highlightColor);
        }
    }

    public void Deselect()
    {
        foreach (var material in _materials)
        {
            material.SetColor("_Emission", Color.black);
        }
    }
}
