using Prometheus;

namespace ShopStats.Metrics;

public static class SaleMetrics
{
    public static readonly Counter SalesCreated = Prometheus.Metrics.CreateCounter(
        "shop_sales_created_total",
        "Total number of sales created"
    );
}

