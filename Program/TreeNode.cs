using System;

public class TreeNode
{
    public string QuestionOrAnswer { get; set; }
    public TreeNode YesChild { get; set; }
    public TreeNode NoChild { get; set; }

    public TreeNode(string questionOrAnswer, TreeNode yesChild = null, TreeNode noChild = null)
    {
        var node = new TreeNode(questionOrAnswer);
        node.YesChild = yesChild;
        node.NoChild = noChild;
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
        var isInAfrica = new TreeNode("Is it in Africa?", chad, australia);
        var isInSouthAmerica = new TreeNode("Is it in South America?", argentina, usa);
        var isInAmericas = new TreeNode("Is it in the Americas?", isInSouthAmerica, isInAfrica);
        var isInSouthAsia = new TreeNode("Is it in South Asia?", india, indonesia);
        var isInEastAsia = new TreeNode("Is it in East Asia?", china, isInSouthAsia);
        var isInAsia = new TreeNode("Is it in Asia?", isInEastAsia, isInAmericas);
        var isSlavic = new TreeNode("Is it a Slavic country?", poland, france);
        var isEnglishPrimary = new TreeNode("Is English one of the primary languages?", uk, isSlavic);
        var isInEurope = new TreeNode("Is it in Europe?", isEnglishPrimary, isInAsia);
        

        //return root
        var root = isInEurope;
        return root;
    }   
}