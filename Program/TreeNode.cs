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
         *          yes Is it the United Kingdom?
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
        isEnglishPrimary.YesChild = uk;
        isEnglishPrimary.NoChild = new TreeNode("Is it a Slavic country?");
        var isSlavic = isEnglishPrimary.NoChild;
        isSlavic.YesChild = poland;
        isSlavic.NoChild = france;

        var isInSouthAsia = new TreeNode("Is it in South Asia?");
        isInSouthAsia.YesChild = india;
        isInSouthAsia.NoChild = indonesia;

        var isInEastAsia = new TreeNode("Is it in East Asia?");
        isInEastAsia.YesChild = china;
        isInEastAsia.NoChild = isInSouthAsia;

        var isInAsia = new TreeNode("Is it in Asia?");
        isInAsia.YesChild = isInEastAsia;
        isInAsia.NoChild = new TreeNode("Is it in the Americas?");
        var isInAmericas = isInAsia.NoChild;

        var isInSouthAmerica = new TreeNode("Is it in South America?");
        isInSouthAmerica.YesChild = argentina;
        isInSouthAmerica.NoChild = usa;
        isInAmericas.YesChild = isInSouthAmerica;

        var isInAfrica = new TreeNode("Is it in Africa?");
        isInAfrica.YesChild = chad;
        isInAfrica.NoChild = australia;
        isInAmericas.NoChild = isInAfrica;

        var isInEurope = new TreeNode("Is it in Europe?");
        isInEurope.YesChild = isEnglishPrimary;
        isInEurope.NoChild = isInAsia;

        //return root
        var root = isInEurope;
        return root;
    }   
}