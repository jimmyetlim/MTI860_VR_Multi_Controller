namespace Assets.Scripts.Utilities
{
    public class Position
    {
        private float x { get; set; }
        private float y { get; set; }

        public Position(float x, float y) 
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "[" + x.ToString() + "|" + y.ToString() + "]";
        }
    }
}
