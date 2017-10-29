using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElliottProject5
{
    public class Tree
    {
        private Node234 root = new Node234();
        public Int32 counter;

        public Node234 find(string key)
        {
            Node234 curNode = root;
            int childNumber;

            while (true)
            {
                if ((childNumber = curNode.findItem(key)) != -1)
                    return curNode;
                else if (curNode.isLeaf())
                    return null;
                else
                    curNode = getNextChild(curNode, key);
            }
        }

        public void insert(string dValue)
        {
            Node234 curNode = root;
            DataItem tempItem = new DataItem(dValue);
            //Check to see if value already exists
            Node234 found = find(dValue);
            if (found != null)
            {
                DataItem it = found.getItem(found.findItem(dValue));
                if (it != null)
                {
                    it.occurences++;
                    counter++;
                    return;
                }
                else
                    throw new Exception("Could not find string occurence for: " + dValue);
            }
            while (true)
            {
                if (curNode.isFull())
                {
                    split(curNode);
                    curNode = curNode.getParent();
                    curNode = getNextChild(curNode, dValue);
                }
                else if (curNode.isLeaf())
                    break;
                else
                    curNode = getNextChild(curNode, dValue);
            }

            curNode.insertItem(tempItem);
            counter++;
        }

        private void split(Node234 thisNode)
        {
            DataItem itemB, itemC;
            Node234 parent, child2, child3;
            int itemIndex;

            itemC = thisNode.removeItem();
            itemB = thisNode.removeItem();
            child2 = thisNode.disconnectChild(2);
            child3 = thisNode.disconnectChild(3);

            Node234 newRight = new Node234();

            if (thisNode == root)
            {
                root = new Node234();
                parent = root;
                root.connectChild(0, thisNode);
            }
            else
                parent = thisNode.getParent();

            itemIndex = parent.insertItem(itemB);
            int n = parent.getNumItems();

            for (int j = n - 1; j > itemIndex; j--)
            {
                Node234 temp = parent.disconnectChild(j);
                parent.connectChild(j + 1, temp);
            }

            parent.connectChild(itemIndex + 1, newRight);

            newRight.insertItem(itemC);
            newRight.connectChild(0, child2);
            newRight.connectChild(1, child3);
        }

        private Node234 getNextChild(Node234 theNode, string dValue)
        {
            int j;
            int numItems = theNode.getNumItems();
            for (j = 0; j < numItems; j++)
                if (string.Compare(dValue, theNode.getItem(j).Value, StringComparison.CurrentCulture) < 0)
                    return theNode.getChild(j);
            return theNode.getChild(j);
        }

        public void displayTree(ref string display)
        {
            recDisplayTree(root, 0, 0, ref display);
        }
        private void recDisplayTree(Node234 thisNode, int level, int childNumber, ref string display)
        {
            int numItems = thisNode.getNumItems();
            for (int j = 0; j < numItems + 1; j++)
            {
                Node234 nextNode = thisNode.getChild(j);
                if (nextNode != null)
                {
                    recDisplayTree(nextNode, level + 1, j, ref display);
                }
                else
                {
                    thisNode.displayNode(ref display);
                    return;
                }
            }

        }
    }
}
