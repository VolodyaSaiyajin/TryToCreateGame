using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float WallCheckDistance = 0.2f;
    public float LedgeCheckDistance = 0.4f;
    public float VisibilityRange = 4f;

    public int Heath = 100;

    public LayerMask WhatIsTouched;
    public LayerMask WhatIsGround;
    public LayerMask WhatIsEnemy;
}
