using Microsoft.EntityFrameworkCore;

namespace ПР49_Осокин.Context
{
    public class Config
    {
        public static readonly string connection = "server=localhost;uid=root;database=pr49";
        public static MySqlServerVersion mySqlServerVersion = new MySqlServerVersion(new System.Version(8, 0, 11));
    }
}
