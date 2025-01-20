using EmpMgmt.Core.Constant;
using EmpMgmt.Core.CoreExtension;
using EmpMgmt.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// ************** Add services to the container. ********************

builder.Services.AddControllers();
builder.Services.AddCoreExtension(builder.Configuration);
builder.Services.AddMediatR();
builder.Services.AddCorsPolicy();


var app = builder.Build();

// *********** Configure the HTTP request pipeline. ***************

app.UseRouting();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors(GlobalConstant.CorsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();