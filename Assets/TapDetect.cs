using UnityEngine;
using TMPro;

public class TapDetect : MonoBehaviour
{
    public TextMeshProUGUI infoText;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            DetectTap(Input.GetTouch(0).position);
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            DetectTap(Input.mousePosition);
        }
#endif
    }

    void DetectTap(Vector2 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // 🔥 Distance from bottom of model (world space)
            float height = hit.point.y;

            // 🔥 Normalize based on approximate range
            if (height > 2.0f)
            {
                infoText.text = "Head";
            }
            else if (height > 1.5f)
            {
                infoText.text = "Chest";
            }
            else if (height > 1.0f)
            {
                infoText.text = "Abdomen";
            }
            else
            {
                infoText.text = "Legs";
            }
        }
    }
}