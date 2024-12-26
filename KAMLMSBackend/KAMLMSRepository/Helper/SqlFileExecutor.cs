using Microsoft.EntityFrameworkCore;

namespace KAMLMSRepository.Helper
{
    public class SqlFileExecutor
    {
        private readonly DbContext dbContext;
        public SqlFileExecutor(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void ExecutePendingSqls()
        {
            try
            {
                EnsureExecutedScriptsTableExists();
                var executedScripts = dbContext.Database
                .SqlQuery<string>($"SELECT ScriptName FROM ExecutedScripts")
                .ToList();
                var scriptFiles = Directory.GetFiles($"{AppContext.BaseDirectory}/Queries", "*.sql");
                foreach (var scriptFile in scriptFiles)
                {
                    try
                    {
                        var scriptName = Path.GetFileName(scriptFile);

                        if (!executedScripts.Contains(scriptName))
                        {
                            var scriptContent = File.ReadAllText(scriptFile);
                            dbContext.Database.ExecuteSqlRaw(scriptContent);

                            dbContext.Database.ExecuteSqlRaw(
                                "INSERT INTO ExecutedScripts (ScriptName, ExecutedAt) VALUES ({0}, GETDATE())", scriptName);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void EnsureExecutedScriptsTableExists()
        {
            const string createTableSql = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'ExecutedScripts' AND xtype = 'U')
            CREATE TABLE ExecutedScripts (
                ScriptName NVARCHAR(255) NOT NULL PRIMARY KEY,
                ExecutedAt DATETIME DEFAULT GETDATE()
            );";

            dbContext.Database.ExecuteSqlRaw(createTableSql);
        }
    }
}
