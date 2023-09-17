using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

//Adiciona serviço de autenticação JWT Bearer - token por json
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//Define os parâmetros de validaçào do token (continuação acima)
.AddJwtBearer("JwtBearer", options =>
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
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-games-chave-autenticacao-webapi-codefirst")),

        //Valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(20),

        //De onde está vindo (qual o issure)
        ValidIssuer = "webapi.inlock.codefirst",

        //Para onde está indo (qual o audiece)
        ValidAudience = "webapi.inlock.codefirst"
    };
});

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
        Title = "API InLock Games - Code First",

        //Descrição da API
        Description = "API para gerenciamento dos jogos armazenados no banco de dados gerado por código.",

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
