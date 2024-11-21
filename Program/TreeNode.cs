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
         *          yes Is it one of the Koreas?
         *              yes Is it South Korea?
         *              no Is Chinese a primary language?
         *                  yes Is it China?
         *                  no Is it Japan?
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
        var southKorea = new TreeNode("Is it South Korea?");
        var china = new TreeNode("Is it China?");
        var japan = new TreeNode("Is it Japan?");
        var argentina = new TreeNode("Is it Argentina?");
        var usa = new TreeNode("Is it the U.S.?");
        var chad = new TreeNode("Is it Chad?");
        var australia = new TreeNode("Is it Australia?");

        //nodes
        //In europe is ROOT
        var inEurope = new TreeNode("Is it in Europe?");
        inEurope.YesChild = isEnglishPrimary;
        inEurope.NoChild = inAsia;

        var isEnglishPrimary = new TreeNode("Is English one of the primary languages?");
        isEnglishPrimary.YesChild = ireland;
        isEnglishPrimary.NoChild = isSlavic;

        var inAsia = new TreeNode("Is it in Asia?");
        inAsia.YesChild = isKorea;
        inAsia.NoChild = inAmericas;

        var isSlavic = new TreeNode("Is it a Slavic country?");
        isSlavic.YesChild = poland;
        isSlavic.NoChild = france;

        var ireland = new TreeNode("Is it Ireland?");
        ireland.NoChild = uk;

        var isKorea = new TreeNode("Is it one of the Koreas?");
        isKorea.YesChild = southKorea;
        isKorea.NoChild = isChinesePrimary;

        var isChinesePrimary = new TreeNode("Is Chinese a primary language?");
        isChinesePrimary.YesChild = china;
        isChinesePrimary.NoChild = japan;

        var inAmericas = new TreeNode("Is it in the Americas?");
        inAmericas.YesChild = southAmerica;
        inAmericas.NoChild = inAfrica;

        var southAmerica = new TreeNode("Is it in South America?");
        southAmerica.YesChild = argentina;
        southAmerica.NoChild = usa;
        var inAfrica = new TreeNode("Is it in Africa?");
        inAfrica.YesChild = chad;
        inAfrica.NoChild = australia;
            


        var root = inEurope

        return root;
    }   
}