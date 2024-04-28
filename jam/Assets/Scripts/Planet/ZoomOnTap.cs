using UnityEngine;

public class ZoomOnTap : MonoBehaviour
{
    public Move moveScript;
    private bool _move = true;
    private Vector3 _lastPosition;
    private Vector3 _moonOffset; // Added to store the offset between the object and the moon
    public Camera mainCamera;
    public GameObject moon;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition); // Use mainCamera instead of Camera.main
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                var rig = hitInfo.collider.GetComponent<Rigidbody>();
                if (rig != null)
                {
                    Debug.LogWarning("has touched object");
                    _move = !_move;
                    moveScript.enabled = _move;
                    if (!_move)
                    {
                        // Zoom in when clicking on the object
                        Debug.LogWarning("Zoom in");
                        rig.constraints = RigidbodyConstraints.FreezeAll;
                        _lastPosition = transform.position;
                        _moonOffset = moon.transform.position - transform.position; // Calculate the offset
                        Vector3 newPosition = mainCamera.transform.position + mainCamera.transform.forward * 4f;
                        rig.transform.position = newPosition;

                        // Apply the same offset to the moon's position
                        moon.transform.position = rig.transform.position + _moonOffset;
                    }
                    else
                    {
                        rig.constraints = RigidbodyConstraints.None;
                        rig.velocity = transform.right * moveScript.velocityX * Time.deltaTime;
                        rig.transform.position = _lastPosition;

                        // Apply the same offset to the moon's position
                        moon.transform.position = rig.transform.position + _moonOffset;
                    }
                    Debug.LogWarning("move: " + _move);
                }
            }
        }
    }
}
