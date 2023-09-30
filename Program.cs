//Code modified from https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=net-7.0

using System;
using System.Text;
using System.Collections.Generic;
// Create the link list.
string[] words =
    { "the", "fox", "jumps", "over", "the", "dog" };
LinkedList<string> sentence = new LinkedList<string>(words);
Display(sentence, "The linked list values:");
Console.WriteLine("sentence.Contains(\"jumps\") = {0}",
    sentence.Contains("jumps"));

// Add the word 'today' to the beginning of the linked list.
sentence.AddFirst("today");
Display(sentence, "Test 1: Add 'today' to beginning of the list:");

// Move the first node to be the last node.
LinkedListNode<string> mark1 = sentence.First;
sentence.RemoveFirst();
sentence.AddLast(mark1);
Display(sentence, "Test 2: Move first node to be last node:");

// Change the last node to 'yesterday'.
sentence.RemoveLast();
sentence.AddLast("yesterday");
Display(sentence, "Test 3: Change the last node to 'yesterday':");

// Move the last node to be the first node.
mark1 = sentence.Last;
sentence.RemoveLast();
sentence.AddFirst(mark1);
Display(sentence, "Test 4: Move last node to be first node:");

// Indicate the last occurence of 'the'.
sentence.RemoveFirst();
LinkedListNode<string> current = sentence.FindLast("the");
IndicateNode(current, "Test 5: Indicate last occurence of 'the':");

// Add 'lazy' and 'old' after 'the' (the LinkedListNode named current).
current = sentence.Find("the");
sentence.AddAfter(current, "lazy");
sentence.AddAfter(current, "old");
IndicateNode(current, "Test 6: Add 'lazy' and 'old' after 'the':");

// Indicate 'fox' node.
current = sentence.Find("fox");
IndicateNode(current, "Test 7: Indicate the 'fox' node:");

// Add 'quick' and 'brown' before 'fox':
sentence.AddBefore(current, "quick");
sentence.AddBefore(current, "brown");
IndicateNode(current, "Test 8: Add 'quick' and 'brown' before 'fox':");

current = sentence.Find("old");
sentence.Remove(current);
Display(sentence, "Test 9: Did we get it right?");


static void Display(LinkedList<string> words, string test)
{
    Console.WriteLine(test);
    foreach (string word in words)
    {
        Console.Write(word + " ");
    }
    Console.WriteLine();
    Console.WriteLine();
}

static void IndicateNode(LinkedListNode<string> node, string test)
{
    Console.WriteLine(test);
    if (node.List == null)
    {
        Console.WriteLine("Node '{0}' is not in the list.\n",
            node.Value);
        return;
    }

    StringBuilder result = new StringBuilder("(" + node.Value + ")");
    LinkedListNode<string> nodeP = node.Previous;

    while (nodeP != null)
    {
        result.Insert(0, nodeP.Value + " ");
        nodeP = nodeP.Previous;
    }

    node = node.Next;
    while (node != null)
    {
        result.Append(" " + node.Value);
        node = node.Next;
    }

    Console.WriteLine(result);
    Console.WriteLine();
}








//This code example produces the following output:
//
//The linked list values:
//the fox jumps over the dog

//Test 1: Add 'today' to beginning of the list:
//today the fox jumps over the dog

//Test 2: Move first node to be last node:
//the fox jumps over the dog today

//Test 3: Change the last node to 'yesterday':
//the fox jumps over the dog yesterday

//Test 4: Move last node to be first node:
//yesterday the fox jumps over the dog

//Test 5: Indicate last occurence of 'the':
//the fox jumps over (the) dog

//Test 6: Add 'lazy' and 'old' after 'the':
//the fox jumps over (the) lazy old dog

//Test 7: Indicate the 'fox' node:
//the (fox) jumps over the lazy old dog

//Test 8: Add 'quick' and 'brown' before 'fox':
//the quick brown (fox) jumps over the lazy old dog

//Test 9: Indicate the 'dog' node:
//the quick brown fox jumps over the lazy old (dog)

//Test 10: Throw exception by adding node (fox) already in the list:
//Exception message: The LinkedList node belongs a LinkedList.

//Test 11: Move a referenced node (fox) before the current node (dog):
//the quick brown jumps over the lazy old fox (dog)

//Test 12: Remove current node (dog) and attempt to indicate it:
//Node 'dog' is not in the list.

//Test 13: Add node removed in test 11 after a referenced node (brown):
//the quick brown (dog) jumps over the lazy old fox

//Test 14: Remove node that has the value 'old':
//the quick brown dog jumps over the lazy fox

//Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':
//the quick brown dog jumps over the lazy rhinoceros

//Test 16: Copy the list to an array:
//the
//quick
//brown
//dog
//jumps
//over
//the
//lazy
//rhinoceros

//Test 17: Clear linked list. Contains 'jumps' = False
//