namespace Randomizowane
{
    public class Edge
    {
        public Node from;
        public Node to;

        public Edge(Node from, Node to)
        {
            this.from = from;
            this.to = to;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", from.index, to.index);
        }
    }
}
