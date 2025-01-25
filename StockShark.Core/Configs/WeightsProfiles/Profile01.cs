namespace StockShark.Core.Configs.WeightsProfiles
{
    internal class Profile01
    {
        // Suggested indicator weights (sum should be 1.0)
        Dictionary<string, double> indicatorWeights = new Dictionary<string, double>
        {
            // Trend Indicators
            { "UpTrend", 0.05 },
            { "DownTrend", 0.05 },
            { "SidewaysTrend", 0.05 },
            { "EMA", 0.05 },
            { "SMA", 0.05 },
            { "ParabolicSAR", 0.05 },

            // Momentum Indicators
            { "MACD", 0.05 },
            { "RSI", 0.05 },
            { "ATR", 0.05 },
            { "OBV", 0.05 },

            // Pattern Recognition
            { "FlagsAndPennants", 0.03 },
            { "AscendingTriangle", 0.03 },
            { "DescendingTriangle", 0.03 },
            { "SymmetricalTriangle", 0.03 },
            { "DoubleBottom", 0.03 },
            { "DoubleTop", 0.03 },
            { "HeadAndShoulders", 0.03 },
            { "FibonacciRetracement", 0.03 },
            { "IchimokuCloud", 0.05 },
            { "SupportLevel", 0.05 },
            { "ResistanceLevel", 0.05 },

            // Volatility Indicators
            { "BollingerBands", 0.05 },
            { "VPT", 0.05 }
        };
    }
}
