using System.Collections.Generic;
using UnityEngine;

public class XmlTree{
    //public string node {get;private set;}
    public string value {get;private set;}
    public List<XmlTree> leafs {get;private set;}
    
    public XmlTree(string value){
        this.value = value;
        leafs = new List<XmlTree>();
    }

    public void AddLeaf(XmlTree leaf){
        leafs.Add(leaf);
    }
    
    public void SetValue(string value){
        this.value = value;
    }

    public XmlTree GetNext(int nextPointer){
        if(leafs.Count <= 0) return null;
        return leafs[nextPointer];
    }
}

public abstract class XmlTreeNode{
    public string vlaue;
    public  XmlTreeNode(string value){
        this.vlaue = value;
    }
}