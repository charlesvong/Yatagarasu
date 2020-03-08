using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class checkList : MonoBehaviour
{

    private RawImage[] blocks;
    private List<Texture> hints = new List<Texture>();
    private int cur_ind = 0;
    private int total;

    // Start is called before the first frame update
    void Start()
    {
        blocks = GetComponentsInChildren<RawImage>();
        total = blocks.Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void receiveHint(Texture tex) {
        if (!hints.Contains(tex))
        {
            hints.Add(tex);
            blocks[cur_ind].texture = tex;
            Color currColor = blocks[cur_ind].color;
            currColor.a = 1f;
            blocks[cur_ind].color = currColor;
            cur_ind += 1;
        }
    }
}
