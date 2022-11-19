using System.Collections.Generic;

/// <summary>
/// SLang之StoryTree之基本物件，一個SLStory即為StoryTree的一個節點(Leaf)
/// </summary>
public class SLStory : SLObj{
    public List<string> attributes;
    public string title;

    /// <summary>
    /// SLParts為一順序型故事元件，不可使用SLStory作為故事元件的一部份
    /// </summary>
    public List<SLObj> SLParts;

    public SLStory(string slang){
        
    }
}