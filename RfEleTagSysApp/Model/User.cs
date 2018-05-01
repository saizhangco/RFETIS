
namespace RfEleTagSysApp.Model
{
    public class User
    {
        private int id;
        private string name;
        private string password;
        private Role role;

        public User()
        {
            id = 0;
            name = "";
            password = "";
            role = null;
        }

        public int Id
        {
            get{ return id; }
            set{ id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Role Role
        {
            get { return role; }
            set { role = value; }
        }

        public override string ToString()
        {
            return "User [ id=" + Id + ", name=" + Name + ", password=" + Password + ", role=" + Role.ToString() + " ]"; 
        }
    }
}
