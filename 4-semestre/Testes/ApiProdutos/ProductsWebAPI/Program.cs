using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using ProductsWebAPI.Context;
using ProductsWebAPI.Interfaces;
using ProductsWebAPI.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ProductsContext>();

//adiciona as configurações do NewtonSoft para impedir erros de ciclo (cycle)
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        // Ignora os loopings nas consultas
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        // Ignora valores nulos ao fazer junções nas consultas
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    }
);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Adiciona o gerador do Swagger à coleção de serviços
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        //Versão da API
        Version = "v1",

        //Título da API
        Title = "API Voyager",

        //Descrição da API
        Description = "API para gerenciamento do banco de dados do projeto Voyager.",

        //Termos de serviço
        //TermsOfService = new Uri("https://example.com/terms"),

        //Contatos do desenvolvedor
        Contact = new OpenApiContact
        {
            Name = "Voyager Team",
            Url = new Uri("https://github.com/MuriloSouzAlmeid")
        }

        //Lincensa da aplicação
        /*License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }*/
    });


    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

    //Configura o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //Configura para adicionar tokens de e autenticação e autorização nas requisições pelo swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,

        //Define como o valor do token será passado pelo swagger
        Description = "Velue: Bearer TokenJWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },

            new string[]
            {

            }
        }


    });
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});


var app = builder.Build();

//Habilite o middleware para atender ao documento JSON gerado e à interface do usuário do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.UseSwaggerUI();
//Para atender à interface do usuário do Swagger na raiz do aplicativo
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();