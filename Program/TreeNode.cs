using System;

class TreeNode
{
    public string Data;
    public TreeNode ChildYes;
    public TreeNode ChildNo;
    public TreeNode Parent;

    public TreeNode(string data)
    {
        this.Data = data;
        ChildYes = null;
        ChildNo = null;
        Parent = null;
    }

    public void AddChildren(TreeNode childYes, TreeNode childNo)
    {
        this.ChildYes = childYes;
        this.ChildNo = childNo;
    }
    
}