using System;

public class TreeNode
{
    public string QuestionOrAnswer { get; set; }
    public TreeNode YesChild { get; set; }
    public TreeNode NoChild { get; set; }

    public TreeNode(string questionOrAnswer)
    {
        QuestionOrAnswer = questionOrAnswer;
    }

    public void AddChildren(TreeNode childYes, TreeNode childNo)
    {
        this.ChildYes = childYes;
        this.ChildNo = childNo;
    }


    public static TreeNode BuildQuestionTree()
    {
        //Questions:
        /** 
         * 1. Is it in Europe? 
         *     yes Is English one of the primary languages? 
         *          yes Is it Ireland?
         *              no Is it the United Kingdom?
         *          no Is it a slavic country?
         *              yes is it Poland?
         *              no is it France?
         *     no Is it in Asia
         *          yes Is it in East Asia?
         *              yes Is it China?
         *              no Is it in South Asia?
         *                  yes Is it India?
         *                  no Is it Indonesia?
         *          no Is it in the Americas?
         *              yes Is it in South America?
         *                  yes Is it Argentina?
         *                  no Is it the U.S.?
         *              no Is it in Africa?
         *                  yes Is it Chad?
         *                  no Is it Australia?
         * 
         */

        // Guesses
        var uk = new TreeNode("Is it the United Kingdom?");
        var ireland = new TreeNode("Is it Ireland?");
        var poland = new TreeNode("Is it Poland?");
        var france = new TreeNode("Is it France?");
        var india = new TreeNode("Is it India?");
        var china = new TreeNode("Is it China?");
        var indonesia = new TreeNode("Is it Indonesia?");
        var argentina = new TreeNode("Is it Argentina?");
        var usa = new TreeNode("Is it the U.S.?");
        var chad = new TreeNode("Is it Chad?");
        var australia = new TreeNode("Is it Australia?");

        //question nodes
        //In europe is ROOT
        var isEnglishPrimary = new TreeNode("Is English one of the primary languages?");
        isEnglishPrimary.YesChild = ireland;
        isEnglishPrimary.NoChild = new TreeNode("Is it a Slavic country?");
        isEnglishPrimary.NoChild.YesChild = poland;
        isEnglishPrimary.NoChild.NoChild = france;

        var isInEastAsia = new TreeNode("Is it in East Asia?");
        isInEastAsia.YesChild = china;
        isInEastAsia.NoChild = new TreeNode("Is it in South Asia?");
        isInEastAsia.NoChild.YesChild = india;
        isInEastAsia.NoChild.NoChild = indonesia;

        var isInAsia = new TreeNode("Is it in Asia?");
        isInAsia.YesChild = isInEastAsia;
        isInAsia.NoChild = new TreeNode("Is it in the Americas?");
        isInAsia.NoChild.YesChild = new TreeNode("Is it in South America?");
        isInAsia.NoChild.YesChild.YesChild = argentina;
        isInAsia.NoChild.YesChild.NoChild = usa;
        isInAsia.NoChild.NoChild = new TreeNode("Is it in Africa?");
        isInAsia.NoChild.NoChild.YesChild = chad;
        isInAsia.NoChild.NoChild.NoChild = australia;

        var inEurope = new TreeNode("Is it in Europe?");
        inEurope.YesChild = isEnglishPrimary;
        inEurope.NoChild = isInAsia;

        ireland.NoChild = uk;

        //return root
        var root = inEurope;
        return root;
    }   
}