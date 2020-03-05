using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    public GameObject panelRoot;
    public GameObject menu;
    public GameObject closedMenu;
    public unAnchorUI changeAnchor;

    private bool isClosed = false;
    private Vector3 iniPosition;

    void Start()
    {
        closedMenu.SetActive(false);
        iniPosition = this.transform.localPosition;
    }
    


    private void OnTriggerEnter(Collider other)
    {
        if (isClosed)
        {
            isClosed = false;
            closedMenu.SetActive(false);
            menu.SetActive(true);
            this.transform.parent = menu.transform;
            this.transform.localPosition = iniPosition;
        }
        else
        {
            if (panelRoot.transform.parent == null)
            {
                changeAnchor.AnchorUi();
            }

            isClosed = true;
            closedMenu.SetActive(true);
            menu.SetActive(false);
            this.transform.parent = panelRoot.transform;
            this.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
    
}
