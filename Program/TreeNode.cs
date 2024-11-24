using System;

public class TreeNode
{
    public string QuestionOrAnswer { get; set; }
    public TreeNode YesChild { get; set; }
    public TreeNode NoChild { get; set; }

    public TreeNode(string questionOrAnswer, TreeNode yesChild, TreeNode noChild)
    {
        QuestionOrAnswer = questionOrAnswer;
        YesChild = yesChild;
        NoChild = noChild;
    }
    public TreeNode(string questionOrAnswer)
    {
        QuestionOrAnswer=questionOrAnswer;
        YesChild = null;
        NoChild = null;
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
        TreeNode uk = new TreeNode("Is it the United Kingdom?");
        TreeNode poland = new TreeNode("Is it Poland?");
        TreeNode france = new TreeNode("Is it France?");
        TreeNode india = new TreeNode("Is it India?");
        TreeNode china = new TreeNode("Is it China?");
        TreeNode indonesia = new TreeNode("Is it Indonesia?");
        TreeNode argentina = new TreeNode("Is it Argentina?");
        TreeNode usa = new TreeNode("Is it the U.S.?");
        TreeNode chad = new TreeNode("Is it Chad?");
        TreeNode australia = new TreeNode("Is it Australia?");

        //question nodes
        //In europe is ROOT
        TreeNode isInAfrica = new TreeNode("Is it in Africa?", chad, australia);
        TreeNode isInSouthAmerica = new TreeNode("Is it in South America?", argentina, usa);
        TreeNode isInAmericas = new TreeNode("Is it in the Americas?", isInSouthAmerica, isInAfrica);
        TreeNode isInSouthAsia = new TreeNode("Is it in South Asia?", india, indonesia);
        TreeNode isInEastAsia = new TreeNode("Is it in East Asia?", china, isInSouthAsia);
        TreeNode isInAsia = new TreeNode("Is it in Asia?", isInEastAsia, isInAmericas);
        TreeNode isSlavic = new TreeNode("Is it a Slavic country?", poland, france);
        TreeNode isEnglishPrimary = new TreeNode("Is English one of the primary languages?", uk, isSlavic);
        TreeNode isInEurope = new TreeNode("Is it in Europe?", isEnglishPrimary, isInAsia);
        

        //return root
        TreeNode root = isInEurope;
        return root;
    }   
}