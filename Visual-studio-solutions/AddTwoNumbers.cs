using System;

namespace Visual_studio_solutions
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class AddTwoNumbers
    {
        public ListNode AddTwoNumbersFunc(ListNode l1, ListNode l2)
        {
            ListNode currentNodeFirst = l1;
            ListNode currentNodeSecond = l2;
            // Create result Linked list
            ListNode result = new ListNode(l1.val + l2.val);


            // TODO: Have to use a carry in order to sum the numbers properly
            while ((currentNodeFirst != null) && (currentNodeSecond != null))
            {
                ListNode newNode = new ListNode(currentNodeFirst.val + currentNodeSecond.val);
                result = newNode;

                Console.WriteLine(currentNodeFirst.val + " " + currentNodeSecond.val + " " + result.val);
                result = newNode.next;
                currentNodeFirst = currentNodeFirst.next;
                currentNodeSecond = currentNodeSecond.next;
            }

            return result;
          
        }
    }
}
