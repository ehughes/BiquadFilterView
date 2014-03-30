using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eDSP;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;


namespace WindowsFormsApplication1
{
    public partial class BiquadFilterView : Form
    {

        BiQuad MyBQ = new BiQuad();

        PlotModel PM = new PlotModel();

        eLogAXis X_Axis = new eLogAXis();
        LinearAxis Y_Axis_Mag = new LinearAxis();
        LinearAxis Y_Axis_Phase = new LinearAxis();
        LineSeries LS_Mag = new LineSeries();
        LineSeries LS_Phase = new LineSeries();

        LineAnnotation LowEAnnotation = new LineAnnotation();
        LineAnnotation HighEAnnotation = new LineAnnotation();


        LineAnnotation HighE12Annotation = new LineAnnotation();
        LineAnnotation HighE24Annotation = new LineAnnotation();


        public BiquadFilterView()
        {
            InitializeComponent();
         
            FilterTypeCB.Items.Clear();
            FilterTypeCB.Items.AddRange(Enum.GetNames(typeof(eDSP.IIR.BiQuadType)));
            FilterTypeCB.SelectedIndex = 0;

       
            X_Axis.TickStyle = OxyPlot.Axes.TickStyle.Inside;
            Y_Axis_Mag.TickStyle = OxyPlot.Axes.TickStyle.Inside;

            X_Axis.MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139);
            X_Axis.MajorGridlineStyle = LineStyle.Solid;
            X_Axis.Maximum = 10548;
            X_Axis.Minimum = 41;
            X_Axis.MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139);
            X_Axis.MinorGridlineStyle = LineStyle.Solid;
            X_Axis.Position = AxisPosition.Bottom;
            X_Axis.Title = "Frequency (Hz)";

            X_Axis.Base = 2.0;

            Y_Axis_Mag.Minimum = -50;
            Y_Axis_Mag.Maximum = 50;
            Y_Axis_Mag.Title = "dbGain 10*log(Gain)";
            Y_Axis_Mag.MajorGridlineStyle = LineStyle.Solid;
            Y_Axis_Mag.MinorGridlineStyle = LineStyle.Dot;
            Y_Axis_Phase.Key = "Magnitude";

            Y_Axis_Phase.Minimum = -180;
            Y_Axis_Phase.Maximum = 180;
            Y_Axis_Phase.Title = "Phase (Degrees)";
            Y_Axis_Phase.Key = "Phase";
            Y_Axis_Phase.Position = AxisPosition.Right;

            Y_Axis_Phase.MajorGridlineStyle = LineStyle.Solid;
            Y_Axis_Phase.MinorGridlineStyle = LineStyle.Dot;

            LS_Mag.Title = "Magnitude (dbGain)";
            LS_Phase.Title = "Phase (Degrees)";

            LowEAnnotation.Type = LineAnnotationType.Vertical;
            LowEAnnotation.X = 82.41;
            LowEAnnotation.Color = OxyColors.Plum;
            LowEAnnotation.Text = "Low E";
            LowEAnnotation.StrokeThickness = 2.0;

            HighEAnnotation.Type = LineAnnotationType.Vertical;
            HighEAnnotation.X = 82.41 * 4;
            HighEAnnotation.Color = OxyColors.Plum;
            HighEAnnotation.Text = "High E";
            HighEAnnotation.StrokeThickness = 2.0;



            HighE12Annotation.Type = LineAnnotationType.Vertical;
            HighE12Annotation.X = 82.41 * 4 * 2;
            HighE12Annotation.Color = OxyColors.Plum;
            HighE12Annotation.Text = "High E (12th Fret)";
            HighE12Annotation.StrokeThickness = 2.0;


            HighE24Annotation.Type = LineAnnotationType.Vertical;
            HighE24Annotation.X = 82.41 * 4 * 4;
            HighE24Annotation.Color = OxyColors.Plum;
            HighE24Annotation.Text = "High E (24th Fret)";
            HighE24Annotation.StrokeThickness = 2.0;


            FreqResponsePlot.Model = PM;


            FreqResponsePlot.Model.Axes.Add(Y_Axis_Mag);
            FreqResponsePlot.Model.Axes.Add(Y_Axis_Phase);
            FreqResponsePlot.Model.Axes.Add(X_Axis);
           
            FreqResponsePlot.BackColor = Color.White;
            FreqResponsePlot.Model.PlotAreaBackground = OxyColors.White;

            LS_Mag.YAxisKey = "Magnitude";
            LS_Phase.YAxisKey = "Phase";
            FreqResponsePlot.Model.Series.Add(LS_Mag);
            FreqResponsePlot.Model.Series.Add(LS_Phase);
            LS_Mag.Smooth = true;

            ResizeControls();

        }

        private void FilterTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dbGain_NUD_ValueChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void Q_NUD_ValueChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SampleRate_NUD_ValueChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void f0_Label_Click(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void f0_NUD_ValueChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void BiquadFilterView_Load(object sender, EventArgs e)
        {
   
        }

        void UpdateFilter()
        {
            MyBQ = IIR.DesignBiquad((IIR.BiQuadType)Enum.Parse(typeof(IIR.BiQuadType), (string)FilterTypeCB.SelectedItem),
                                       (double)SampleRate_NUD.Value,
                                       (double)f0_NUD.Value,
                                       (double)dbGain_NUD.Value,
                                       (double)Q_NUD.Value);
            
            FilterSpec_TB.Text = MyBQ.ToString();

            FreqZ Hz = new FreqZ();

            double[] MyFrequencyPoints = new double[256 * 9];

            for (int i = 0; i < MyFrequencyPoints.Length; i++)
            {
                MyFrequencyPoints[i] = (82.41/4) * Math.Pow(2, (double)(i) / 256.0);
            }

            Hz.Compute(MyFrequencyPoints, (double)SampleRate_NUD.Value, MyBQ.b, MyBQ.a);

            LS_Mag.Points.Clear();
            for (int i = 0; i < Hz.FrequencyPoints.Length; i++)
            {
                LS_Mag.Points.Add(new DataPoint(Hz.FrequencyPoints[i], 20 * Math.Log10(Hz.Magnitude[i])));
            }



            LS_Phase.Points.Clear();

            if (DisplayPhaseCheckBox.Checked == true)
            {
    
                for (int i = 0; i < Hz.FrequencyPoints.Length; i++)
                {
                    LS_Phase.Points.Add(new DataPoint(Hz.FrequencyPoints[i], Hz.Phase[i]));
                }
                
            }



            if (FreqResponsePlot.Model != null)
            {
                FreqResponsePlot.Model.Annotations.Clear();
                if (DisplayGuiarStringReferencesCheckBox.Checked == true)
                {

                    FreqResponsePlot.Model.Annotations.Add(HighEAnnotation);
                    FreqResponsePlot.Model.Annotations.Add(LowEAnnotation);
                    FreqResponsePlot.Model.Annotations.Add(HighE12Annotation);
                    FreqResponsePlot.Model.Annotations.Add(HighE24Annotation);

                }
            }

            FreqResponsePlot.RefreshPlot(true);
        }

        private void BiquadFilterView_Resize(object sender, EventArgs e)
        {

            ResizeControls();
        }

        void ResizeControls()
        {
            Size NewSize = new System.Drawing.Size();

            NewSize.Width = this.Size.Width - FreqResponsePlot.Location.X - 20;
            NewSize.Height = this.Size.Height - FreqResponsePlot.Location.Y - 42;


            FreqResponsePlot.Size = NewSize;

        }

        private void DisplayPhaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void DisplayGuiarStringReferencesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        
    }


    public class eLogAXis : OxyPlot.Axes.LogarithmicAxis
    {

        public override void GetTickValues(out IList<double> majorLabelValues, out IList<double> majorTickValues, out IList<double> minorTickValues)
        {
            majorTickValues = new List<Double>();

            for (int i = 0; i < 12; i++)
            {
                majorTickValues.Add(82.41 / 4.0 * Math.Pow(2, i));    
            }
            minorTickValues = majorTickValues;
            majorLabelValues = majorTickValues;

        }
    }


}
