using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //Class Droid Collection implements the IDroidCollection interface.
    //All methods declared in the Interface must be implemented in this class 
    class DroidCollection : IDroidCollection
    {
        // >Holds all of the droids for this collection
        private GenericLinkedList<IDroid> droidList = new GenericLinkedList<IDroid>();


        // >Constructor
        //
        public DroidCollection()
        {
            // >Prepopulate the list.
            Add("Carbonite", "Protocol", "Bronze", 40);
            Add("Vanadium", "Protocol", "Silver", 32);
            Add("Quadranium", "Protocol", "Gold", 139);

            Add("Carbonite", "Utility", "Bronze", true, true, true);
            Add("Vanadium", "Utility", "Silver", true, true, true);
            Add("Quadranium", "Utility", "Gold", true, true, true);

            Add("Carbonite", "Janitorial", "Bronze", true, true, true, true, true);
            Add("Vanadium", "Janitorial", "Silver", true, true, true, true, true);
            Add("Quadranium", "Janitorial", "Gold", true, true, true, true, true);

            Add("Carbonite", "Astromech", "Bronze", true, true, true, true, 8);
            Add("Vanadium", "Astromech", "Silver", true, true, true, true, 15);
            Add("Quadranium", "Astromech", "Gold", true, true, true, true, 20);
        }

        //The Enqueue method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Model, string Color, int NumberOfLanguages)
        {
            // >Create a new droid.
            ProtocolDroid temp = new ProtocolDroid(Material, Model, Color, NumberOfLanguages);
            // >Enqueue it to the list.
            droidList.Add(temp);

            return true;
        }

        //The Enqueue method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        //The method can be redeclared as Enqueue since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            // >Create a new droid.
            UtilityDroid temp = new UtilityDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm);
            // >Enqueue it to the list.
            droidList.Add(temp);

            return true;
        }

        //The Enqueue method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            // >Create a new droid.
            JanitorDroid temp = new JanitorDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
            // >Enqueue it to the list.
            droidList.Add(temp);

            return true;
        }

        //The Enqueue method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            // >Create a new droid.
            AstromechDroid temp = new AstromechDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
            // >Enqueue it to the list.
            droidList.Add(temp);

            return true;
        }

        //The last method that must be implemented due to implementing the interface.
        //This method iterates through the list of droids and creates a printable string that could
        //be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            //Declare the return string
            string returnString = "";

            IDroid temp;// >Temporary droid to hold what is pulled from the list.

            //For each droid in the droidCollection
            for (int i = 0; i < droidList.Count ; i++)
            {
                // >Store the droid's reference.
                temp = droidList.Retrieve(i);
                // >Calculate the droid's cost.
                temp.CalculateTotalCost();

                //Create the string now that the total cost has been calculated
                returnString += "******************************" + Environment.NewLine;
                returnString += temp.ToString() + Environment.NewLine + Environment.NewLine;
                returnString += "Total Cost: " + temp.TotalCost.ToString("C") + Environment.NewLine;
                returnString += "******************************" + Environment.NewLine;
                returnString += Environment.NewLine;
            }

            //return the completed string
            return returnString;
        }


        // >Sort the droid list by Model.
        public void SortByModel()
        {
            // >Stacks to be used for sorting.
            GenericStack<ProtocolDroid> protocalStack = new GenericStack<ProtocolDroid>();
            GenericStack<UtilityDroid> utilityStack = new GenericStack<UtilityDroid>();
            GenericStack<JanitorDroid> janitorStack = new GenericStack<JanitorDroid>();
            GenericStack<AstromechDroid> astromechStack = new GenericStack<AstromechDroid>();
            // >Queue for sorting.
            GenericQueue<IDroid> droidQueue = new GenericQueue<IDroid>();

            IDroid droid;// >Temporary droid to hold what is pulled from the list.

            //For each droid in the droidCollection
            for (int i = 0; i < droidList.Count; i++)
            {
                // >Store the droid's reference.
                droid = droidList.Retrieve(i);

                // >Find the droid's class, cast it as that class, and push it onto the correct stack.
                if (droid is ProtocolDroid)
                {
                    //Console.WriteLine("p");
                    protocalStack.Push((ProtocolDroid)droid);
                }
                else if (droid is JanitorDroid)
                {
                    //Console.WriteLine("rightPointer");
                    janitorStack.Push((JanitorDroid)droid);
                }
                else if (droid is AstromechDroid)
                {
                    //Console.WriteLine("a");
                    astromechStack.Push((AstromechDroid)droid);
                }
                else if (droid is UtilityDroid)
                {
                    //Console.WriteLine("u");
                    utilityStack.Push((UtilityDroid)droid);
                }
            }

            // >Put the stack items into the queue.
            while (astromechStack.Count > 0)
            {
                droidQueue.Enqueue(astromechStack.Pop());
            }
            while (janitorStack.Count > 0)
            {
                droidQueue.Enqueue(janitorStack.Pop());
            }
            while (utilityStack.Count > 0)
            {
                droidQueue.Enqueue(utilityStack.Pop());
            }
            while (protocalStack.Count > 0)
            {
                droidQueue.Enqueue(protocalStack.Pop());
            }

            // >Empty the current list.
            droidList = new GenericLinkedList<IDroid>();
            // >Put the queue items back into the list.
            while (droidQueue.Count > 0)
            {
                droidList.Add(droidQueue.Dequeue());
            }
            
        }

        // >Sort the droid list by TotalCost.
        public void SortByTotalCost()
        {
            // >Temporary array to pass into the sort method.
            IDroid[] passArray = new IDroid[droidList.Count];
            IDroid droid;// >Temporary droid to hold what is pulled from the list.

            for (int i = 0; i < droidList.Count; i++)
            {
                // >Store the droid's reference.
                droid = droidList.Retrieve(i);

                // >Calculate the total cost.
                droid.CalculateTotalCost();

                // >Put the droid into the array.
                passArray[i] = droid;
            }

            // >Pass in the array to be sorted.
            MergeSort.Sort(passArray);


            // >Empty the current list.
            droidList = new GenericLinkedList<IDroid>();
            // >Put the array items back into the list.
            for (int i = 0; i < passArray.Length; i++)
            {
                droidList.Add(passArray[i]);
            }
        }




    }
}
