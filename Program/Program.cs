using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = false;

            do
            {
                // Introduction 
                Console.WriteLine("Welcome to 20 questions! \nLet's get started!");

                // Create root node 
                TreeNode root = TreeNode.BuildQuestionTree();

                //// Load existing tree
                Console.WriteLine("Do you have a tree to load? Enter 'yes' or 'no'");
                string input = Console.ReadLine();
                if (input.ToLower() == "yes") {
                    root = LoadTree();

                    if(root == null){
                        Console.WriteLine("Failed to load the tree. Starting with a new one.");
                         root = new TreeNode("placeholder");
                    }

                }
                else
                {
                    root = new TreeNode("placeholder");
                }
                //// If no existing tree to load, create a new tree 
                //else root = new TreeNode("placeholder");
                
                // Run the game 
                PlayGame(root);

                //add questions for responsive tree
                Console.WriteLine("Was this correct? Enter 'yes' or 'no'");
                var input = Console.ReadLine();
                if (input.ToLower() == "yes") Console.WriteLine("Hurray!")
                if (input.ToLower() == "no")
                {
                    Console.WriteLine("Please enter a new question to grow the tree, then - something that differentiates between your answer and mine. When answered yes, it should be the country you are thinking of.");
                    var question = Console.ReadLine();
                    Console.WriteLine("What country were you thinking of?");
                    var answer = Console.ReadLine();
                    Console.WriteLine("Your question has been logged. Thanks!");
                    EditTree(currentNode, question, answer);
                }

                // Save Tree
                Console.WriteLine("Do you want to save the tree? Enter 'yes' or 'no'");
                input = Console.ReadLine();
                //if(input.ToLower() == "yes") SaveTree(FindRoot(answer));





                // Prompt to play again
                Console.WriteLine("Would you like to play again? Enter 'yes' or 'no'.");
                input = Console.ReadLine();
                if (input.ToLower() == "yes") playAgain = true;
                else playAgain = false;

            } while (playAgain == true);

            // Exit game
            Console.WriteLine("Goodbye!");
        }

        //takes in a new question and new country answer, then adds it to the tree
        static void EditTree(TreeNode currentNode, string newQuestion, string yesChild)
        {
            //the current guess, which will be the "no" child of the new question
            string incorrectAnswer = currentNode.QuestionOrAnswer;

            //create new nodes
            TreeNode oldQuestionNode = new TreeNode(incorrectAnswer);//the old guess
            TreeNode newQuestionYesChild = new TreeNode(yesChild);//the new guess
            
            //add in the new question, which branches into new guess if yes and old guess if no
            currentNode.QuestionOrAnswer = newQuestion;
            currentNode.YesChild = newQuestionYesChild;
            currentNode.NoChild = oldQuestionNode;
        }

        static void SaveTree(TreeNode root)
        {
            // save to a file
            try
            {
                string json = JsonConvert.SerializeObject(root, Formatting.Indented);
                File.WriteAllText("tree.json", json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving the tree: " + ex.Message);
            }
        }

        static TreeNode LoadTree()
        {
            // load from file 

            try
            {
                if (File.Exists("tree.json"))
                {
                    string json = File.ReadAllText("tree.json");
                    return JsonConvert.DeserializeObject<TreeNode>(json);
                }
                else
                {
                    Console.WriteLine("No saved tree found.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading the tree: " + ex.Message);
                return null;
            }

            // return root node 
            return null;
        }

        //Plays game => Asks root question, goes through the tree using yes/no
        //returns last visited treenode
        public static TreeNode PlayGame(TreeNode node)
        {

            if (node.YesChild == null && node.NoChild == null) // Leaf node (answer)
            {
                Console.WriteLine(node.QuestionOrAnswer);
                return
            }

            Console.WriteLine(node.QuestionOrAnswer + " (yes/no)");
            string answer = Console.ReadLine()?.Trim().ToLower();

            if (answer == "yes")
            {
                return PlayGame(node.YesChild);
            }
            else if (answer == "no")
            {
                return PlayGame(node.NoChild);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                return PlayGame(node); // Repeat the question
            }
        }
    }
}
