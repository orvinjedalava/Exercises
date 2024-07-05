using LogsAPI.Interfaces.Services;
using LogsAPI.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILogFileService, LogFileService>();

//builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

//app.UseHttpLogging();
app.Use(async (httpContext, next) =>
{
    await next();

    ILogger<Program>? logger = app.Services.GetService<ILogger<Program>>();
    logger.LogInformation("***Start custom logging***");

    string ipAddress = httpContext.Connection.RemoteIpAddress?.ToString();
    int localPort = httpContext.Connection.LocalPort;
    int statusCode = httpContext.Response.StatusCode;

    logger.LogInformation($"ipAddress: {ipAddress}");

    logger.LogInformation("***End custom logging***");
    //httpContext.Response

    //try
    //{
    //    httpContext.Request.EnableBuffering();
    //    string requestBody = await new StreamReader(httpContext.Request.Body, Encoding.UTF8).ReadToEndAsync();
    //    httpContext.Request.Body.Position = 0;
    //    Console.WriteLine($"Request body: {requestBody}");
    //}
    //catch (Exception ex)
    //{
    //    Console.WriteLine($"Exception reading request: {ex.Message}");
    //}

    //Stream originalBody = httpContext.Response.Body;
    //try
    //{
    //    using var memStream = new MemoryStream();
    //    httpContext.Response.Body = memStream;

    //    // call to the following middleware 
    //    // response should be produced by one of the following middlewares
    //    await next(httpContext);

    //    memStream.Position = 0;
    //    string responseBody = new StreamReader(memStream).ReadToEnd();

    //    memStream.Position = 0;
    //    await memStream.CopyToAsync(originalBody);
    //    Console.WriteLine(responseBody);
    //}
    //finally
    //{
    //    httpContext.Response.Body = originalBody;
    //}
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
