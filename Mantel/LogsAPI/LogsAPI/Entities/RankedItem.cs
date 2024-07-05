namespace LogsAPI.Entities
{
    public class RankedItem
    {
        public RankedItem(int rank, object value)
        {
            Rank = rank;
            Value = value;
        }   

        public int Rank { get; private set; }
        public object Value { get; private set; }
    }
}
