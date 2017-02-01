namespace Wow.DataBase
{
    public class RepositorySettings : IRepositorySettings
    {
        #region Consts 

        private const string ConnectionStringName = "Data Source=192.168.195.249;" +
                                                    "Database=WoWDB;" +
                                                    "User Id=wowtest;" +
                                                    "Password=wowtest;";

        #endregion

        #region IRepositorySettings 

        public string ConnectionString => ConnectionStringName;

        #endregion
    }
}
