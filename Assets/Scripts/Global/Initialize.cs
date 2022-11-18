using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour
{
    //[初始化物件]
    public TextAsset xsmlScheme;

    void Awake(){
        Init();
    }

    private void Init(){
        GlobalInit();
        //XSMLInit();
        SJsonInit();
    }

    private void GlobalInit(){
        Global.Init();
    }

    private void XSMLInit(){
        Global.xsmlReader = new XSMLReader();
        Global.xsmlReader.xsmlSchema = xsmlScheme;
        Global.xsmlReader.Awake();
    }

    private void SJsonInit(){
        Global.SJSonReader = new SJSon();
        Global.SJSonReader.Awake();
    }
}
