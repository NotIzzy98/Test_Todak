using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CancelButton : MonoBehaviour, IPointerEnterHandler
{
    public Skill1JoyStick skill1JoyStick;
    public Skill2JoyStick skill2JoyStick;
    public Skill3Button skill3Button;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void EnableCancel()
    {
        gameObject.SetActive(true);
    }

    public void DisableCancel()
    {
        gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        skill1JoyStick.cancel = true;
        skill2JoyStick.cancel = true;
        skill3Button.cancel = true;
        skill1JoyStick.Skill1Ends();
        skill2JoyStick.Skill2Over();
        skill3Button.Skill3Cancel();
        gameObject.SetActive(false);
    }
}
