import { useEffect, useState, useCallback } from 'react';
import axios from 'axios';
import { Line } from 'react-chartjs-2';
import {
  Chart as ChartJS,
  LineElement,
  PointElement,
  CategoryScale,
  LinearScale,
  Title,
  Tooltip,
  Legend
} from 'chart.js';

ChartJS.register(LineElement, PointElement, CategoryScale, LinearScale, Title, Tooltip, Legend);

const ShopOrderChart = () => {
  const [chartData, setChartData] = useState(null);
  const [date, setDate] = useState('');

  const fetchData = useCallback(async () => {
    try {
      const res = await axios.get('http://localhost:9090/api/v1/query', {
        params: { query: 'shop_orders_total' }
      });

      const results = res.data?.data?.result || [];

      const labels = [];
      const data = [];

      results.forEach((item) => {
        const shopId = item.metric.shop_id || 'unknown';
        const value = parseFloat(item.value[1]);
        const timestamp = item.value[0];

        labels.push(shopId);
        data.push(value);

        if (timestamp) {
          const d = new Date(timestamp * 1000);
          setDate(d.toLocaleString());
        }
      });

      setChartData({
        labels,
        datasets: [
          {
            label: 'Orders by Shop ID',
            data,
            borderColor: 'rgb(75, 192, 192)',
            tension: 0.3,
            fill: false,
          },
        ],
      });
    } catch (error) {
      console.error('Error fetching Prometheus data:', error);
    }
  }, []);

  useEffect(() => {
    fetchData();

    const interval = setInterval(() => {
      fetchData();
    }, 10000);

    return () => clearInterval(interval);
  }, [fetchData]);

  if (!chartData) return <p>Loading chart...</p>;

  return (
    <div style={{ maxWidth: 700, margin: '0 auto' }}>
      <h2>Shop Orders by Shop ID</h2>
      {date && <p style={{ fontWeight: 'bold', marginBottom: '10px' }}>Data Timestamp: {date}</p>}
      <button onClick={fetchData} style={{ marginBottom: '10px', padding: '5px 10px' }}>
        Refresh Now
      </button>
      <Line data={chartData} />
    </div>
  );
};

export default ShopOrderChart;
