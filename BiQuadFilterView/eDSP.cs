using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;


namespace eDSP
{

    //  http://www.musicdsp.org/files/Audio-EQ-Cookbook.txt

    public class DF1_BiQuad
    {
       
        /*
        The most straight forward implementation would be the "Direct Form 1"
        (Eq 2):

        y[n] = (BQ.b[0]/BQ.a[0])*x[n] + (BQ.b[1]/BQ.a[0])*x[n-1] + (BQ.b[2]/BQ.a[0])*x[n-2]
                            - (BQ.a[1]/BQ.a[0])*y[n-1] - (BQ.a[2]/BQ.a[0])*y[n-2]            (Eq 4)
            */

        public double[] b = new double[3];
        public double[] a = new double[2];
    
    }

    public class BiQuad
    {
        /* 
        First, given a biquad transfer function defined as:

                BQ.b[0] + BQ.b[1]*z^-1 + BQ.b[2]*z^-2
        H(z) = ------------------------                                  (Eq 1)
                BQ.a[0] + BQ.a[1]*z^-1 + BQ.a[2]*z^-2
        */
       
       public  double[] b = new double[3];
       public  double[] a = new double[3];

       public override string ToString()
       {
           string s;

           s =  "BiQuad Coefficients (Normalized to a[0]) \r\n";
           s += "----------------------------------------------------------------------------------\r\n";
           s += "y[n] = b[0]*x[n] + b[1]*x[n-1] + b[2]*x[n-2] - a[1]*x[n-1] - a[1]*y[n-2]\r\n";
           s += "----------------------------------------------------------------------------------\r\n";
           s += "b[0] = " + b[0].ToString() + "\r\n";
           s += "b[1] = " + b[1].ToString() + "\r\n";
           s += "b[2] = " + b[2].ToString() + "\r\n";
           s += "a[0] = " + a[0].ToString() + "\r\n";
           s += "a[1] = " + a[1].ToString() + "\r\n";
           s += "a[2] = " + a[2].ToString() + "\r\n";

           return s;
       }
     }
         
    

   public class IIR
    {

        public enum BiQuadType
        {
               LowPass=0,
               HighPass,
               BandpassConstantSkirtGainPeakGainQ,
               BandpassConstantSkirtGainPeakGainZero,
               Notch,
               AllPass,
               PeakingEQ,
               LowShelf,
               HighShelf
        }

        static public BiQuad DesignBiquad( BiQuadType FilterType,
                                    double Fs,
                                    double f0,
                                    double dBGain,
                                    double Q)
        {

            double A;
            double w0;
            double alpha;

            //if( FilterType == BiQuadType.HighShelf || FilterType == BiQuadType.LowShelf)
           // {
           //     A = Math.Sqrt(Math.Pow(10.0, dBGain / 40.0));
          //  }
           // else
            {
                 A = Math.Sqrt(Math.Pow(10.0, dBGain / 20.0));
            }

            w0 = 2 * Math.PI * f0 / Fs;

            BiQuad BQ = new BiQuad();

             alpha = Math.Sin(w0)/(2*Q);
  

            switch(FilterType)
            {
                default:
             case   BiQuadType.LowPass:     //   H(s) = 1.0 / (s^2 + s/Q + 1.0)

            BQ.b[0] =  (1.0 - Math.Cos(w0))/2.0;
            BQ.b[1] =   1.0 - Math.Cos(w0);
            BQ.b[2] =  (1.0 - Math.Cos(w0))/2.0;
            BQ.a[0] =   1.0 + alpha;
            BQ.a[1] =  -2.0*Math.Cos(w0);
            BQ.a[2] =   1.0 - alpha;
            break;

                case BiQuadType.HighPass:       // H(s) = s^2 / (s^2 + s/Q + 1)

            BQ.b[0] = (1.0 + Math.Cos(w0)) / 2.0;
                        BQ.b[1] = -(1.0 + Math.Cos(w0));
                        BQ.b[2] = (1.0 + Math.Cos(w0)) / 2.0;
                        BQ.a[0] = 1.0 + alpha;
                        BQ.a[1] = -2.0 * Math.Cos(w0);
                        BQ.a[2] = 1.0 - alpha;
                        break;


                 case BiQuadType.BandpassConstantSkirtGainPeakGainQ:   //     H(s) = s / (s^2 + s/Q + 1)  //(constant skirt gain, peak gain = Q)

                        BQ.b[0] = Math.Sin(w0) / 2.0;
                    BQ.b[1] =   0;
                    BQ.b[2] = -Math.Sin(w0) / 2.0;
                    BQ.a[0] = 1.0 + alpha;
                    BQ.a[1] = -2.0 * Math.Cos(w0);
                    BQ.a[2] = 1.0 - alpha;
                    break;

                  case BiQuadType.BandpassConstantSkirtGainPeakGainZero:   //     H(s) = (s/Q) / (s^2 + s/Q + 1)     // (constant 0 dB peak gain)

                    BQ.b[0] =   alpha;
                    BQ.b[1] = 0.0;
                    BQ.b[2] =  -alpha;
                    BQ.a[0] =   1 + alpha;
                    BQ.a[1] = -2.0 * Math.Cos(w0);
                    BQ.a[2] = 1.0 - alpha;
                    break;


                 case BiQuadType.Notch:    //  H(s) = (s^2 + 1) / (s^2 + s/Q + 1)

                    BQ.b[0] = 1.0;
                    BQ.b[1] =  -2*Math.Cos(w0);
                    BQ.b[2] = 1.0;
                    BQ.a[0] = 1.0 + alpha;
                    BQ.a[1] = -2.0 * Math.Cos(w0);
                    BQ.a[2] = 1.0 - alpha;
                    break;


                  case BiQuadType.AllPass:       // H(s) = (s^2 - s/Q + 1) / (s^2 + s/Q + 1)

                    BQ.b[0] = 1.0 - alpha;
                    BQ.b[1] =  -2*Math.Cos(w0);
                    BQ.b[2] = 1.0 + alpha;
                    BQ.a[0] = 1.0 + alpha;
                    BQ.a[1] = -2.0 * Math.Cos(w0);
                    BQ.a[2] = 1.0 - alpha;
                    break;


                case BiQuadType.PeakingEQ: // H(s) = (s^2 + s*(A/Q) + 1) / (s^2 + s/(A*Q) + 1)

                    BQ.b[0] =   1.0 + alpha*A;
                    BQ.b[1] = -2.0 * Math.Cos(w0);
                    BQ.b[2] =   1.0 - alpha*A;
                    BQ.a[0] =   1.0 + alpha/A;
                    BQ.a[1] =  -2.0*Math.Cos(w0);
                    BQ.a[2] = 1.0 - alpha / A;
                    break;


                case BiQuadType.LowShelf: //H(s) = A * (s^2 + (Math.Sqrt(A)/Q)*s + A)/(A*s^2 + (Math.Sqrt(A)/Q)*s + 1)

                    BQ.b[0] =    A*( (A+1.0) - (A-1.0)*Math.Cos(w0) + 2.0*Math.Sqrt(A)*alpha );
                    BQ.b[1] =  2.0*A*( (A-1.0) - (A+1.0)*Math.Cos(w0)                   );
                    BQ.b[2] = A * ((A + 1.0) - (A - 1.0) * Math.Cos(w0) - 2.0 * Math.Sqrt(A) * alpha);
                    BQ.a[0] = (A + 1.0) + (A - 1.0) * Math.Cos(w0) + 2.0 * Math.Sqrt(A) * alpha;
                    BQ.a[1] =   -2.0*( (A-1.0) + (A+1.0)*Math.Cos(w0)                   );
                    BQ.a[2] = (A + 1.0) + (A - 1.0) * Math.Cos(w0) - 2.0 * Math.Sqrt(A) * alpha;

            break;

                case BiQuadType.HighShelf:// H(s) = A * (A*s^2 + (Math.Sqrt(A)/Q)*s + 1)/(s^2 + (Math.Sqrt(A)/Q)*s + A)

                     BQ.b[0] = A * ((A + 1.0) + (A - 1.0) * Math.Cos(w0) + 2.0 * Math.Sqrt(A) * alpha);
                     BQ.b[1] = -2.0 * A * ((A - 1.0) + (A + 1.0) * Math.Cos(w0));
                    BQ.b[2] = A * ((A + 1.0) + (A - 1.0) * Math.Cos(w0) - 2.0 * Math.Sqrt(A) * alpha);
                    BQ.a[0] = (A + 1.0) - (A - 1.0) * Math.Cos(w0) + 2.0 * Math.Sqrt(A) * alpha;
                    BQ.a[1] = 2.0 * ((A - 1.0) - (A + 1.0) * Math.Cos(w0));
                    BQ.a[2] = (A + 1.0) - (A - 1.0) * Math.Cos(w0) - 2.0 * Math.Sqrt(A) * alpha;

            break;
            }

            //Normalize so a[0] is 1.   This is for real time Implementation!

            BQ.b[0] =  BQ.b[0] / BQ.a[0];
            BQ.b[1] =  BQ.b[1] / BQ.a[0];
            BQ.b[2] =  BQ.b[2] / BQ.a[0];
          
            BQ.a[1] =  BQ.a[1] / BQ.a[0];
            BQ.a[2] =  BQ.a[2] / BQ.a[0];
            BQ.a[0] = 1.0;  
            return BQ;
        }
    }


    public class FreqZ
    {
       public double[] Magnitude;
       public double[] Phase;
       public double[] FrequencyPoints;

       public void Compute(double[] FP, double SampleRate, double [] b, double [] a)
       {
           if (FP != null)
           {
               FrequencyPoints = new double[FP.Length];
               Magnitude = new double[FP.Length];
               Phase = new double[FP.Length];

               for(int i = 0;i<FP.Length;i++)
               {
                   FrequencyPoints[i] = FP[i];

                   Complex Num = new Complex(0,0);
                   Complex Den = new Complex(0,0);
                   Complex Hz;

                   for (int n = 0; n < b.Length; n++)
                   {
                       Num += Complex.Exp(Complex.ImaginaryOne * -1.0 * (double)n * 2.0 * Math.PI * (FrequencyPoints[i] / SampleRate)) * b[n];
                   }

                   for (int n = 0; n < a.Length; n++)
                   {
                       Den += Complex.Exp(Complex.ImaginaryOne *-1.0 * (double)n * 2.0 * Math.PI * (FrequencyPoints[i] / SampleRate)) * a[n];
                   }

                   Hz = Num / Den;

                   Magnitude[i] = Hz.Magnitude;
                   Phase[i] = Hz.Phase * 180.0 / Math.PI;

               }

           }

       }

    }


}
