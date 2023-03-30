using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Skill3Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Skill3Start skill3Start;
    public GameObject range;

    public CancelButton cancelButton;
    public bool cancel = false;
    // Start is called before the first frame update
    void Start()
    {
        range.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        range.SetActive(true);
        cancelButton.EnableCancel();
        cancel = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        range.SetActive(false);
        if (cancel == false)
        {
            skill3Start.SpawnShield();
        }
        cancelButton.DisableCancel();
    }

    public void Skill3Cancel()
    {
        range.SetActive(false);
    }
}
