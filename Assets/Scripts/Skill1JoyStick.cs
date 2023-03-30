using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Skill1JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private float maxDisplacement = 200;
    Vector2 startPos;
    Transform handle;

    public GameObject Skill1Button;
    public GameObject Skill1Phase2;
    public GameObject Skill1;
    public GameObject Skill1Circle;
    public GameObject Skill1Directon;

    public Image Skill1Joystick;
    public Image Skill1JoystickBG;
    public Image Skill1CircleI;
    public Image Skill1DirectionI;

    public Skill1Spawn skill1start;

    public CancelButton cancelButton;
    public bool cancel = false;

    public static float Horizontal = 0, Vertical = 0;

    void Start()
    {
        Skill1Joystick = GetComponent<Image>();
        Skill1JoystickBG = Skill1.GetComponent<Image>();
        Skill1CircleI = Skill1Circle.GetComponent<Image>();
        Skill1DirectionI = Skill1Directon.GetComponent<Image>();

        var TempColor = Skill1Joystick.color;
        TempColor.a = 0;
        Skill1Joystick.color = TempColor;
        Skill1JoystickBG.color = TempColor;
        Skill1CircleI.color = TempColor;
        Skill1DirectionI.color = TempColor;

        Skill1Phase2.SetActive(false);

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
        Skill1Button.SetActive(false);
        cancelButton.EnableCancel();
        cancel = false;

        var TempColor = Skill1Joystick.color;
        TempColor.a = 1;
        Skill1Joystick.color = TempColor;
        Skill1JoystickBG.color = TempColor;
        Skill1CircleI.color = TempColor;
        Skill1DirectionI.color = TempColor;

        UpdateHandlePosition(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateHandlePosition(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var TempColor = Skill1Joystick.color;
        TempColor.a = 0;
        Skill1Joystick.color = TempColor;
        Skill1JoystickBG.color = TempColor;
        Skill1CircleI.color = TempColor;
        Skill1DirectionI.color = TempColor;

        if (cancel == false)
        {
            Skill1Phase2.SetActive(true);

            skill1start.Skill1Commence();
            Invoke("Skill1Ends", 2);
        }
        else
        {
            Invoke("Skill1Ends", 0);
        }

        cancelButton.DisableCancel();
        UpdateHandlePosition(startPos);
    }

    public void Skill1Ends()
    {
        var TempColor = Skill1Joystick.color;
        TempColor.a = 0;
        Skill1Joystick.color = TempColor;
        Skill1JoystickBG.color = TempColor;
        Skill1CircleI.color = TempColor;
        Skill1DirectionI.color = TempColor;

        CancelInvoke();
        Skill1Phase2.SetActive(false);
        Skill1Button.SetActive(true);
    }
}
