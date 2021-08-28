using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;

    private EnemyBehavior m_Selected = null;

    public void Update()
    {
        ClickedPolluter();
    }

    public void ClickedPolluter()
    {
        
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Selected something");
            var enemy = hit.collider.GetComponentInParent<EnemyBehavior>();
            m_Selected = enemy;
            
            if (m_Selected != null)
            {
                m_Selected.BreakApart();
                
            }


            //check if the hit object have a IUIInfoContent to display in the UI
            //if there is none, this will be null, so this will hid the panel if it was displayed
            //var uiInfo = hit.collider.GetComponentInParent<UIMainScene.IUIInfoContent>();
            //UIMainScene.Instance.SetNewInfoContent(uiInfo);
        }
    }


}
