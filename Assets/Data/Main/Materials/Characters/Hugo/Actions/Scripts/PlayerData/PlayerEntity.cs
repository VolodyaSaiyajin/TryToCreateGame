using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    [SerializeField] private Transform _eyePosition;
    public Transform EyePosition => _eyePosition;
}
