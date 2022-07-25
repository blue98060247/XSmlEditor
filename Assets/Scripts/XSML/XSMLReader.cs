using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class XSMLReader
{
    public TextAsset xsmlSchema;
    private XmlApi xmlApi;
    private Dictionary<string,StoryTree.Chapter> storyTrees;


    // Start is called before the first frame update
    public void Awake()
    {
        if(xsmlSchema) xmlApi = new XmlApi(xsmlSchema);

        StoryTreeInit();
    }

    private void StoryTreeInit(){
        storyTrees = new Dictionary<string, StoryTree.Chapter>();
        if(xsmlSchema) LoadAllXsml();
    }

    public void LoadAllXsml(){
        bool createFlag = !Directory.Exists(@"./Xsml");
        if(createFlag){
            Directory.CreateDirectory(@"./Xsml");
            Global.logger.WriteLog("建立Xsml路徑");
        }
        string[] files = Directory.GetFiles(@"./Xsml");
        Global.logger.WriteLog($"發現{files.Length}個檔案");
        List<string> xsmlsPath = new List<string>();
        foreach(string file in files){
            if(file.Substring(file.Length - 5) == ".xsml"){
                xsmlsPath.Add(file);
            }
            else{
                Global.logger.WriteLog($"test {file.Substring(file.Length - 5)}");
            }
        }
        if(xsmlsPath.Count == 0){
            Global.logger.WriteLog("找不到xsml檔");
            return;
        }
        foreach(string xsmlPath in xsmlsPath){
            LoadXsml(xsmlPath);
        }
    }

    private void LoadXsml(string path){
        bool pass = xmlApi.AddXml(path);
        if(!pass) {
            Global.logger.WriteLog($"新增xsml失敗: {path}");
            return;
        }
        
    }
}
