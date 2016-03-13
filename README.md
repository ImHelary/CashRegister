## C# POS Cash Register Console App. Compiled with Visual Studio

      I was looking for an instructional that would show how
      to build a simple POS cash register in C# as a console app.
    
      The ones I found however wasn't really much helpful based on what I expected
    
      So I spent time to create this one myself just in case anyone might face the same problem I faced.

      Feel free to Post Comments and reviews
      
      The code was compiled in Microsoft Visual Studio 2013 and
      
      Is heavily commented for easy understanding.


###Features:
            1. Runs for as long as the user wants without exitting
            2. Outputs Receipts
            3. Very polite AI shopkeeper
            4. The list goes on and on
            
            
            
###Method:
            I basically created an item class and had a class of fruits 
            inherit properties like name, price, etc. that you will expect it
            an item in a shop to have.
            
            User gets message to confirm purchase
            purchase history is added to text file Using System.IO.Streamwriter
            And read Using System.IO.StreamWriter, in the form of a receipt.
            
            Checks whether the amount of items you ae requesting are instock or out of stock
            
                  Current items available in the virtual shop are
                      Banana
                      Apple
                      Pineapple
                      Pear
                      Orange
            
            I created methods based on Bob Tabor's advice:
              "If you keep writing the same line of code many time, 
              know that there is a shorter way of performing that operation"

###Possible Upgrades:
            Convert into a WPF app
            Allow users to change/remove items in/from cart
            Spell Suggestions
            
            FOLLOW CLOSELY TO CATCH THESE UPRADES!!!!
            YOU CAN ALSO RECOMMEND FEATURES EITHER TO CHALLENGE ME Or TO REQUEST HELP.
            
            #TheWorldIsYours
            

###The main code is in the Program.cs File. compiled in visual studio. 
    ###The whole project folder has been posted


############Special Thanks to Bob Tabor for all his tutorials on MSDN Channel 9 that I took while learning to code.  
