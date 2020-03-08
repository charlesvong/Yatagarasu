using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogPresent : MonoBehaviour
{
    public presentingObj obj;
    public dialogManager dManager;
    public RawImage present;
    public checkList check;

    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show(GameObject fab) {
        obj.setTarget(fab);
        obj.initiateObj();
        obj.transform.Rotate(0.0f, 0.0f, 180.0f);
        this.gameObject.SetActive(true);
    }

    public void Show2d(Texture tex)
    {
        present.texture = tex;
        check.receiveHint(tex);
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        obj.destroyObj();
        this.gameObject.SetActive(false);
    }
}
