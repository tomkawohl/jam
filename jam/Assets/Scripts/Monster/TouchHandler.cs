using UnityEngine;
using UnityEngine.InputSystem;

public class TouchHandler : MonoBehaviour
{
    void Update()
    {
        if (Touchscreen.current != null) {
            if (Touchscreen.current.primaryTouch.press.isPressed) {
                Vector3 inputPosition = Touchscreen.current.primaryTouch.position.ReadValue();

                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(inputPosition);
                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
                
                if (hit.collider != null && hit.collider.CompareTag("Monster")) {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        if (Mouse.current != null) {
            if (Mouse.current.leftButton.wasPressedThisFrame) {
                Vector3 inputPosition = Mouse.current.position.ReadValue();

                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(inputPosition);
                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
                Debug.DrawLine(touchPosition, hit.point, Color.red, 1f);
                Debug.Log("Hit: " + hit.collider.name);
                
                if (hit.collider != null && hit.collider.CompareTag("Monster")) {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
