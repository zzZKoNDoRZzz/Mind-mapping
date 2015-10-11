using System;

namespace MindKeeperBase.Model
{
    public class Topic
    {
        public Topic()
        {
            TopicId = Guid.NewGuid();
        }
        public Guid TopicId { get; set; }
        public string Name { get; set; }
        public Topic Parent { get; set; }
        public string Note { get; set; }
        public ImportanceCategory Importance { get; set; }
        public Map Map { get; set; }

        #region GetHashCode, Equals, ToString override
        public override int GetHashCode()
        {
            return TopicId.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is User))
                return false;

            return Equals((User)obj);
        }
        public bool Equals(User other)
        {
            return TopicId == other.UserId;
        }
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }

    public enum ImportanceCategory
    {
        Low = 0,
        Normal,
        High,
        Critical
    }
}
