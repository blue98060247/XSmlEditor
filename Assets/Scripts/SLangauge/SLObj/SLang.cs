using System.Collections.Generic;

//此類別為對所有的SLang檔進行讀取與寫入的管理員

public class SLang{

    private Dictionary<string,SLStory> storyTrees;

    public void Awake(){
        StoryTreeInit();
    }

    public void StoryTreeInit(){
        storyTrees = new Dictionary<string, SLStory>();
        LoadAllSLang();
    }

    public void LoadAllSLang(){
        bool createFlag = !Directory.Exists(@"./SLang");
        if(createFlag){
            Directory.CreateDirectory(@"./SLang");
            Global.Log("建立SLang路徑");
        }
        string[] files = Directory.GetFiles(@"./SLang");
        Global.Log($"發現{files.Length}個檔案");
        List<string> slangPath = new List<string>();
        foreach(string file in files){
            //Global.Log(file);
            if(file.Substring(file.Length - 5) == ".json"){
                slangPath.Add(file);
            }
            else{
                Global.Log($"test {file.Substring(file.Length - 5)}");
            }
        }
        if(slangPath.Count == 0){
            Global.Log("找不到sjson檔");
            return;
        }
        foreach(string langPath in slangPath){
            LoadSLang(File.ReadAllText(langPath));
        }
    }

    public void LoadSLang(string slangString){
        try{
            Global.Log(slangString);
            SLStory temp = new SLStory(slangString);
        }
        catch (Exception e){
            Global.Log($"Load SJson Error! get error: {e.Message}, \nat line {e.StackTrace}");
        }
    }
}