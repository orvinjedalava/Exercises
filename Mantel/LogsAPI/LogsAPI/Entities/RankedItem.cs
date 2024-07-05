namespace LogsAPI.Entities
{
    public class RankedItem
    {
        public RankedItem(int rank, string value)
        {
            Rank = rank;
            Value = value;
        }   

        public int Rank { get; private set; }
        public string Value { get; private set; }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            RankedItem? item = obj as RankedItem;
            return Rank == item?.Rank && Value == item?.Value;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
