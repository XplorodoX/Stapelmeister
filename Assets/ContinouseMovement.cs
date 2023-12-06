using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRContinuousMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 1;
    public XRNode inputSource;

    private Vector2 inputAxis;
    private XRRig rig;
    private CharacterController character;

    void Start()
    {
        character = GetComponent<CharacterController>();
        if (character == null)
        {
            Debug.LogError("CharacterController not found on the GameObject.");
        }

        rig = GetComponent<XRRig>();
        if (rig == null)
        {
            Debug.LogError("XRRig not found on the GameObject.");
        }
    }

    void Update()
    {
        if (!TryGetInput())
        {
            return;
        }

        UpdateMovement();
    }

    private bool TryGetInput()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        return device.isValid && device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void UpdateMovement()
    {
        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        character.Move(direction * Time.deltaTime * speed);
    }
}
