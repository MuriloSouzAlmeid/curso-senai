using MongoDB.Driver;

namespace minimalAPIMongo.Services
{
    public class MongoDbService
    {
        // Armazenar a configuração da aplicação
        private readonly IConfiguration _configuration;

        // Armazena uma referência ao MongoDb
        private readonly IMongoDatabase _database;

        /// <summary>
        /// Contém a configuração mecessária para acesso ao MongoDb
        /// </summary>
        /// <param name="configuration">Obj com a config da aplicação</param>
        public MongoDbService(IConfiguration configuration)
        {
            //Atribui a configuração recebida dentro de _cofiguration
            _configuration = configuration;

            // Busca a propriedade (especificada como parâmetro) da string de conexão salva na appsettings.json e salva em uma variável
            string connectionString = _configuration.GetConnectionString("DbConnection")!;
            // var connectionString -> "mongodb://localhost:27017/ProductDatabase_Tarde"

            //cria uma MongoUrl com a string de conexão e guarda em uma variável
            MongoUrl mongoUrl = MongoUrl.Create(connectionString);

            //cria um cliente de servidor a partir da mongoUrl
            //MongoClient mongoClient = new MongoClient(mongoUrl);
            MongoClient mongoClient = new(mongoUrl);

            //salva os dados da base de dados NoSQL na variável database
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        //significa que ao ser instanciada, retorna os dados salvos da base de dados => propriedade para acessar o bd
        public IMongoDatabase GetDatabase => _database;
    }
}