using System.Collections.Generic;

/// <summary>
/// SJSON序列化用的物件
/// </summary>
[System.Serializable]
public class SJSerializeObj{
    public string key;
    public string title;
    public List<SJPart> SJParts;
}

/// <summary>
/// SJSON最基本的部件，所有SJSON物件皆必須繼承此部件
/// </summary>
[System.Serializable]
public abstract class SJPart{
    public string key;

    public abstract override string ToString();
}

[System.Serializable]
public class SetCharacter{
    
    public string Character;
}

[System.Serializable]
public class DialogueObj : SJPart{
    public string dialogue;

    public override string ToString()
    {
        return $"對話: {dialogue}";
    }
}

[System.Serializable]
public class SelectPartObj : SJPart{
    public List<Part> part;

    public override string ToString()
    {
        string partsStr = "";
        foreach(Part p in part){
            partsStr += part.ToString() + "\n";
        }
        return $"選擇: 有 {part.Count}個選項\n{partsStr}";
    }
}

[System.Serializable]
public class Part {
    public string OptionString;
    public SetCharacter setCharacter;
    public DialogueObj dialogue;
    public JumpObj jump;

    public override string ToString()
    {
        string op = ((setCharacter != null)? setCharacter.ToString() : "") + 
                    ((dialogue != null)? dialogue.ToString() : "") + 
                    ((jump != null)? jump.ToString() : "") ;
        return $"選項: {OptionString}{((op.Length>0)?$" op: { op }" : "")}";
    }
}

[System.Serializable]
public class JumpObj : SJPart{
    public string jumpKey;

    public override string ToString()
    {
        return $"跳至: {jumpKey}";
    }
}