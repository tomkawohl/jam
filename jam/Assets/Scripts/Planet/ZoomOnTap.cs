using UnityEngine;

public class ZoomOnTap : MonoBehaviour
{
    public Move moveScript;
    private float pollution = 100;
    private string planetName = "Planet";
    private string description = "Planet super cool";
    private bool _move = true;
    private Vector3 _lastPosition;
    private Vector3 _moonOffset;
    public Camera mainCamera;
    public GameObject moon;
    public PlanetInfoUI planetInfoUI; // Référence au script PlanetInfoUI

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
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
                        _moonOffset = moon.transform.position - transform.position;
                        Vector3 newPosition = mainCamera.transform.position + mainCamera.transform.forward * 4f;
                        rig.transform.position = newPosition;
                        moon.transform.position = rig.transform.position + _moonOffset;

                        // Activer le panneau UI et mettre à jour les informations de la planète
                        planetInfoUI.gameObject.SetActive(true);
                        planetInfoUI.UpdatePlanetInfo(planetName, description, pollution);
                    }
                    else
                    {
                        rig.constraints = RigidbodyConstraints.None;
                        rig.velocity = transform.right * moveScript.velocityX * Time.deltaTime;
                        rig.transform.position = _lastPosition;
                        moon.transform.position = rig.transform.position + _moonOffset;

                        // Désactiver le panneau UI lorsque la planète est désélectionnée
                        planetInfoUI.gameObject.SetActive(false);
                    }
                    Debug.LogWarning("move: " + _move);
                }
            }
        }
    }
}
