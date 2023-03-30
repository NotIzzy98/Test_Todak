using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Skill2JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private float maxDisplacement = 200;
    Vector2 startPos;
    Transform handle;

    public GameObject Skill2Button;
    public GameObject Skill2Circle;
    public Skill2Start skill2Start;

    public Image Skill2BG;
    public Image Skill2JoystickI;
    public Image Skill2Range;

    public CancelButton cancelButton;
    public bool cancel = false;

    public static float Horizontal = 0, Vertical = 0;
    // Start is called before the first frame update
    void Start()
    {
        Skill2BG = GetComponent<Image>();
        Skill2JoystickI = GameObject.Find("Skill2Joystick").GetComponent<Image>();
        Skill2Range = Skill2Circle.GetComponent<Image>();

        var TempColor = Skill2BG.color;
        TempColor.a = 0;
        Skill2BG.color = TempColor;
        Skill2JoystickI.color = TempColor;
        Skill2Range.color = TempColor;

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
        Skill2Button.SetActive(false);
        cancelButton.EnableCancel();
        cancel = false;

        var TempColor = Skill2BG.color;
        TempColor.a = 1;
        Skill2BG.color = TempColor;
        Skill2JoystickI.color = TempColor;
        Skill2Range.color = TempColor;

        skill2Start.Skill2Commence();

        UpdateHandlePosition(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateHandlePosition(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var TempColor = Skill2BG.color;
        TempColor.a = 0;
        Skill2BG.color = TempColor;
        Skill2JoystickI.color = TempColor;
        Skill2Range.color = TempColor;

        if (cancel == false)
        {
            skill2Start.SummonSkill2();
            skill2Start.Skill2Done();
        }

        cancelButton.DisableCancel();
        Skill2Button.SetActive(true);
    }

    public void Skill2Over()
    {
        var TempColor = Skill2BG.color;
        TempColor.a = 0;
        Skill2BG.color = TempColor;
        Skill2JoystickI.color = TempColor;
        Skill2Range.color = TempColor;

        skill2Start.Skill2Done();
        Skill2Button.SetActive(true);
    }
}
