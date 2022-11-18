using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class SJSon{
    private Dictionary<string,SJSerializeObj> storyTrees;

    public void Awake(){
        StoryTreeInit();
    }

    public void StoryTreeInit(){
        storyTrees = new Dictionary<string, SJSerializeObj>();
        LoadAllSJson();
    }

    public void LoadAllSJson(){
        bool createFlag = !Directory.Exists(@"./SJSON");
        if(createFlag){
            Directory.CreateDirectory(@"./SJSON");
            Global.Log("建立SJSON路徑");
        }
        string[] files = Directory.GetFiles(@"./SJSON");
        Global.Log($"發現{files.Length}個檔案");
        List<string> sjsonPath = new List<string>();
        foreach(string file in files){
            //Global.Log(file);
            if(file.Substring(file.Length - 5) == ".json"){
                sjsonPath.Add(file);
            }
            else{
                Global.Log($"test {file.Substring(file.Length - 5)}");
            }
        }
        if(sjsonPath.Count == 0){
            Global.Log("找不到sjson檔");
            return;
        }
        foreach(string xsmlPath in sjsonPath){
            LoadSJson(File.ReadAllText(xsmlPath));
        }
    }

    public void LoadSJson(string jsonString){
        try{
            Global.Log(jsonString);
            SJSerializeObj temp = JsonUtility.FromJson<SJSerializeObj>(jsonString);
            Global.Log(temp.title);
            if(storyTrees.ContainsKey(temp.title)){
                Global.Log("Load SJson Error! get multi title");
            }else{
                Global.Log($"Load SJson Complete! Get story - {temp.title}");
                storyTrees.Add(temp.title, temp);
                ReadSJson(temp);
            }
        }
        catch (Exception e){
            Global.Log($"Load SJson Error! get error: {e.Message}, \nat line {e.StackTrace}");
        }
    }

    public void ReadSJson(SJSerializeObj sjson){
        Global.Log($"讀取 {sjson.title}");
        Global.Log($"test: {sjson.SJParts}");
        Global.Log($"此章節共有 {sjson.SJParts.Count}個部分");
        Global.Log("----------------------------");
        foreach(SJPart p in sjson.SJParts){
            p.ToString();
        }
    }
}