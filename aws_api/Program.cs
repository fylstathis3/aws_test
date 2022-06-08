using aws_api.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

var app = builder.Build();

app.MapGet("/", () =>
{
    InMemory.IntForCache += 1;
    return InMemory.IntForCache;
});
app.UseSwagger();
app.UseSwaggerUI();
app.Run();