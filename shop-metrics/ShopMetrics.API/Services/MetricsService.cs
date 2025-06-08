using Prometheus;

namespace ShopMetrics.API.Services;

public class MetricsService
{
    private static readonly Counter OrderCounter =
        Metrics.CreateCounter("shop_orders_total", "Total orders per shop", new CounterConfiguration
        {
            LabelNames = new[] { "shop_id", "date" }
        });

    private static readonly Counter PageViewCounter =
        Metrics.CreateCounter("shop_page_views_total", "Total page views per shop", new CounterConfiguration
        {
            LabelNames = new[] { "shop_id" }
        });

    public void TrackOrder(string shopId)
    {
        var date = DateTime.UtcNow.ToString("yyyy-MM-dd");
        OrderCounter.WithLabels(shopId, date).Inc();
    }

    public void TrackPageView(string shopId)
    {
        PageViewCounter.WithLabels(shopId).Inc();
    }
}
