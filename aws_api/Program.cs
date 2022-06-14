using System.Text;
using aws_api.Helpers;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

var app = builder.Build();



// const string url = "amqps://fylstathis:fylstathis21@b-dcce8793-99e9-464d-9a53-93e5c11a2f37.mq.us-east-1.amazonaws.com:5671";
// const string queueName = "test-queue";
//
// var model = new {Name = "John Doe"};
// var serializedModel = JsonConvert.SerializeObject(model);
// var bytes = Encoding.UTF8.GetBytes(serializedModel);
//
// var connectionFactory = new RabbitMQ.Client.ConnectionFactory()
// {
//     Uri=  new Uri(url)
// };
//
// var connection = connectionFactory.CreateConnection();
// var channel = connection.CreateModel();
// channel.QueueDeclare(queueName, true, true, false, null);
// channel.BasicPublish("", queueName, false, null, bytes);
//
// var consumer = new RabbitMQ.Client.Events.EventingBasicConsumer(channel);
// consumer.Received += (sender, e) =>
// {
//     var stringMessage = Encoding.UTF8.GetString(e.Body.ToArray());
//     InMemory.Message = stringMessage;
//     Console.WriteLine(stringMessage);
// };
//
// channel.BasicConsume(queueName, true, "", true, true, null, consumer);

app.MapGet("/", () =>
{
    return InMemory.Message;
});

app.UseSwagger();
app.UseSwaggerUI();
app.Run();