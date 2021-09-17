namespace JoyCon
{
    public class HistoricalData
    {
        private readonly float[] _data;
        private int _index;

        public float Total { get; private set; }
        
        public float Mean { get; private set; }

        public HistoricalData(int numberOfDataToKeep)
        {
            _data = new float[numberOfDataToKeep];
        }

        public void AddData(float newData)
        {
            Total -= _data[_index];
            Total += newData;
            Mean = Total / _data.Length;
            _data[_index] = newData;
            _index = (_index + 1)  % _data.Length;
        }
    }
}