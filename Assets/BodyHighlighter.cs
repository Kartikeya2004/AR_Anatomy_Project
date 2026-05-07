using UnityEngine;

public class BodyHighlighter : MonoBehaviour
{
    public Renderer head;
    public Renderer chest;
    public Renderer arms;
    public Renderer legs;

    private Color normalColor = Color.white;
    private Color highlightColor = Color.yellow;

    void ResetAll()
    {
        head.material.color = normalColor;
        chest.material.color = normalColor;
        arms.material.color = normalColor;
        legs.material.color = normalColor;
    }

    public void ShowHead()
    {
        ResetAll();
        head.material.color = highlightColor;
    }

    public void ShowChest()
    {
        ResetAll();
        chest.material.color = highlightColor;
    }

    public void ShowArms()
    {
        ResetAll();
        arms.material.color = highlightColor;
    }

    public void ShowLegs()
    {
        ResetAll();
        legs.material.color = highlightColor;
    }
}