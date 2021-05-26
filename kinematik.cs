using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class kinematik
    {
        public float a1 = 180;
        public float a2 = 180;
        public float a3 = 210;

        public float at1 = 110;

        public double x { get; set; }
        public double y { get; set; }
        public double phi { get; set; }


        public double [] pos_AT2()
        {
            double[] pos= new double[2];
            double theta1 = inv_angles()[0] * Math.PI / 180;

            double xx = 0;
            double yy = 0;

            xx = a1 * Math.Cos(theta1 + 0f);

            yy = a1 * Math.Sin(theta1 + 0f) +at1;
            pos[0] = xx;
            pos[1] = yy;
            return pos;
               
        }

        public double[] pos_AT3()
        {
            double[] pos = new double[2];
            double theta1 = inv_angles()[0] * Math.PI / 180;

            double theta2 = inv_angles()[1] * Math.PI / 180;

            double xx = 0;
            double yy = 0;

            xx = (a1 * Math.Cos(theta1 + 0f) + a2 * Math.Cos(theta1 - theta2 + 0f));

            yy = (a1 * Math.Sin(theta1 + 0f) + a2 * Math.Sin(theta1 - theta2 + 0f))+at1;

            pos[0] = xx;
            pos[1] = yy;
            return pos;
        }

        public double[] pos_AT4()
        {

            double[] pos = new double[2];

            double theta1 = inv_angles()[0] * Math.PI / 180;

            double theta2 = inv_angles()[1] * Math.PI / 180;

            double theta3 = inv_angles()[2] * Math.PI / 180;

            double xx = 0;
            double yy = 0;

            xx = (a1 * Math.Cos(theta1 + 0f) + a2 * Math.Cos(theta1 - theta2 + 0f) + a3 * Math.Cos(theta1 - theta2 + theta3 + 0f));

            yy = (a1 * Math.Sin(theta1 + 0f) + a2 * Math.Sin(theta1 - theta2 + 0f) + a3 * Math.Sin(theta1 - theta2 + theta3 + 0f)) + at1;

            pos[0] = xx;
            pos[1] = yy;
            return pos;
        }

        public double[] forward()
        {
            double[] x = new double[3];
            double theta1 = inv_angles()[0] * Math.PI / 180;

            double theta2 = inv_angles()[1] * Math.PI / 180;

            double theta3 = inv_angles()[2] * Math.PI / 180;

            double xx = 0;
            double yy = 0;

            xx = (a1 * Math.Cos(theta1 + 0f) + a2 * Math.Cos(theta1 - theta2 + 0f) + a3 * Math.Cos(theta1 - theta2 + theta3 + 0f));
            yy = (a1 * Math.Sin(theta1 + 0f) + a2 * Math.Sin(theta1 - theta2 + 0f) + a3 * Math.Sin(theta1 - theta2 + theta3 + 0f)) + at1;
            x[0] = xx;
            x[1] = yy;
            return x;
        }

        public double[] inv_angles()
        {

            double phi_rad = phi * Math.PI / 180;
            double[] angle = new double[]{
                0,
                0,
                0 };

            double wx = x - a3 * Math.Sin(phi_rad);
            double wy = y - a3 * Math.Cos(phi_rad) - at1;


            double delta = Math.Pow(wx, 2) + Math.Pow(wy, 2);
            double beta = Math.Acos(((Math.Pow(a1, 2) + Math.Pow(a2, 2) - Math.Pow(wx + 0f, 2) - Math.Pow(wy + 0f, 2)) + 0f) / ((2 * a1 * a2) + 0f));

            double alpha = Math.Acos(((Math.Pow(wx, 2) + Math.Pow(wy, 2) + Math.Pow(a1, 2) - Math.Pow(a2, 2)) + 0f) / (0f + (2 * a1 * Math.Sqrt(Math.Pow(wx, 2) + Math.Pow(wy, 2)))));

            double gamma = Math.Atan2((wy + 0f), (wx + 0f));

            double theta_1 = alpha + gamma;
            double theta_2 = Math.PI - beta;
            double theta_3 = theta_2 - theta_1 - phi_rad + Math.PI / 2;

            angle[0] = theta_1 * 180 / Math.PI;
            angle[1] = theta_2 * 180 / Math.PI;
            angle[2] = theta_3 * 180 / Math.PI;
            return angle;
        }
    }
}
