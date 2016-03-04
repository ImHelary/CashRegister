using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


// My code is filled with lots of METHODS, I did this because i didn't want to write the same code over and over again
// I could still put eerything under one method to make me write just one line of code for each operation but i would find
// difficulty in correcting errors


namespace CashRegister
{
    class Program
    {
        private static string message = "", x = "";
        //message and x and declared in this way because i needed to use them in other methods in this class

        private static int length = 1, grandTotal = 0;
        //length is used in the for loop in order to enable the user run the code or any number of times without closing
        //Grandtotal keeps record of the total of every item purchase you make and stores in memory till it's needed later


        //private static string x = "";
        private static StreamWriter writeToTextFile = new StreamWriter("Receipts.txt");
        //Streamwriter Writes every purchas to the text file Receipts. txt
        static void Main(string[] args)
        {

                writeToTextFile.WriteLine("\nThanks for doing business with us \nHere's Your Receipt: \n\n");//First line written into the text file
                writeToTextFile.WriteLine("Item   Quantity  Price   Total\n\n");

                Fruit banana = new Fruit("Bananas", 2, 50, "Kwadu");
                Fruit apple = new Fruit("Apples", 3, 62, "Aded33d3");
                Fruit pineApple = new Fruit("Pineapples", 2, 100, "Abrob3");
                Fruit pear = new Fruit("Pears", 4, 72, "paYae");
                Fruit orange = new Fruit("Oranges", 5, 93, "AkutuBoombaa");


                for (int i = 0; i < length; i++)
                {
                    try
                    {

                    if (length == 1)
                    {
                        message = "Hello! What would you like to buy?   ";
                    }
                    else if (length >= 1)
                    {
                        message = "\nThanks for staying! What else would you like to buy?   ";
                    }
                    Console.Write(message);
                        //JUST FOR READABILITY SAKE.
                        //NOBODY LOVES A ONE WAY TELLER ;)
                    string userPurchaseValue = Console.ReadLine().ToUpper();

                    switch (userPurchaseValue) 
                    {

                            //I PREFER SWITCH CASES OVER IF STATEMENTS IF SO MANY INSTANCES ARE TO BE GIVEN-- MOSTLY DEALING WITH USER INPUT
                        default:
                            Console.WriteLine("Sorry, we do not have {0} in stock yet", userPurchaseValue);
                            //i -= 1;
                            x = "\n                     \n";
                            //I another item is typed whether intentional or mistakenly, draw the users attention
                            break;


                        case "BANANA":

                            requiredOperations(banana);

                            //howManyWho(banana);      
                            //Message How Many bananas...

                            //getUserInputForQuantity(banana);
                            // Evaluates how many items you want

                            //x = PrintUserChoicesToTextFile(banana);
                            // If Banana is chosen, current value of x which includes 
                            
                            //grandTotal += banana.Total;//grandTotal Updated

                            /*
                             * I PUT THESE ARE THE METHODS UNDER REQUIRED OPERATIONS. 
                             * YOU CAN SIMPLY COMMENT OUT THE REQUIRED OPERATIONS METHOD AND ENABLE
                             * THE REST AND THE CODE WILL STILL WORK JUST FINE.. THEY ARE STILL THERE 
                             * TO JUST GUIDE YOU AS TO WHAT GOES ON IN THAT PROCESS SINCE I COULDN'T 
                             * FIND A GEEKY NAME TO FIT THE METHOD PERFECTLY. SUGGESTIONS ARE WELCOME :`)
                             */

                            break;


                        case "APPLE":

                            requiredOperations(apple);

                            //howManyWho(apple);
                            //getUserInputForQuantity(apple);
                            //x = PrintUserChoicesToTextFile(apple);
                            //grandTotal += apple.Total;
                            break;


                        case "PINEAPPLE":

                            requiredOperations(pineApple);

                            //howManyWho(pineApple);
                            //getUserInputForQuantity(pineApple);
                            //x = PrintUserChoicesToTextFile(pineApple);
                            //grandTotal += pineApple.Total;
                            break;

                        case "PEAR":

                            requiredOperations(pear);

                            //howManyWho(pear);
                            //getUserInputForQuantity(pear);
                            //x = PrintUserChoicesToTextFile(pear);
                            //grandTotal += pear.Total;
                            break;

                        case "ORANGE":

                            requiredOperations(orange);

                            //howManyWho(orange);
                            //getUserInputForQuantity(orange);
                            //x = PrintUserChoicesToTextFile(orange);
                            //grandTotal += orange.Total;
                            break;






                        
                    }
                    //writeToTextFile.WriteLine(x);//at the end of each loop write the current value for x into text file
                    Console.ReadLine();
                    continuePurchase();


                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\n\n\n\n\n{0}\n\n\n\n", e.Message);

                        // THE ONLY RELEVANT EXCEPTION TYPE I FOUND NECESSARY TO USE AT THE MOMENT SINCE THAT'S PROBABLY THE MOST LIKELY OF ERRORS

                        continuePurchase();
                    }
            }
        }

        private static void requiredOperations(Item item)
        {
            howManyWho(item);
            getUserInputForQuantity(item);
            writeToTextFile.WriteLine(PrintUserChoicesToTextFile(item));
            grandTotal += item.Total;
        }
        
        private static void continuePurchase()
        {
            //Simple message to find out if the user wants to buy anything else after each purchase attempt
            //i could make the user specify the number of items before hand but i just used this to protect 
            //customers from feeling stupid or undecided about how many items to buy

            Console.Write("Continue Shopping?    ( Y / N )  ");
            string tryReadKey = Console.ReadLine().ToUpper();//ToUpper() converts your user input into uppercase to prevent mismatched key input

            if (tryReadKey == "Y")
            {
                //If yes, then increase the scope of the for loop
                length += 1;
            }

            else
            {
                //otherwise put a line under the shopping list in the text file
                writeToTextFile.WriteLine("\n-----------------------------------------");
                writeToTextFile.Close();
                // End the StreamWriter process to enable other processes(Specifically StreamReader) to gain access to the text file

                Console.Clear();//just like DOS cls command
                length = 0;// End the for loop

                StreamReader readFromTextFile = new StreamReader("Receipts.txt");
                //New System.IO.TextReader extension that acts as a straw and sucks up every element from the text file
                
                string line = "";
                //Empty String

                while ((line = readFromTextFile.ReadLine()) != null)
                {
                    //The empty string equals every line read from the text file while theres still text to read,
                    //The process will remain active until the last line of the file is reached.

                    Console.WriteLine(line);
                    //Writes out every line to the console window
                    
                }
                Console.WriteLine("\nGRAND TOTAL:                       {0:C}", grandTotal);
                //Writes the grand total
                Console.ReadLine();
            }
        }


        private static void getUserInputForQuantity(Item item)
        {
            //make sure there are enough items in stock before you embarrass yourself and your client as well
            int userInputForQuantity = int.Parse(Console.ReadLine());
            item.Quantity = userInputForQuantity;
            if (item.Quantity > item.InStock)
            {
                Console.WriteLine("\nWe cannot give you the {0} {1} you requested\nbecause we have only {2} left in stock.\nWe are deeply sorry for any inconvenince caused.\n                                          Thank You!", item.Quantity, item.Name, item.InStock);
                length -= 1;
            }
            else
            {
                printReceipt(item);// Refer to printReceipt Method for clarity
            }
            item.InStock -= item.Quantity;//Simply subtracts the quantity of items bought from the quantity in stock if purchase is successful

            //throw new NotImplementedException();
        }

        private static void printReceipt(Item item)
        {
            Console.WriteLine(item.Receipt());//any object inheriting properties from Item can reference the receipt property 
        }

        private static void howManyWho(Item item)
        {
            Console.Write(item.HowManyItemsOfChoice());// Refer to HowManyItemsOfChoice under fruit class.. 
        }

        private static string PrintUserChoicesToTextFile(Item item)
        {
            //The items are written to the text file in this format
            string allUserChoices = String.Format("{0} --- {1} --- {2:C} --- {3:C}", item.Name, item.Quantity, item.Price,item.Total);
            return allUserChoices;
            //throw new NotImplementedException();
        }
    }










    //I created an Abstract Class and named it Item
    abstract class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int InStock { get; set; }
        public int Total { get; set; }
        public string ItemCode { get; set; }
        public abstract string HowManyItemsOfChoice();
        public abstract string Receipt();
        //public abstract string PrintUserChoicesToTextFile();
    }

    sealed class Fruit : Item
    {
        //Fruit class inherits from parent class item specifically for fruits
        //As a sealed class, no other class can inherit from it


        public Fruit(string name, int price, int inStock, string itemCode)
        {
            //This block helps to neaten the code up by allowing you to put your values 
            //In a bracket on a line for every new Fruit you wish to add

            this.Name = name;
            this.Price = price;
            this.InStock = inStock;
            this.ItemCode = itemCode;

            this.Total = this.Price * this.Quantity;
        }

        public override string Receipt()
        {
            //Simply prints the user's current choice to screen in a conversational manner
            //NOT THE FINAL RECEIPT THO...


            this.Total = this.Price * this.Quantity;

            string receiptMessage = String.Format("\n\n----- Item Code: {4} ----- \n{0} cost {1:C} a piece. \nSo {2} will cost you {3:C}. \nPress enter to advance", this.Name, this.Price, this.Quantity, this.Total, this.ItemCode);

            return receiptMessage;
            //throw new NotImplementedException();
        }

        public override string HowManyItemsOfChoice()
        {
            //Self explanatory

            string itemOfChoiceMessage = String.Format("\n\nHow many {0} would you like to buy?  ", this.Name);
            
            return itemOfChoiceMessage;

            //throw new NotImplementedException();
        }


        

    }

}


/*
 * FEEL FREE TO ADD TO 
 * OR MAKE RECOMMENDATIONS 
 * OR TWEAK MY CODE. I'D LOVE TO SEE
 * WHAT COMES OUT OF THIS BASIC CONSOLE APP
 * 
 * 
 * SINCERELY,
 * BARNABAS NOMO
 */