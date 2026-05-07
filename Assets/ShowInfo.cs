using UnityEngine;
using TMPro;

public class ShowInfo : MonoBehaviour
{
    public TextMeshProUGUI infoText;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            infoText.text = "Human Anatomy Model\nMuscle Structure Visualization";
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            infoText.text = "Human Anatomy Model\nMuscle Structure Visualization";
        }
#endif
    }
}