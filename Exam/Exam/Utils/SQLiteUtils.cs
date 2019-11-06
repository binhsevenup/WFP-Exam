using SQLitePCL;

namespace Exam.Utils
{
    public class SQLiteUtils
    {
        private const string DatabaseName = "contact.db";

        private static SQLiteUtils _instance;
        public SQLiteConnection Connection { get; }

        public static SQLiteUtils GetIntances()
        {
            if (_instance == null)
            {
                _instance = new SQLiteUtils();
            }
            return _instance;
        }

        private SQLiteUtils()
        {
            Connection = new SQLiteConnection(DatabaseName);
            CreateTables();
        }

        private void CreateTables()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Contact (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,Name VARCHAR( 50 ),Phone VARCHAR( 11 ));";
            using (var statement = Connection.Prepare(sql))
            {
                statement.Step();
            }
        }
    }
}