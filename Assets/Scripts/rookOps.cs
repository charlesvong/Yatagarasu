using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rookOps : MonoBehaviour
{
    public Texture uniform;
    public GameObject model;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeToGuard() {
        Renderer m_Renderer = model.GetComponent<Renderer>();
        Material[] mats = m_Renderer.materials;
        mats[0].mainTexture = uniform;
        mats[1].mainTexture = uniform;
        mats[2].mainTexture = uniform;
        m_Renderer.materials = mats;
        this.transform.Find("model").GetComponent<Animator>().SetBool("uniform", true);
    }
}
