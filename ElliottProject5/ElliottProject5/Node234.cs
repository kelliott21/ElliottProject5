using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElliottProject5
{
    public class Node234
    {
        private const int ORDER = 4;
        private int numItems;
        private Node234 parent;
        private Node234[] childArray = new Node234[ORDER];
        private DataItem[] itemArray = new DataItem[ORDER - 1];


        //connect child to this node
        public void connectChild(int childNum, Node234 child)
        {
            childArray[childNum] = child;
            if (child != null)
                child.parent = this;
        }

        //Disconnect child from this node
        public Node234 disconnectChild(int childNum)
        {
            Node234 tempNode = childArray[childNum];
            childArray[childNum] = null;
            return tempNode;
        }

        //return child
        public Node234 getChild(int childNum)
        {
            return childArray[childNum];
        }

        //Return parent
        public Node234 getParent()
        {
            return parent;
        }

        public bool isLeaf()
        {
            if (childArray[0] == null)
                return true;
            else
                return false;
        }

        //keep track of how many items are in the node
        public int getNumItems()
        {
            return numItems;
        }


        public DataItem getItem(int index)
        {
            return itemArray[index];
        }

        //If full pull apart and add a node
        public bool isFull()
        {
            if (numItems == ORDER - 1)
                return true;
            else
                return false;
        }

        //Find an item
        public int findItem(string key)
        {
            for (int j = 0; j < ORDER - 1; j++)
            {
                if (itemArray[j] == null)
                {
                    break;
                }
                else if (itemArray[j].Value == key)
                    return j;
            }
            return -1;
        }

        public int insertItem(DataItem newItem)
        {
            numItems++;
            string newKey = newItem.Value;
            for (int j = ORDER - 2; j >= 0; j--)
            {
                if (itemArray[j] == null)
                    continue; //don't do anything else go back to the top, outside for loop
                else
                {
                    string itsKey = itemArray[j].Value;
                    if (string.Compare(newKey, itsKey, StringComparison.InvariantCulture) < 0)
                    {
                        itemArray[j + 1] = itemArray[j];
                    }
                    else
                    {
                        itemArray[j + 1] = newItem;
                        return j + 1;
                    }
                }
            }
            itemArray[0] = newItem;
            return 0;
        }

        //remove dataitem
        public DataItem removeItem()
        {
            DataItem temp = itemArray[numItems - 1];
            itemArray[numItems - 1] = null;
            numItems--;
            return temp;
        }

        public void displayNode(ref string display)
        {
            for (int j = 0; j < numItems; j++)
            {
                display += itemArray[j].ToString() + "\r\n";
            }
        }
        public void displayItem(int index, ref string display)
        {
            if (itemArray[index] != null)
            {
                display += itemArray[index].ToString() + "\r\n";
            }
        }
        public override string ToString()
        {
            string display = "";
            for (int j = 0; j < numItems; j++)
            {
                display += itemArray[j].ToString() + "\r\n";
            }
            return display;
        }
    }
}
