using UnityEngine;
using System.Collections.Generic;

public class BodyLayerManager : MonoBehaviour
{
    [System.Serializable]
    public class BodyLayer
    {
        public string layerName;
        public GameObject layerObject;
        [HideInInspector] public Material originalMaterial;
        [HideInInspector] public Material[] originalMaterials;
    }

    public List<BodyLayer> layers = new List<BodyLayer>();
    public Color highlightColor = new Color(0f, 0.8f, 1f, 0.8f); // cyan glow
    public Material highlightMaterial; // assign in Inspector

    private BodyLayer currentHighlighted = null;

    public void HighlightLayer(string name)
    {
        // Reset previous
        if (currentHighlighted != null)
            ResetLayer(currentHighlighted);

        // Find and highlight new
        BodyLayer target = layers.Find(l => l.layerName == name);
        if (target == null) return;

        Renderer[] renderers = target.layerObject
                               .GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            // Save originals
            target.originalMaterials = r.materials;
            // Apply highlight
            Material[] mats = new Material[r.materials.Length];
            for (int i = 0; i < mats.Length; i++)
                mats[i] = highlightMaterial;
            r.materials = mats;
        }

        currentHighlighted = target;
    }

    private void ResetLayer(BodyLayer layer)
    {
        Renderer[] renderers = layer.layerObject
                               .GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            if (layer.originalMaterials != null)
                r.materials = layer.originalMaterials;
        }
    }

    public void ResetAll()
    {
        if (currentHighlighted != null)
            ResetLayer(currentHighlighted);
        currentHighlighted = null;
    }
}