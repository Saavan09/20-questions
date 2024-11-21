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
                TreeNode root;

                //// Load existing tree
                //Console.WriteLine("Do you have a tree to load? Enter 'yes' or 'no'");
                //string input = Console.ReadLine();
                //if (input.ToLower() == "yes") root = LoadTree();

                //// If no existing tree to load, create a new tree 
                //else root = new TreeNode("placeholder");
                
                // Run the game 
                //PlayGame()






                // Edit Tree
                Console.WriteLine("Was this correct? Enter 'yes' or 'no'");
                input = Console.ReadLine();
                if (input.ToLower() == "no")
                {
                    Console.WriteLine("Would you like to add a question?");
                    input = Console.ReadLine();
                    if (input.ToLower() == "yes") answer = EditTree(answer);
                }

                // Save Tree
                Console.WriteLine("Do you want to save the tree? Enter 'yes' or 'no'");
                input = Console.ReadLine();
                if(input.ToLower() == "yes") SaveTree(FindRoot(answer));





                // Prompt to play again
                Console.WriteLine("Would you like to play again? Enter 'yes' or 'no'.");
                input = Console.ReadLine();
                if (input.ToLower() == "yes") playAgain = true;
                else playAgain = false;

            } while (playAgain == true);

            // Exit game
            Console.WriteLine("Goodbye!");
        }

        static TreeNode Game(TreeNode root)
        {
            // Ask root question 
            // Get input
            // Traverse to yes or no child nodes based on input 
            
            

            // If no child nodes, return node
            return root; // placeholder
        }

        static TreeNode EditTree(TreeNode startingNode)
        {
            // Add new nodes based on feedback and input 

            return startingNode; // placeholder
        }

        static void SaveTree(TreeNode root)
        {
            // save to a file
        }

        static TreeNode LoadTree()
        {
            // load from file 

            // return root node 
            return null;
        }

        // Recursive function - navigates upwards through parents until finding root 
        // Returns root node 
        // Accepts a child node as parameter 
        static TreeNode FindRoot(TreeNode node)
        {
            if(node.Parent != null) FindRoot(node.Parent);
            return node;
        }

        static void PlayGame(TreeNode node)
        {
            if (node.YesChild == null && node.NoChild == null) // Leaf node (answer)
            {
                Console.WriteLine(node.QuestionOrAnswer);
                return;
            }

            Console.WriteLine(node.QuestionOrAnswer + " (yes/no)");
            string answer = Console.ReadLine().Trim().ToLower();

            if (answer == "yes")
            {
                PlayGame(node.YesChild);
            }
            else if (answer == "no")
            {
                PlayGame(node.NoChild);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                PlayGame(node); // Repeat the question
            }
        }
    }
}
