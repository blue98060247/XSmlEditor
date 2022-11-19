using System.Collections.Generic;

/// <summary>
/// SLang之StoryTree之基本物件，一個SLStory即為StoryTree的一個節點(Leaf)
/// </summary>
public class SLStory : SLObj{
    // 設定header所占用的空間
    public static readonly int headerStruct = 1;

    public List<string> attributes;
    public string title;

    /// <summary>
    /// SLParts為一順序型故事元件，不可使用SLStory作為故事元件的一部份
    /// </summary>
    public List<SLObj> SLParts;

    public SLStory(string slang){
        // 使用LineHelper，一行一行進行處理
        LineHelper line = new LineHelper(slang);
        string[] header = line.GetLines(headerStruct);
        // 取得header
        title = 
    }
}