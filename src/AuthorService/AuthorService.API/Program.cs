using AuthorService.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddStackExchangeRedisCache(options =>
{
    string? redisConnectionString = builder.Configuration.GetConnectionString("Redis");
    if (string.IsNullOrEmpty(redisConnectionString))
        throw new InvalidOperationException("Connection string 'Redis' not found.");

    options.InstanceName = "article-api_"; // Cache keyleri için önek
    options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions
    {
        EndPoints = { redisConnectionString },
        AbortOnConnectFail = false,
        ConnectRetry = 5,
        ConnectTimeout = 1000,
        SyncTimeout = 1000,
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorDbContext(builder.Configuration);
builder.Services.AddExtensionAutoMapper();
builder.Services.AddAuthorService();

builder.Services.AddIdentityService(builder.Configuration);

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
