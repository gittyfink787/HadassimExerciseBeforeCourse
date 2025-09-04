namespace LinkedListHadasim;

    /// <summary>
    /// Represents a single node in a linked list.
    /// </summary>
    internal class Node
    {
        /// <summary>
        /// Gets or sets the integer value stored in this node.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the reference to the next node in the list.
        /// </summary>
        public Node Next { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="value">The value to assign to this node.</param>
        /// <param name="next">The reference to the next node in the list.</param>
        public Node(int value, Node next)
        {
            Value = value;
            Next = next;
        }
    }
