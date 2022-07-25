using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StoryTree{
    public enum StoryTreeNodeType{
    None,
    Chapter,
    Character,
    Dialogue,
    SelectPart,

}

    public abstract class StoryTreeNode{
        public List<StoryTreeNode> children;
        public abstract StoryTreeNodeType type { get;}
        public string content; 

    }

    public class Chapter : StoryTreeNode{
        public override StoryTreeNodeType type { get {return StoryTreeNodeType.Chapter;}}
    }

    public class Character : StoryTreeNode{
        public override StoryTreeNodeType type { get {return StoryTreeNodeType.Character;}}
    }

    public class Dialogue : StoryTreeNode{
        public override StoryTreeNodeType type { get {return StoryTreeNodeType.Dialogue;}}
    }

    public class SelectPart : StoryTreeNode{
        public override StoryTreeNodeType type { get {return StoryTreeNodeType.SelectPart;}}
    }
}