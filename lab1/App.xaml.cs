using lab1.Services;

namespace lab1
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "friends.db";
        public static SQLiteService database;

        public static SQLiteService Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

    }
}
