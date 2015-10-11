using System;
using System.Drawing;

namespace MindKeeperBase.Model
{
    public class Map
    {
        public Map()
        {
            CreationDateTime = DateTime.Now;
            MapId = Guid.NewGuid();
        }
        public Guid MapId { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public DateTime CreationDateTime { get; private set; }
        public Point Location { get; set; }
        public int Width { get; set; }
        public int Heigh { get; set; }

        #region GetHashCode, Equals, ToString override
        public override int GetHashCode()
        {
            return MapId.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is User))
                return false;

            return Equals((User)obj);
        }
        public bool Equals(User other)
        {
            return MapId == other.UserId;
        }
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
