using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 LibCurve

道路测量中里程桩K * +***是表示该路线中线位置沿路线曲线中线至路线起点（K0+000m处）的水平距离，也称为路线中桩桩号。

为了便于标定线路中线位置和长度，由线路起点开始，沿着中线方向每隔一定距离钉设一个里程桩，并作为施测路线纵横断面的依据。通过里程桩的测设，不仅具体表示了中线的位置，而且利用桩号的形式表达了距离路线起点的里程。如某桩点距离线路起点的水平距离为5278.61m，则它的桩号应写为K5+278.61m，桩号中“+”号前为千米数，“+”号后为米数。

一、线路中线因根据施测需要而设置里程桩，里程桩分为整桩和加桩两种。

1、整桩是为了标定路线里程而设置的每隔10m、20m、50米的整倍数的里程桩号，百米桩和公里桩都属于整桩。通常直线段的桩距较大，宜为20至50米，并根据地形起伏变化确定。而曲线段的桩距较小，宜为5至20米，按曲线半径和长度选定。  
2、加桩分为地形加桩、地物加桩、曲线加桩和关系加桩。
（1）地形加桩是指路线中线地面起伏变化较大处加设的里程桩。

（2）地物加桩是沿道路中线有人工构筑物的地方，如房屋、桥涵、沟渠等交叉出加设的里程桩。

（3）曲线加桩是指曲线上设置的主点桩，如路线圆曲线起点（ZY）、圆曲线中点(QZ)、圆曲线终点（YZ）。通常根据主点的实际里程缩写为 ZY K*+***.** 、QZ K*+***.**，精确至厘米等。

（4）关系加桩是指路线上的转点桩（ZD）和交点桩（JD）。交点桩是圆曲线起点处和终点处切线的交点。转点桩是不能通视的相邻两个交点桩连线上设置的加桩。通常根据转点和交点的实际里程缩写为 ZD K*+***.**、JD K*+***.** 精确至厘米。

二、线路中线的平面线型由直线和曲线组成，而曲线由圆曲线和缓和曲线组成。这些线型变化的位置称为主点。如直线变为圆曲线的位置，即圆曲线的起点称为直圆点（ZY），圆曲线的中点（QZ），圆曲线变为直线的位置，即圆曲线的终点称为圆直点（YZ），直线变为缓和曲线的位置，称为直缓点（ZH），缓和曲线变为圆曲线的位置，称为缓圆点（HY），圆曲线变为缓和曲线的位置，称为圆缓点（YH）,缓和曲线变为直线的位置，称为缓直点（HZ）。

三、测设里程桩时，按照工程的不同精度需要，可使用钢卷尺、测距仪、经纬仪、全站仪、RTK等测量设备，根据已知的路线测量控制点坐标和曲线主点测设元素，采用多种不同的测设方法确定不同里程桩的位置。
     
     */
namespace WindowsFormsApplication2
{

    struct PointXYZ    ////////////结构体，用于记录桩位
    {
        //public int id;
        public string name;
        public double X;
        public double Y;
        public double Z;
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ArrayList pointlist_XYZ = new ArrayList(); //存点位坐标

        double licheng_add = 0;

        private void but_line_Click(object sender, EventArgs e)
        {
            #region 直线坐标计算
            /*
                起点桩号,起点坐标：k11+125,x,y,h
                终点桩号,终点坐标：k11+666,x,y,h
                坡度：1.0105（表示1°01'05''）
                邻桩间距：5（表示每隔五米设一个桩）
示例数据：
K11+125,46.135,79.262,10
k11+225,76.541,174.528,12
1.0105
5

            */
            #endregion

            //每次执行计算前都要清空全局参数
            pointlist_XYZ.Clear();
            licheng_add = 0;

            string[] sLines = rtb_line.Lines; //richTextBox中的数据以string数组的形式存在sLines中，每行为一个元素

            int iObsCount = rtb_line.Lines.Length;//输入数据的行数，rTextBox_input.Lines.Length表示的是richTextBox中的文本行数

            double slope = 0;//坡度
            double distance = 0;//桩距
            
            //逐行用Split函数分离，获取点位数据
            for (int i = 0; i < iObsCount; i++)
            {
                if (i<=1) { //第一行和第二行，分别为：起点和终点
                    string[] a2 = sLines[i].Split(',');
                    PointXYZ pXYZ;

                    pXYZ.name = a2[0];
                    pXYZ.X = double.Parse(a2[1]);
                    pXYZ.Y = double.Parse(a2[2]);
                    pXYZ.Z = double.Parse(a2[3]);

                    pointlist_XYZ.Add(pXYZ);
                }
                if (i==2) { //第三行，坡度slope
                            //slope = sLines[i];
                            //degree 度, branch 分, second 秒
                    string[] aSplit = sLines[i].Split('.');
                    double degree = double.Parse(aSplit[0]);
                    double branch = double.Parse(aSplit[1].Substring(0, 2));
                    double second = double.Parse(aSplit[1].Substring(2, 2));
                    slope =(Math.PI/180) * ( degree + branch/60 + second/3600 );
                }
                if (i==3) { //第四行，间距
                    distance =   double.Parse(sLines[i]);
                }
            }

            //计算直线坐标
            //az:坐标方位角
            PointXYZ point_read1 = (PointXYZ)pointlist_XYZ[0];
            PointXYZ point_read2 = (PointXYZ)pointlist_XYZ[1];
            double dx = point_read2.X - point_read1.X;
            double dy = point_read2.Y - point_read1.Y;
            double az = Math.Atan(dy/dx);

            double distance_line = Math.Sqrt( dx*dx + dy*dy );
            if (distance_line>distance) {
                //整桩数
                int zz_count =(int)(distance_line / distance);
                string[] zhuang = point_read1.name.Split('+');
                string kmm = zhuang[0].Replace("K","");
                licheng_add = double.Parse(kmm)*1000 + double.Parse(zhuang[1]);

                //每个桩点坐标
                //前一个点的坐标
                PointXYZ upPoint;
                upPoint = point_read1;
                //upPoint.name = point_read1.name;
                //upPoint.X = point_read1.X;
                //upPoint.Y = point_read1.Y;
                //upPoint.Z = point_read1.Z;
                for (int i = 0; i <zz_count;i++)
                {
                    double number = (licheng_add+distance) / 1000;
                    string[] strSplit = number.ToString().Split('.');
                    string str_xiaoshu = "0." + strSplit[1];
                    double xiaoshu = double.Parse(str_xiaoshu)*1000;
                    PointXYZ pXYZ;
                    pXYZ.name = "K" + strSplit[0] + "+" + xiaoshu;
                    pXYZ.X = upPoint.X + distance * Math.Cos(az);
                    pXYZ.Y = upPoint.Y + distance * Math.Sin(az);
                    pXYZ.Z = upPoint.Z + distance * Math.Sin(slope);
                    pointlist_XYZ.Add(pXYZ);

                    licheng_add += distance;
                    upPoint = pXYZ;
                }
                //if (distance * zz_count < distance_line) {
                //}
            }
            rtb_out.AppendText("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -" + System.Environment.NewLine);
            rtb_out.AppendText("直线坐标计算结果：" + System.Environment.NewLine);
            rtb_out.AppendText(point_read1.name + "," + point_read1.X.ToString("#0.0000") + "," + point_read1.Y.ToString("#0.0000") + "," + point_read1.Z.ToString("#0.0000") + System.Environment.NewLine);
            for (int i = 2 ;i < pointlist_XYZ.Count;i++) {
                PointXYZ point_read = (PointXYZ)pointlist_XYZ[i];
                rtb_out.AppendText(point_read.name + "," + point_read.X.ToString("#0.0000") + "," + point_read.Y.ToString("#0.0000") + "," + point_read.Z.ToString("#0.0000") + System.Environment.NewLine);
            }
            rtb_out.AppendText(point_read2.name + "," + point_read2.X.ToString("#0.0000") + "," + point_read2.Y.ToString("#0.0000") + "," + point_read2.Z.ToString("#0.0000") + System.Environment.NewLine);
            rtb_out.AppendText("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -" + System.Environment.NewLine);
        }

        private void but_yqx_Click(object sender, EventArgs e)
        {

            #region 圆曲线坐标计算
            /*
                交点桩号,交点坐标：k11+666,x,y,h
                直圆点桩号,直圆点坐标：k11+125,x,y,h
                圆直点桩号,圆直点坐标：k11+666,x,y,h
                圆曲线半径：100
                曲线偏角：86°42'43.7"
                邻桩间距（弧长Li）：5（表示每隔五米设一个桩）
                坡度：1.0105（表示1°01'05''）
总弧长：151.341米
X=212.453米  Y=411.867米  H=0.000米 交点
X=147.505米  Y=343.332米  H=0.000米 直圆点
X=147.756米  Y=480.638米  H=0.000米 圆直点

示例数据：
K11+125,212.453,411.867,10
K11+111,147.505,343.332,12
K11+111,147.756,480.638,11
100
86.42437
5
1.0105
            */
            #endregion

            //每次执行计算前都要清空全局参数
            pointlist_XYZ.Clear();
            licheng_add = 0;

            string[] sLines = rtb_yqx.Lines; //richTextBox中的数据以string数组的形式存在sLines中，每行为一个元素

            int iObsCount = rtb_yqx.Lines.Length;//输入数据的行数，rTextBox_input.Lines.Length表示的是richTextBox中的文本行数

            double slope = 0;//坡度
            double distance = 0;//桩距（弧长）
            double pianjiao = 0;//偏角
            double banjing = 0;//半径

            //逐行用Split函数分离，获取点位数据
            for (int i = 0; i < iObsCount; i++)
            {
                if (i <= 2)
                { //第一行、第二行、第三行，分别为：交点，直圆点，圆直点
                    string[] a2 = sLines[i].Split(',');
                    PointXYZ pXYZ;

                    pXYZ.name = a2[0];
                    pXYZ.X = double.Parse(a2[1]);
                    pXYZ.Y = double.Parse(a2[2]);
                    pXYZ.Z = double.Parse(a2[3]);

                    pointlist_XYZ.Add(pXYZ);
                }
                if (i==3) {//半径
                    banjing = double.Parse(sLines[i]);
    /*
0 交点桩号,交点坐标：k11+666,x,y,h
1 直圆点桩号,直圆点坐标：k11+125,x,y,h
2 圆直点桩号,圆直点坐标：k11+666,x,y,h
3 圆曲线半径：100
4 曲线偏角：86°42'43.7"
5 邻桩间距（弧长Li）：5（表示每隔五米设一个桩）
6 坡度：1.0105（表示1°01'05''）    
    */
                }
                if (i==4) {//曲线偏角
                           //degree 度, branch 分, second 秒
                           //如果传入参数为一个长整, 且大于等于0,
                           //则以这个长整的位置为起始,
                           //截取之后余下所有作为字串.
                    string[] aSplit = sLines[i].Split('.');
                    double degree = double.Parse(aSplit[0]);
                    double branch = double.Parse(aSplit[1].Substring(0, 2));
                    double second = double.Parse(aSplit[1].Substring(2, 2));
                    pianjiao = (Math.PI / 180) * (degree + branch / 60 + second / 3600);
                }
                if (i==5) {//邻桩间距（弧长）
                    distance = double.Parse(sLines[i]);
                }
                if (i==6) {//坡度
                    //degree 度, branch 分, second 秒
                    string[] aSplit = sLines[i].Split('.');
                    double degree = double.Parse(aSplit[0]);
                    double branch = double.Parse(aSplit[1].Substring(0, 2));
                    double second = double.Parse(aSplit[1].Substring(2, 2));
                    slope = (Math.PI / 180) * (degree + branch / 60 + second / 3600);//用弧度表示
                }
            }

            //曲线要素：切线长T，曲线长L，外矢距E，切曲差q
            double yqx_T = banjing * Math.Tan(pianjiao/2);
            double yqx_L = banjing * pianjiao;
            double yqx_E = banjing * (1 / Math.Cos(pianjiao / 2) - 1);
            double yqx_q = 2* yqx_T - yqx_L;

            PointXYZ point_read_jd = (PointXYZ)pointlist_XYZ[0];//交点
            PointXYZ point_read_zy = (PointXYZ)pointlist_XYZ[1];//直圆点
            PointXYZ point_read_yz = (PointXYZ)pointlist_XYZ[2];//圆直点
            
            //只需知道交点坐标
            string[] zhuang_jd = point_read_jd.name.Split('+');
            string kmm = zhuang_jd[0].Replace("K", "");
            double Kjd = double.Parse(kmm) * 1000 + double.Parse(zhuang_jd[1]);

            double Kzy = Kjd - yqx_T;
            double Kqz = Kzy + yqx_L/2;
            double Kyz = Kzy + yqx_L;

            //圆曲线的主点 应标注里程
            rtb_out.AppendText("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -" + System.Environment.NewLine);
            rtb_out.AppendText("圆曲线坐标计算结果：" + System.Environment.NewLine);
            rtb_out.AppendText("直圆点里程Kzy：" + Kzy.ToString("#0.0000") + System.Environment.NewLine);
            rtb_out.AppendText("曲中点里程Kqz：" + Kqz.ToString("#0.0000") + System.Environment.NewLine);
            rtb_out.AppendText("圆直点里程Kyz：" + Kyz.ToString("#0.0000") + System.Environment.NewLine);

            //独立坐标系坐标计算    
            //ZY到i点的弧长Li，该弧长对应的圆心角为angle_i
            double angle_i = (distance / banjing) * (180 / Math.PI);
            double x_i = banjing * Math.Sin(angle_i);
            double y_i = banjing * (1 - Math.Cos(angle_i));

            //YX-QZ段

            //ZY点到JD点的线路坐标方位角az_q1
            //double dx = point_read2.X - point_read1.X;
            //double dy = point_read2.Y - point_read1.Y;
            //double az = Math.Atan(dy / dx);
            //YZ点到JD点的线路坐标方位角az_q2

            //计算直线坐标
            //az:坐标方位角
           
            



        }
    }
}
