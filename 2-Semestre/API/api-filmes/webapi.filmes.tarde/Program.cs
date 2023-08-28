using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o servi�o de controllers
builder.Services.AddControllers();

//Adiciona o gerador do Swagger � cole��o de servi�os
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        //Vers�o da API
        Version = "v1",

        //T�tulo da API
        Title = "API Filmes",

        //Descri��o da API
        Description = "API para gerenciamento de filmes e seus g�neros. Introdu��o � Sprint 2 - Back-end API",

        //Termos de servi�o
        //TermsOfService = new Uri("https://example.com/terms"),

        //Contatos do desenvolvedor
        Contact = new OpenApiContact
        {
            Name = "Murilo Souza Almeida",
            Url = new Uri("https://github.com/MuriloSouzAlmeid")
        }

        //Lincensa da aplica��o
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


//Instancia o builder da aplica��o
var app = builder.Build();

//Habilita o middleware para atender ao documento JSON gerado e � interface do usu�rio do Swagger
if (app.Environment.IsDevelopment())
{
    //Adicionar� o middleware do Swagger somente se o ambiente atual estiver definido como Desenvolvimento.
    app.UseSwagger();
    //A chamada do m�todo UseSwaggerUI habilita o Middleware de arquivos est�ticos.
    app.UseSwaggerUI();
}

//Para atender � interface do usu�rio do Swagger na raiz do aplicativo - leva pra interface do swagger
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