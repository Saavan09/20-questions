using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

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
                        root = TreeNode.BuildQuestionTree();
                    }
                    else Console.WriteLine("Loaded tree successfully. Starting with existing tree.");

                }

                
                // Run the game 
                TreeNode currentNode = PlayGame(root);

                //add questions for responsive tree
                Console.WriteLine("Was this correct? Enter 'yes' or 'no'");
                input = Console.ReadLine();
                if (input.ToLower() == "yes") Console.WriteLine("Hurray!");
                if (input.ToLower() == "no")
                {
                    Console.WriteLine("Please enter a new question to grow the tree, then - something that differentiates between your answer and mine. When answered yes, it should be the country you are thinking of.");
                    string question = Console.ReadLine();
                    Console.WriteLine("What country were you thinking of?");
                    string answer = Console.ReadLine();
                    Console.WriteLine("Your question has been logged. Thanks!");
                    EditTree(currentNode, question, answer);
                }

                // Save Tree
                Console.WriteLine("Do you want to save the tree? Enter 'yes' or 'no'");
                input = Console.ReadLine();
                if(input.ToLower() == "yes") SaveTree(root);





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
            StreamWriter textFile = null;

            try
            {
                textFile = new StreamWriter($"tree.txt");                

                SerializeTree(root, textFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving the tree: " + ex.Message);
            }
            finally
            {
                if (textFile != null) textFile.Close();
            }
        }

        // pre-order tree traversal 
        static void SerializeTree(TreeNode node, StreamWriter writer)
        {
            if (node == null)
            {
                writer.WriteLine("#"); // Marker for null
                return;
            }

            writer.WriteLine(node.QuestionOrAnswer);      
            SerializeTree(node.YesChild, writer);  
            SerializeTree(node.NoChild, writer);  
        }

        static TreeNode LoadTree()
        {
            // load from file 
            StreamReader textFile = null;
            TreeNode currentNode;
            try
            {
                if (File.Exists("tree.txt"))
                {
                    textFile = new StreamReader($"tree.txt");

                    currentNode = DeserializeTree(textFile);
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
            finally
            {
                if(textFile != null) textFile.Close();
            }

            // return root node 
            return currentNode;
        }

        // pre-order tree traversal 
        static TreeNode DeserializeTree(StreamReader reader)
        {
            string line = reader.ReadLine();
            if (line == null || line == "#") return null;

            TreeNode node = new TreeNode(line);
            node.YesChild = DeserializeTree(reader);
            node.NoChild = DeserializeTree(reader);

            return node;
        }


        //Plays game => Asks root question, goes through the tree using yes/no
        //returns last visited treenode
        public static TreeNode PlayGame(TreeNode node)
        {

            if (node.YesChild == null && node.NoChild == null) // Leaf node (answer)
            {
                Console.WriteLine(node.QuestionOrAnswer);
                return node;
            }

            Console.WriteLine(node.QuestionOrAnswer + " (yes/no)");
            string answer = Console.ReadLine().Trim().ToLower();

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
