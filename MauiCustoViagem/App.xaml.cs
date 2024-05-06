using MauiCustoViagem.Helpers;
namespace MauiCustoViagem
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;

        public static SQLiteDatabaseHelper Db
        {
            get
            {
                if (_db == null)
                {
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "banco_sqlite_viagem.db3");

                    _db = new SQLiteDatabaseHelper(path);
                } 
                return _db;
            }
        }

        static SQLiteDatabaseHelperPedagios _dbpedagios;

        public static SQLiteDatabaseHelperPedagios DbPedagio
        {
            get
            {
                if (_dbpedagios == null)
                {
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "banco_sqlite_pedagio.db3");

                    _dbpedagios = new SQLiteDatabaseHelperPedagios(path);
                }
                return _dbpedagios;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
