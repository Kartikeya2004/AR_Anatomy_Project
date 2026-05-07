using UnityEngine;

public class HighlightButton : MonoBehaviour
{
    public BodyLayerManager manager;
    public string targetLayerName;

    public void OnButtonPressed()
    {
        manager.HighlightLayer(targetLayerName);
    }
}