using UnityEngine;

public class Stamina : MonoBehaviour
{
    [Header("Stamina Settings")]
    public float PlayerStamina = 100.0f;
    [SerializeField] private float _maxStamina = 100.0f;
    [HideInInspector] public bool HasRegenerated = true;
    [HideInInspector] public bool IsPlayerSprinting = false;

    [Header("Stamina Regeneration Settings")]
    [Range(0, 50)] [SerializeField] private float _staminaDrain = 0.5f;
    [Range(0, 50)] [SerializeField] private float _staminaRegeneration = 0.5f;

    [Header("Stamina Speed Settings")]
    [SerializeField] private int _slowedRunSpeed = 4;
    [SerializeField] private int _normalRunSpeed = 4;

    //[Header("Stamina UI Elements")]
    //[SerializeField] private 

}
