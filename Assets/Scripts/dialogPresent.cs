using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogPresent : MonoBehaviour
{
    public presentingObj obj;
    public dialogManager dManager;

    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show() {
        (GameObject fab, Material mat) = dManager.generateObj();
        obj.setTarget(fab);
        obj.setMaterial(mat);
        obj.initiateObj();
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        obj.destroyObj();
        this.gameObject.SetActive(false);
    }
}
