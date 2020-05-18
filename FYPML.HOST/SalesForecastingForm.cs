using ExcelDataReader;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FYPML.HOST
{
    public partial class SalesForecastingForm : Form
    {
        public SalesForecastingForm()
        {
            InitializeComponent();
        }
        DataTableCollection tableCollection;
        private void SalesForecastingForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new List<RegionForecastingClass>();
            fChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Fab", "Mar", "April", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" },

            });
            fChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString()

            });
            fChart.LegendLocation = LiveCharts.LegendLocation.Right;
        }
        DataTable dt;
        List<RegionForecastingClass> forecastingClasses = new List<RegionForecastingClass>();
        RegionForecastingClass regionForecasting = new RegionForecastingClass();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = tableCollection[comboBox1.SelectedItem.ToString()];

            dataGridView1.DataSource = dt;
            foreach (DataRow dr in dt.Rows)
            {
                forecastingClasses.Add(new RegionForecastingClass
                {
                    Year = Convert.ToInt32(dr["Year"]),
                    Month = Convert.ToInt32(dr["Month"]),
                    Amount = Convert.ToDouble(dr["Amount"])
                });
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = openFileDialog.FileName;
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                            { ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true } }
                                );
                            tableCollection = dataSet.Tables;
                            foreach (DataTable dataTable in tableCollection)
                            {
                                comboBox1.Items.Add(dataTable.TableName);
                            }
                        }
                    }
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            fChart.Series.Clear();
            SeriesCollection series = new SeriesCollection();
            var years = (from o in forecastingClasses as List<RegionForecastingClass>
                         select new { Year = o.Year }).Distinct();
            foreach (var year in years)
            {
                List<double> values = new List<double>();

                for (int month = 1; month <= 12; month++)
                {
                    var data = (from o in forecastingClasses as List<RegionForecastingClass>
                                where o.Year.Equals(year.Year) && o.Month.Equals(month)
                                select new { o.Amount, o.Month });
                    double value = 0;
                    if (data.FirstOrDefault() != null)
                    {
                        value = Convert.ToDouble(data.FirstOrDefault().Amount);
                        values.Add(value);
                    }
                }
                series.Add(new LineSeries() { Title = year.Year.ToString(), Values = new ChartValues<double>(values) });
            }
            fChart.Series = series;

        }

        private void btnNewRow_Click(object sender, EventArgs e)
        {
            DataRow dataRow = dt.NewRow();
            dataRow[0] = int.Parse(textBox1.Text);
            dataRow[1] = int.Parse(textBox2.Text);
            dataRow[2] = double.Parse(textBox3.Text);
            dt.Rows.Add(dataRow)
            dataGridView1.DataSource = dt;
            foreach (DataRow dr in dt.Rows)
            {
                forecastingClasses.Add(new RegionForecastingClass
                {
                    Year = Convert.ToInt32(dr["Year"]),
                    Month = Convert.ToInt32(dr["Month"]),
                    Amount = Convert.ToDouble(dr["Amount"])
                });
            }
        }
    }
}
