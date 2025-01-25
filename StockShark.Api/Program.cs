using Microsoft.EntityFrameworkCore;
using StockShark.ApplicationService.Histories;
using StockShark.ApplicationService.Technical.ChartPatterns.AnalyzeAscendingTriangle;
using StockShark.ApplicationService.Technical.ChartPatterns.AnalyzeFlagsAndPennants;
using StockShark.ApplicationService.Technical.ChartPatterns.DescendingTriangle;
using StockShark.ApplicationService.Technical.ChartPatterns.SymmetricalTriangle;
using StockShark.ApplicationService.Technical.Indicators.Momentum.Momentumz;
using StockShark.Contracts.Histories.EternalServices;
using StockShark.Contracts.Histories.Repositories;
using StockShark.Contracts.Shares.Repository;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.FlagsAndPennants.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.FlagsAndPennants.PatternFinder;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.AscendingTriangle.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.AscendingTriangle.PatternFinder;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.DescendingTriangle.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.DescendingTriangle.PatternFinder;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.SymmetricalTriangle.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.ChartPatterns.Continuation.Triangles.SymmetricalTriangle.PatternFinder;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.MACD.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.MACD.Indicator;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.RSI.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Momentum.RSI.Indicator;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.EMA.Analyzer;
using StockShark.Core.Brain.Implementation.Technical.Indicators.Trend.MA.EMA.Indicator;
using StockShark.ExternalServices;
using StockShark.ExternalServices.Histories;
using StockShark.Repository.Base;
using StockShark.Repository.Histories;
using StockShark.Repository.Shares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StockSharkDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("StockShark")));

MofidEasyTraderExternalServiceConfig mofidEasyTraderExternalServiceConfig =
    builder.Configuration.GetSection("DataProviderConfigs:MofidEasyTrader").Get<MofidEasyTraderExternalServiceConfig>() ?? new();
builder.Services.AddSingleton(mofidEasyTraderExternalServiceConfig);

builder.Services.AddTransient<IHistoryExternalService, HistoryMofidEasyTraderExternalService>();

builder.Services.AddScoped<UpdateHistoryDataApplicationService>();

builder.Services.AddScoped<AnalyzeFlagsAndPennantsApplicationService>();
builder.Services.AddScoped<FlagsAndPennantsPatternFinder>();
builder.Services.AddScoped<FlagsAndPennantsAnalyzer>();

builder.Services.AddScoped<AnalyzeAscendingTriangleApplicationService>();
builder.Services.AddScoped<AscendingTrianglePatternFinder>();
builder.Services.AddScoped<AscendingTriangleAnalyzer>();

builder.Services.AddScoped<AnalyzeDescendingTriangleApplicationService>();
builder.Services.AddScoped<DescendingTrianglePatternFinder>();
builder.Services.AddScoped<DescendingTriangleAnalyzer>();

builder.Services.AddScoped<AnalyzeSymmetricalTriangleApplicationService>();
builder.Services.AddScoped<SymmetricalTrianglePatternFinder>();
builder.Services.AddScoped<SymmetricalTriangleAnalyzer>();

builder.Services.AddScoped<CalculateMACDApplicationService>();
builder.Services.AddScoped<MacdIndicator>();
builder.Services.AddScoped<MacdAnalyzer>();

builder.Services.AddScoped<CalculateRSIApplicationService>();
builder.Services.AddScoped<RsiIndicator>();
builder.Services.AddScoped<RsiAnalyzer>();

builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();
builder.Services.AddScoped<IShareRepository, ShareRepository>();

var app = builder.Build();

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
