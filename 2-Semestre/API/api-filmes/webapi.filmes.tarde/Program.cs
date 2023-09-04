using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o serviço de controllers
builder.Services.AddControllers();

//Adiciona serviço de autenticação JWT Bearer - token por json
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//Define os parâmetros de validaçào do token (continuação acima)
.AddJwtBearer("JwtBearer",options => 
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Valida quem está solicitando
        ValidateIssuer = true,

        //Valida quem está recebendo
        ValidateAudience = true,

        //Define se o tempo de expiração do token será validado
        ValidateLifetime = true,

        //Forma de criptografia e a validação da chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

        //Valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //De onde está vindo (qual o issure)
        ValidIssuer = "webapi.filmes.tarde",

        //Para onde está indo (qual o audiece)
        ValidAudience = "webapi.filmes.tarde"
    };
});

//Adiciona o gerador do Swagger à coleção de serviços
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        //Versão da API
        Version = "v1",

        //Título da API
        Title = "API Filmes",

        //Descrição da API
        Description = "API para gerenciamento de filmes e seus gêneros. Introdução à Sprint 2 - Back-end API",

        //Termos de serviço
        //TermsOfService = new Uri("https://example.com/terms"),

        //Contatos do desenvolvedor
        Contact = new OpenApiContact
        {
            Name = "Murilo Souza Almeida",
            Url = new Uri("https://github.com/MuriloSouzAlmeid")
        }

        //Lincensa da aplicação
        /*License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }*/
    });

    //Configura o Swagger para usar o arquivo XML
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


//Instancia o builder da aplicação
var app = builder.Build();

//Habilita o middleware para atender ao documento JSON gerado e à interface do usuário do Swagger
if (app.Environment.IsDevelopment())
{
    //Adicionará o middleware do Swagger somente se o ambiente atual estiver definido como Desenvolvimento.
    app.UseSwagger();
    //A chamada do método UseSwaggerUI habilita o Middleware de arquivos estáticos.
    app.UseSwaggerUI();
}

//Para atender à interface do usuário do Swagger na raiz do aplicativo - leva pra interface do swagger
app.UseSwaggerUI(options =>
{
    //(https://localhost:<port>/)
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    //Defina a propriedade RoutePrefix como uma cadeia de caracteres vazia
    options.RoutePrefix = string.Empty;
});

//Use a autenticação definida pelo token
app.UseAuthentication();

//Use a autorização definidas no token
app.UseAuthorization();

//Mapear os controllers
app.MapControllers();
app.Run();