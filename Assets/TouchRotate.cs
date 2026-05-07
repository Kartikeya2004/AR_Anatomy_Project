using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // TOUCH (PHONE)
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Moved)
            {
                float rot = t.deltaPosition.x * speed * Time.deltaTime;
                transform.Rotate(0, -rot, 0, Space.Self);
            }
        }

#if UNITY_EDITOR
        // Mouse test
        if (Input.GetMouseButton(0))
        {
            float rot = Input.GetAxis("Mouse X") * speed;
            transform.Rotate(0, -rot, 0, Space.Self);
        }
#endif
    }
}