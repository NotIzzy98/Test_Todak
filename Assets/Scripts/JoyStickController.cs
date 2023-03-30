using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private float maxDisplacement = 200;
    Vector2 startPos;
    Transform handle;

    public GameObject rotation;

    public static float Horizontal = 0, Vertical = 0;

    void Start()
    {
        rotation.SetActive(false);
        handle = transform.GetChild(0);
        startPos = handle.position;
    }

    void UpdateHandlePosition(Vector2 pos)
    {
        var delta = pos - startPos;
        delta = Vector2.ClampMagnitude(delta, maxDisplacement);
        handle.position = startPos + delta;
        Horizontal = delta.x;
        Vertical = delta.y;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rotation.SetActive(true);
        UpdateHandlePosition(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateHandlePosition(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rotation.SetActive(false);
        UpdateHandlePosition(startPos);
    }
}
