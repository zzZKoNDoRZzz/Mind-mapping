using System;

namespace MindKeeperBase.Model
{
    public class User
    {
        public User()
        {
            UserId = Guid.NewGuid();
        }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string HomeDirectoryPath { get; set; }

        #region GetHashCode, Equals, ToString override
        public override int GetHashCode()
        {
            return UserId.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is User))
                return false;

            return Equals((User)obj);
        }
        public bool Equals(User other)
        {
            return UserId == other.UserId;
        }
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
