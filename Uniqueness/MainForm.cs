using Similarity_Search_Lib.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Similarity_Search
{
    public partial class MainForm : Form
    {
        private readonly Model m_Model;
        private scpl.Windows.PlotSurface2D m_ComparisonHeatmap;
        private System.Windows.Forms.Form m_HeatMapForm;
        private bool TargetMet = false;
        private System.Timers.Timer m_Timer;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(Model model)
        {
            this.m_Model = model;
            InitializeComponent();
            RefreshUI();

            this.m_Model.dataImportedEvent += M_Model_dataImportedEvent;
            this.m_Model.newSearchResultEvent += M_Model_newSearchResultEvent;
            this.m_Model.parametersChangedEvent += M_Model_parametersChangedEvent;
            this.FormClosed += CloseCleanup;

            searchType.DataSource = Enum.GetValues(typeof(Similarity_Search_Lib.DTO.SearchTypeENUM));
            m_Timer = new System.Timers.Timer(5000)
            {
                Enabled = true
            };
            m_Timer.Elapsed += M_Timer_Elapsed;
        }

        private void M_Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (m_wrangler != null && m_Model != null && m_Model.BestSoFar != null)
                status.Text = string.Format("After {0:###,###,###,##0} iterations the best result so far is {1}.", m_wrangler.GetIterationCount(), m_Model.BestSoFar.Result);
        }

        private void CloseCleanup(Object sender, FormClosedEventArgs e)
        {
            if (m_wrangler!=null)
            {
                m_wrangler.Stop();
            }
        }
        private void RefreshUI()
        {
            this.SuspendLayout();
            var dataLoaded = (m_Model.fullSearchSet == null) ? false : true;
            this.RowCount.Text = (dataLoaded) ? m_Model.fullSearchSet.Items.Count.ToString() : "0";
            this.FilteredRowCount.Text = (dataLoaded) ? m_Model.fullSearchSet.GetFilteredItems(m_Model.AllowedPctMissing).Count().ToString() : "0";
            this.datapoints.Text = (dataLoaded) ? m_Model.fullSearchSet.Items.First().Datapoints.Count().ToString() : "0";

            this.pctMissing.Value = m_Model.AllowedPctMissing;
            this.pctMissing.Enabled = (dataLoaded && !m_Model.DoingWork);
            this.pctMissingLabel.Enabled = (dataLoaded && !m_Model.DoingWork);

            this.requestedItems.Value = m_Model.ResultSize;
            this.requestedItems.Enabled = (dataLoaded && !m_Model.DoingWork);
            this.requestedItemsLabel.Enabled = (dataLoaded && !m_Model.DoingWork);

            this.numberOfCores.Value = m_Model.SearchWorkerCount;
            this.numberOfCores.Enabled = (dataLoaded && !m_Model.DoingWork);
            this.numberOfCoresLabel.Enabled = (dataLoaded && !m_Model.DoingWork);

            this.searchType.SelectedItem = m_Model.SearchType;
            this.searchType.Enabled = (dataLoaded && !m_Model.DoingWork);
            this.searchTypeLabel.Enabled = (dataLoaded && !m_Model.DoingWork);

            this.targetResult.Value = m_Model.TargetResult;
            this.targetResult.Enabled = (dataLoaded && !m_Model.DoingWork);
            this.targetResultLabel.Enabled = (dataLoaded && !m_Model.DoingWork);

            this.ActionButton.Enabled = dataLoaded;

            var searchResultsPresent = (m_Model.BestSoFar == null) ? false : true;
            exportToolStripMenuItem.Enabled = searchResultsPresent;
            this.BestResult.Text = (searchResultsPresent) ? m_Model.BestSoFar.Result.ToString() : "0";
            this.BestResult.Enabled = searchResultsPresent;
            this.BestResultLabel.Enabled = searchResultsPresent;
            this.heatMap.Enabled = searchResultsPresent;

            this.ActionButton.Text = (m_Model.DoingWork) ? "Stop" : "Go";


            if (m_Model.BestSoFar!=null)
            {
                DataSet resultsds = new DataSet();
                resultsds.Locale = CultureInfo.InvariantCulture;
                DataTable resultDataSet= resultsds.Tables.Add("Best Data Set");

                resultDataSet.Columns.Add("UniqueId", typeof(string));
                resultDataSet.Columns.Add("Alias", typeof(string));
                resultDataSet.Columns.Add("Required", typeof(bool));
                resultDataSet.Columns.Add("PctMissing", typeof(double));

                foreach (var item in m_Model.BestSoFar.Items)
                {
                    DataRow dataRow;
                    dataRow = resultDataSet.NewRow();
                    dataRow["UniqueId"] = item.UniqueID;
                    dataRow["Alias"] = item.Alias;
                    dataRow["Required"]=item.Required;
                    dataRow["PctMissing"] = item.PctMissing;
                    resultDataSet.Rows.Add(dataRow);
                }
                resultsDataGridView.DataSource = resultDataSet;
                resultsDataGridView.Columns["PctMissing"].DefaultCellStyle.Format = "N2";
                resultsDataGridView.RowTemplate.Height = 18;
                resultsDataGridView.AllowUserToAddRows = false;
                resultsDataGridView.ReadOnly = true;                
            }
            this.ResumeLayout();
        }

        private void M_Model_parametersChangedEvent()
        {
            RefreshUI();
        }

        private void M_Model_newSearchResultEvent()
        {
            M_Timer_Elapsed(null, null);
            RefreshUI();
            if (m_ComparisonHeatmap != null) DrawHeatMap();
            if (TargetMet == false && m_Model.SearchType == SearchTypeENUM.Diversity && m_Model.BestSoFar.Result >= m_Model.TargetResult)
            {
                TargetMet = true;
                MessageBox.Show("You have reached your target number and can safely end processing.", "Target Met");
            }
            if (TargetMet == false && m_Model.SearchType == SearchTypeENUM.Similarity && m_Model.BestSoFar.Result <= m_Model.TargetResult)
            {
                TargetMet = true;
                MessageBox.Show("You have reached your target number and can safely end processing.", "Target Met");
            }
        }

        private void M_Model_dataImportedEvent()
        {
            if (!m_Model.DoingWork)
            {
                m_Model.BestSoFar = null;
                m_Model.TargetResult = m_Model.fullSearchSet.Items.First().Datapoints.Count();
                RefreshUI();
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string filePath = openFileDialog.FileName;
                    var imported = Similarity_Search_Lib.FileHandler.Import(filePath);
                    m_Model.fullSearchSet = imported;
                    Cursor.Current = DefaultCursor;
                }
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!m_Model.DoingWork && (m_Model.fullSearchSet != null) && m_Model.BestSoFar != null)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = Path.GetDirectoryName(m_Model.fullSearchSet.InputFilename);
                saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(m_Model.fullSearchSet.InputFilename) + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_Result" + Path.GetExtension(m_Model.fullSearchSet.InputFilename);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string filePath = saveFileDialog1.FileName;
                    Similarity_Search_Lib.FileHandler.Export(m_Model.BestSoFar, m_Model.fullSearchSet, filePath);
                    Cursor.Current = DefaultCursor;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pctMissing_ValueChanged(object sender, EventArgs e)
        {
            m_Model.AllowedPctMissing = (Int32)pctMissing.Value;
        }

        private void requestedItems_ValueChanged(object sender, EventArgs e)
        {
            m_Model.ResultSize = (Int32)requestedItems.Value;
        }

        private void searchType_SelectedValueChanged(object sender, EventArgs e)
        {
            m_Model.SearchType = (Similarity_Search_Lib.DTO.SearchTypeENUM)searchType.SelectedItem;
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            if (m_Model.fullSearchSet.GetFilteredItems(m_Model.AllowedPctMissing).Count() <= m_Model.ResultSize)
            {
                var msg = string.Format("You have requested {0} results but only have {1} filtered items available.", m_Model.ResultSize, m_Model.fullSearchSet.GetFilteredItems(m_Model.AllowedPctMissing).Count());
                MessageBox.Show(msg, "Error - Insufficient filtered data");
                return;
            }

            TargetMet = false;
            if (m_wrangler!=null)
            {
                m_wrangler.Stop();
                m_wrangler = null;
                m_Model.DoingWork = false;
            }
            else
            {
                m_wrangler = new WorkerWrangler(m_Model);
                m_Model.DoingWork = true;
            }
        }
        private WorkerWrangler m_wrangler;

        private void numberOfCores_ValueChanged(object sender, EventArgs e)
        {
            m_Model.SearchWorkerCount = (Int32)numberOfCores.Value;
        }

        private void searchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_Model.SearchType = (Similarity_Search_Lib.DTO.SearchTypeENUM)searchType.SelectedItem;
        }

        private void heatMap_Click(object sender, EventArgs e)
        {
            if (m_HeatMapForm != null && m_HeatMapForm.Visible) return;

            m_ComparisonHeatmap = new scpl.Windows.PlotSurface2D();
            m_ComparisonHeatmap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            m_ComparisonHeatmap.BackColor = SystemColors.ControlLightLight;
            m_ComparisonHeatmap.Legend = (scpl.Legend)null;
            m_ComparisonHeatmap.Location = new Point(488, 48);
            m_ComparisonHeatmap.Name = "ComparisonHeatmap";
            m_ComparisonHeatmap.Padding = 10;
            m_ComparisonHeatmap.PlotBackColor = Color.White;
            m_ComparisonHeatmap.ShowCoordinates = true;
            m_ComparisonHeatmap.Size = new Size(280, 232);
            m_ComparisonHeatmap.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            m_ComparisonHeatmap.TabIndex = 14;
            m_ComparisonHeatmap.Title = "";
            m_ComparisonHeatmap.TitleFont = new Font("Arial", 14f, FontStyle.Regular, GraphicsUnit.Pixel);
            m_ComparisonHeatmap.XAxis1 = (scpl.Axis)null;
            m_ComparisonHeatmap.XAxis2 = (scpl.Axis)null;
            m_ComparisonHeatmap.YAxis1 = (scpl.Axis)null;
            m_ComparisonHeatmap.YAxis2 = (scpl.Axis)null;

            m_HeatMapForm = new System.Windows.Forms.Form();
            m_HeatMapForm.Text = "Uniqueness heatmap view";

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            m_HeatMapForm.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            m_HeatMapForm.Controls.Add(m_ComparisonHeatmap);
            m_ComparisonHeatmap.Dock = DockStyle.Fill;
            DrawHeatMap();
            m_HeatMapForm.Show();
        }

        private void DrawHeatMap()
        {
            int GridSize = m_Model.ResultSize;
            m_ComparisonHeatmap.Clear();
            m_ComparisonHeatmap.Add((scpl.IDrawable)new scpl.Grid()
            {
                HorizontalGridType = scpl.Grid.GridType.Fine,
                VerticalGridType = scpl.Grid.GridType.Fine
            });
            double[,] data = new double[GridSize, GridSize];
            string[,] cellLabels = new string[GridSize, GridSize];
            for (int GeIndex1 = 0; GeIndex1 < GridSize; ++GeIndex1)
            {
                for (int GeIndex2 = 0; GeIndex2 < GridSize; ++GeIndex2)
                {
                    data[GeIndex1, GeIndex2] = Convert.ToDouble(this.CalculateDifferences(m_Model.BestSoFar.Items[GeIndex1], m_Model.BestSoFar.Items[GeIndex2]));
                    cellLabels[GeIndex1, GeIndex2] = m_Model.BestSoFar.Items[GeIndex1].Alias + " vs " + m_Model.BestSoFar.Items[GeIndex2].Alias + " " + Convert.ToInt32(data[GeIndex1, GeIndex2]).ToString() + " differences";
                }
            }
            m_ComparisonHeatmap.Add((scpl.IDrawable)new scpl.ImagePlot(data, cellLabels, 1.0, 1.0, 1.0, 1.0)
            {
                Gradient = (scpl.IGradient)new scpl.LinearGradient(Color.Yellow, Color.Blue)
            });
            m_ComparisonHeatmap.Refresh();
        }

        private int CalculateDifferences(SearchItemDTO r1, SearchItemDTO r2)
        {
            int num = 0;
            if (r1.UniqueID != r2.UniqueID)
            {
                for (int index = 0; index < r1.Datapoints.Count(); ++index)
                {
                    if (r1.Datapoints[index].Length > 0 && r2.Datapoints[index].Length > 0 && !r1.Datapoints[index].Equals(r2.Datapoints[index]))
                        ++num;
                }
            }
            return num;
        }

        private void targetResult_ValueChanged(object sender, EventArgs e)
        {
            m_Model.TargetResult = (Int32)targetResult.Value;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new UniquenessAboutBox();
            about.Focus();
            about.BringToFront();
            about.Visible=true;

        }

        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tutorial.pdf"));
        }
    }
}
