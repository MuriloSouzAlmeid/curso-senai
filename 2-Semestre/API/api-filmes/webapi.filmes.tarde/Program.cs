using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o serviço de controllers
builder.Services.AddControllers();

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

//Mapear os controllers
app.MapControllers();
app.Run();