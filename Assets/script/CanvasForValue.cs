using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasForValue : MonoBehaviour
{
    public float offsetX=0;
    public float offsetY=1;
    public static CanvasForValue instance;
    public GameObject tempText;
    public Dictionary<int, TMP_Text> nodeMapText = new Dictionary<int, TMP_Text>();

    public Color negColor = Color.black;
    public Color posColor = Color.black;
    public Color nullColor = Color.black;

    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddTextToNode(CellNode cellNode)
    {
        Vector3 pos = cellNode.transform.position;
        //在pos生成text并设置数值
        GameObject obj = Instantiate(tempText, transform);
        obj.transform.position = new Vector3(pos.x+offsetX,pos.y+offsetY,0);
        TMP_Text t = obj.GetComponent<TMP_Text>();
        t.text = ((int)Mathf.Abs(cellNode.curValue)).ToString();
        nodeMapText.Add(cellNode.GetInstanceID(), t);
    }
    public void UpdateCanvasText(CellNode cellNode)
    {
        TMP_Text t ;
        if(!nodeMapText.TryGetValue(cellNode.GetInstanceID(), out t))
        {
            Debug.Log("字典错误");
            return;
        }
        int value = cellNode.curValue;
        if (value < 0)
        {
            value = -value;
            t.color = negColor;
        }
        else if (value == 0)
        {
            t.color = nullColor;
        }
        else
        {
            t.color = posColor;
        }

        t.text = value.ToString();
      
        DOsomething(t.gameObject, value);
    }

    public void DOsomething(GameObject o, float size)
    {
        // sound
        Debug.Log("DOsomething");
    

        float scale = 1.1f * size/250;
        float duration = 0.2f;
        float half = duration / 2;
        Vector3 vec3 = new Vector3(scale, scale, scale);
        LeanTween.scale(o, vec3, half).setOnComplete(() =>
        {
            LeanTween.scale(o, Vector3.one, half);
        });
    }

}
