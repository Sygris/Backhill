using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Highlight))]
public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;
    public Sprite InteractionIcon;
    public Vector2 IconSize;
}
