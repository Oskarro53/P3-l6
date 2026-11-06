namespace Zad2;

public class BinaryTree<T> where T : notnull
{
    public class Node
    {
        public T Value { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node? left, Node? right)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }

    public Node? Root { get; set; }

    public BinaryTree(Node? root)
    {
        Root = root;
    }

    // TODO: BreadthFirstSearch

    public void BreadthFirstSearch(Action<Node?> onVisit)
    {
        Queue<Node>  queue = new Queue<Node>();
        if (Root == null)
            return;
        queue.Enqueue(Root);
        onVisit(Root);
        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            if (current.Left != null)
            {
                onVisit(current.Left);
                queue.Enqueue(current.Left);
            }

            if (current.Right != null)
            {
                onVisit(current.Right);
                queue.Enqueue(current.Right);
            }
        }
    }

    public int ValueCount(T value)
    {
        int count = 0;
        BreadthFirstSearch(node =>
        {
            if (node.Value.Equals(value))
                count++;
        });
        return count;
    }
}