using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fully_Fuzzy_LPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Public fields
        int vars;
        int cons;
        int type;

        float[,,] eqn22 = new float[3, 3, 4];
        float[,,] eqn23 = new float[3, 4, 4];
        float[,,] eqn32 = new float[4, 3, 4];
        float[,,] eqn33 = new float[4, 4, 4];

        float[,,] tab1 = new float[3, 5, 5]; //this is for 2 cons and 2 vars
        float[,,] tab2 = new float[3, 6, 5]; //this is for 2 cons and 3 vars
        float[,,] tab3 = new float[4, 6, 5]; //this is for 3 cons and 2 vars
        float[,,] tab4 = new float[4, 7, 5]; //this is for 3 cons and 3 vars
        bool optimal;

        string[] side1 = { "X3", "X4" };
        string[] side2 = { "X4", "X5" };
        string[] side3 = { "X3", "X4", "X5" };
        string[] side4 = { "X4", "X5", "X6" };
        int pr = 0; int pc = 0;

        // These set of functions handles the event click of the "Go" buttons
        private void eq22go_Click(object sender, RoutedEventArgs e)
        {
            cons = 2; vars = 2;

            string[,,] text = new string[3, 3, 4]{
                { //first row
                    {eq22000.Text, eq22001.Text, eq22002.Text, eq22003.Text},
                    {eq22010.Text, eq22011.Text, eq22012.Text, eq22013.Text},
                    {eq22020.Text, eq22021.Text, eq22022.Text, eq22023.Text}
                },
                { //second row
                    {eq22100.Text, eq22101.Text, eq22102.Text, eq22103.Text},
                    {eq22110.Text, eq22111.Text, eq22112.Text, eq22113.Text},
                    {eq22120.Text, eq22121.Text, eq22122.Text, eq22123.Text}
                },
                { //z-row
                    {eq22z00.Text, eq22z01.Text, eq22z02.Text, eq22z03.Text},
                    {eq22z10.Text, eq22z11.Text, eq22z12.Text, eq22z13.Text},
                    {"0","0","0","0"}
                }
            };

            // Validation
            string[] tiers = new string[9];
            string[] tier = new string[9];
            int n = 0; bool ans; bool status = false;

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (int z = 0; z < 4; z++)
                    {
                        eqn22[x, y, z] = isValid(text[x, y, z]) ? float.Parse(text[x, y, z]) : 0;
                    }
                    tiers[n] = eqn22[x, y, 0] + "-" + eqn22[x, y, 1] + "-" + eqn22[x, y, 2] + "-" + eqn22[x, y, 3];
                    List<float> temp = new List<float> { eqn22[x, y, 0], eqn22[x, y, 1], eqn22[x, y, 2], eqn22[x, y, 3] };
                    temp.Sort();
                    tier[n] = temp[0] + "-" + temp[1] + "-" + temp[2] + "-" + temp[3];
                    n = n + 1;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                ans = isArranged(tiers[i], tier[i]);
                if (ans == true)
                {
                    status = true;
                    err1.Visibility = Visibility.Visible;
                    err1.Foreground = Brushes.Green;
                    err1.Content = "Inputs are Ok.";
                }
                else if (ans == false)
                {
                    status = false;
                    err1.Visibility = Visibility.Visible;
                    err1.Foreground = Brushes.Red;
                    err1.Content = "Inputs are not Ok.";
                    break;
                }
            }

            if (status == true)
            {
                // Assigning the 
                float[,,] eqn_22 = {
                    //row 1
                    { {eqn22[0,0,0],eqn22[0,0,1],eqn22[0,0,2],eqn22[0,0,3],0},
                        {eqn22[0,1,0],eqn22[0,1,1],eqn22[0,1,2],eqn22[0,1,3],0},
                        {0,0,0,0,0},{0,0,0,0,0},
                        {eqn22[0,2,0],eqn22[0,2,1],eqn22[0,2,2],eqn22[0,2,3],0} },
                    //row 2
                    { {eqn22[1,0,0],eqn22[1,0,1],eqn22[1,0,2],eqn22[1,0,3],0},
                        {eqn22[1,1,0],eqn22[1,1,1],eqn22[1,1,2],eqn22[1,1,3],0},
                        {0,0,0,0,0},{0,0,0,0,0},
                        {eqn22[1,2,0],eqn22[1,2,1],eqn22[1,2,2],eqn22[1,2,3],0} },
                    //z-row
                    { {eqn22[2,0,0],eqn22[2,0,1],eqn22[2,0,2],eqn22[2,0,3],0},
                        {eqn22[2,1,0],eqn22[2,1,1],eqn22[2,1,2],eqn22[2,1,3],0},
                        {0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0} }
                };

                //Major
                //initialize the draw segment
                int offset = 20;
                tableGrid page = new tableGrid(stacky, offset);
                page.clear();
                tableau1 tb22 = new tableau1(eqn_22, type, cons, vars, side1);
                tb22.toCompForm();
                tb22.rank();
                //gives optimal the value of the isOptimal method of the current tableau
                optimal = tb22.isOptimal();
                //int itr = 1;
                for (int i = 0; optimal == false; i++)
                {
                    if (tb22.isOptimal())
                    {
                        //stop
                        tab1 = tb22.tab;
                        pref.Visibility = Visibility.Collapsed;
                        comm.Visibility = Visibility.Collapsed;
                        page.draw1(tab1, "Tableau " + (i+1),"Tableau is Optimal", 0, side1);
                        optimal = true;
                        page.statement("Z* = " + tab1[2, 4, 0] + " , " + tab1[2, 4, 1] + " , " + tab1[2, 4, 2] + " , " + tab1[2, 4, 3] + " | " + tab1[2, 4, 4] + "\n" +
                            side1[0] + "* = " + tab1[0, 4, 0] + " , " + tab1[0, 4, 1] + " , " + tab1[0, 4, 2] + " , " + tab1[0, 4, 3] + " | " + tab1[0, 4, 4] + " , " +
                            side1[1] + "* = " + tab1[1, 4, 0] + " , " + tab1[1, 4, 1] + " , " + tab1[1, 4, 2] + " , " + tab1[1, 4, 3] + " | " + tab1[1, 4, 4]);
                        break;
                    }
                    else
                    {
                        tab1 = tb22.tab;
                        pc = tb22.getPC();
                        pr = tb22.getPR(pc);
                        float pe = tb22.getPE(pc, pr);
                        int pos = getPeNum1(pr, pc);
                        pref.Visibility = Visibility.Collapsed;
                        comm.Visibility = Visibility.Collapsed;
                        side1 = tb22.side;
                        page.draw1(tab1, "Tableau " + (i + 1), "Tableau is not Optimal", pos, side1);
                        tb22 = fuzzy1(tb22, type, cons, vars, tab1);
                        optimal = false;
                        offset = page.off;
                    }
                }
            }
        }

        private void eq23go_Click(object sender, RoutedEventArgs e)
        {
            cons = 2; vars = 3;
            string[,,] text = new string[3, 4, 4]{
                { //first row
                    {eq23000.Text, eq23001.Text, eq23002.Text, eq23003.Text},
                    {eq23010.Text, eq23011.Text, eq23012.Text, eq23013.Text},
                    {eq23020.Text, eq23021.Text, eq23022.Text, eq23023.Text},
                    {eq23030.Text, eq23031.Text, eq23032.Text, eq23033.Text }
                },
                { //second row
                    {eq23100.Text, eq23101.Text, eq23102.Text, eq23103.Text},
                    {eq23110.Text, eq23111.Text, eq23112.Text, eq23113.Text},
                    {eq23120.Text, eq23121.Text, eq23122.Text, eq23123.Text},
                    {eq23130.Text, eq23131.Text, eq23132.Text, eq23133.Text}
                },
                { //z-row
                    {eq23z00.Text, eq23z01.Text, eq23z02.Text, eq23z03.Text},
                    {eq23z10.Text, eq23z11.Text, eq23z12.Text, eq23z13.Text},
                    {eq23z20.Text, eq23z21.Text, eq23z22.Text, eq23z23.Text},
                    {"0","0","0","0"}
                }
            };

            // Validation
            string[] tiers = new string[12];
            string[] tier = new string[12];
            int n = 0; bool ans; bool status = false;

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    for (int z = 0; z < 4; z++)
                    {
                        eqn23[x, y, z] = isValid(text[x, y, z]) ? float.Parse(text[x, y, z]) : 0;
                    }
                    tiers[n] = eqn23[x, y, 0] + "-" + eqn23[x, y, 1] + "-" + eqn23[x, y, 2] + "-" + eqn23[x, y, 3];
                    List<float> temp = new List<float> { eqn23[x, y, 0], eqn23[x, y, 1], eqn23[x, y, 2], eqn23[x, y, 3] };
                    temp.Sort();
                    tier[n] = temp[0] + "-" + temp[1] + "-" + temp[2] + "-" + temp[3];
                    n = n + 1;
                }
            }

            for (int i = 0; i < 12; i++)
            {
                ans = isArranged(tiers[i], tier[i]);
                if (ans == true)
                {
                    status = true;
                    err2.Visibility = Visibility.Visible;
                    err2.Foreground = Brushes.Green;
                    err2.Content = "Inputs are Ok.";
                }
                else if (ans == false)
                {
                    status = false;
                    err2.Visibility = Visibility.Visible;
                    err2.Foreground = Brushes.Red;
                    err2.Content = "Inputs are not Ok.";
                    break;
                }
            }

            if(status == true)
            {
                // Assigning the 
                float[,,] eqn_23 = {
                        //row 1
                        { {eqn23[0,0,0],eqn23[0,0,1],eqn23[0,0,2],eqn23[0,0,3],0},
                         {eqn23[0,1,0],eqn23[0,1,1],eqn23[0,1,2],eqn23[0,1,3],0},
                         {eqn23[0,2,0],eqn23[0,2,1],eqn23[0,2,2],eqn23[0,2,3],0},
                         {0,0,0,0,0},{0,0,0,0,0},
                         {eqn23[0,3,0],eqn23[0,3,1],eqn23[0,3,2],eqn23[0,3,3],0} },
                        //row 2
                        { {eqn23[1,0,0],eqn23[1,0,1],eqn23[1,0,2],eqn23[1,0,3],0},
                         {eqn23[1,1,0],eqn23[1,1,1],eqn23[1,1,2],eqn23[1,1,3],0},
                         {eqn23[1,2,0],eqn23[1,2,1],eqn23[1,2,2],eqn23[1,2,3],0},
                         {0,0,0,0,0},{0,0,0,0,0},
                         {eqn23[1,3,0],eqn23[1,3,1],eqn23[1,3,2],eqn23[1,3,3],0} },
                        //z-row
                        { {eqn23[2,0,0],eqn23[2,0,1],eqn23[2,0,2],eqn23[2,0,3],0},
                         {eqn23[2,1,0],eqn23[2,1,1],eqn23[2,1,2],eqn23[2,1,3],0},
                         {eqn23[2,2,0],eqn23[2,2,1],eqn23[2,2,2],eqn23[2,2,3],0},
                         {0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0} }
                    };

                //Major
                //initialize the draw segment
                int offset = 20;
                tableGrid page = new tableGrid(stacky, offset);
                page.clear();
                tableau2 tb23 = new tableau2(eqn_23, type, cons, vars, side2);
                tb23.toCompForm();
                tb23.rank();
                //gives optimal the value of the isOptimal method of the current tableau
                optimal = tb23.isOptimal();
                for (int i = 0; optimal == false; i++)
                {
                    if (tb23.isOptimal())
                    {
                        //stop
                        tab2 = tb23.tab;
                        pref.Visibility = Visibility.Collapsed;
                        comm.Visibility = Visibility.Collapsed;
                        page.draw2(tab2, "Tableau " + (i + 1), "Tableau is Optimal", 0, side2);
                        optimal = true;
                        page.statement("Z* = " + tab2[2, 5, 0] + " , " + tab2[2, 5, 1] + " , " + tab2[2, 5, 2] + " , " + tab2[2, 5, 3] + " | " + tab2[2, 5, 4] + "\n" +
                            side2[0] + "* = " + tab2[0, 5, 0] + " , " + tab2[0, 5, 1] + " , " + tab2[0, 5, 2] + " , " + tab2[0, 5, 3] + " | " + tab2[0, 5, 4] + " , " +
                            side2[1] + "* = " + tab2[1, 5, 0] + " , " + tab2[1, 5, 1] + " , " + tab2[1, 5, 2] + " , " + tab2[1, 5, 3] + " | " + tab2[1, 5, 4]);
                        break;
                    }
                    else
                    {
                        tab2 = tb23.tab;
                        pc = tb23.getPC();
                        pr = tb23.getPR(pc);
                        float pe = tb23.getPE(pc, pr);
                        int pos = getPeNum3(pr, pc);
                        pref.Visibility = Visibility.Collapsed;
                        comm.Visibility = Visibility.Collapsed;
                        side2 = tb23.side;
                        page.draw2(tab2, "Tableau " + (i + 1), "Tableau is not Optimal", pos, side2);
                        tb23 = fuzzy2(tb23, type, cons, vars, tab2);
                        optimal = false;
                        offset = page.off;
                    }
                }
            }
        }

        private void eq32go_Click(object sender, RoutedEventArgs e)
        {
            cons = 3; vars = 2;
            string[,,] text = new string[4, 3, 4]
            {
                { //first row
                    {eq32000.Text, eq32001.Text, eq32002.Text, eq32003.Text},
                    {eq32010.Text, eq32011.Text, eq32012.Text, eq32013.Text},
                    {eq32020.Text, eq32021.Text, eq32022.Text, eq32023.Text}
                },
                { //second row
                    {eq32100.Text, eq32101.Text, eq32102.Text, eq32103.Text},
                    {eq32110.Text, eq32111.Text, eq32112.Text, eq32113.Text},
                    {eq32120.Text, eq32121.Text, eq32122.Text, eq32123.Text}
                },
                { //third row
                    {eq32200.Text, eq32201.Text, eq32202.Text, eq32203.Text},
                    {eq32210.Text, eq32211.Text, eq32212.Text, eq32213.Text},
                    {eq32220.Text, eq32221.Text, eq32222.Text, eq32223.Text}
                },
                { //z-row
                    {eq32z00.Text, eq32z01.Text, eq32z02.Text, eq32z03.Text},
                    {eq32z10.Text, eq32z11.Text, eq32z12.Text, eq32z13.Text},
                    {"0","0","0","0"}
                }
            };

            // Validation
            string[] tiers = new string[12];
            string[] tier = new string[12];
            int n = 0; bool ans; bool status = false;

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (int z = 0; z < 4; z++)
                    {
                        eqn32[x, y, z] = isValid(text[x, y, z]) ? float.Parse(text[x, y, z]) : 0;
                    }
                    tiers[n] = eqn32[x, y, 0] + "-" + eqn32[x, y, 1] + "-" + eqn32[x, y, 2] + "-" + eqn32[x, y, 3];
                    List<float> temp = new List<float> { eqn32[x, y, 0], eqn32[x, y, 1], eqn32[x, y, 2], eqn32[x, y, 3] };
                    temp.Sort();
                    tier[n] = temp[0] + "-" + temp[1] + "-" + temp[2] + "-" + temp[3];
                    n = n + 1;
                }
            }

            for (int i = 0; i < 12; i++)
            {
                ans = isArranged(tiers[i], tier[i]);
                if (ans == true)
                {
                    status = true;
                    err3.Visibility = Visibility.Visible;
                    err3.Foreground = Brushes.Green;
                    err3.Content = "Inputs are Ok.";
                }
                else if (ans == false)
                {
                    status = false;
                    err3.Visibility = Visibility.Visible;
                    err3.Foreground = Brushes.Red;
                    err3.Content = "Inputs are not Ok.";
                    break;
                }
            }

            if (status == true)
            {
                // Assigning the 
                float[,,] eqn_32 = {
                        //row 1
                        { {eqn32[0,0,0],eqn32[0,0,1],eqn32[0,0,2],eqn32[0,0,3],0},
                         {eqn32[0,1,0],eqn32[0,1,1],eqn32[0,1,2],eqn32[0,1,3],0},
                         {0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},
                         {eqn32[0,2,0],eqn32[0,2,1],eqn32[0,2,2],eqn32[0,2,3],0} },
                        //row 2
                        { {eqn32[1,0,0],eqn32[1,0,1],eqn32[1,0,2],eqn32[1,0,3],0},
                         {eqn32[1,1,0],eqn32[1,1,1],eqn32[1,1,2],eqn32[1,1,3],0},
                         {0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},
                         {eqn32[1,2,0],eqn32[1,2,1],eqn32[1,2,2],eqn32[1,2,3],0} },
                        //row 3
                        { {eqn32[2,0,0],eqn32[2,0,1],eqn32[2,0,2],eqn32[2,0,3],0},
                         {eqn32[2,1,0],eqn32[2,1,1],eqn32[2,1,2],eqn32[2,1,3],0},
                         {0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},
                         {eqn32[2,2,0],eqn32[2,2,1],eqn32[2,2,2],eqn32[2,2,3],0} },
                        //z-row
                        { {eqn32[3,0,0],eqn32[3,0,1],eqn32[3,0,2],eqn32[3,0,3],0},
                         {eqn32[3,1,0],eqn32[3,1,1],eqn32[3,1,2],eqn32[3,1,3],0},
                         {0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0} }
                    };

                //Major
                //initialize the draw segment
                int offset = 20;
                tableGrid page = new tableGrid(stacky, offset);
                page.clear();
                tableau3 tb32 = new tableau3(eqn_32, type, cons, vars, side3);
                tb32.toCompForm();
                tb32.rank();
                //gives optimal the value of the isOptimal method of the current tableau
                optimal = tb32.isOptimal();
                for (int i = 0; optimal == false; i++)
                {
                    if (tb32.isOptimal())
                    {
                        //stop
                        tab3 = tb32.tab;
                        pref.Visibility = Visibility.Collapsed;
                        comm.Visibility = Visibility.Collapsed;
                        page.draw3(tab3, "Tableau " + (i + 1), "Tableau is Optimal", 0, side3);
                        optimal = true;
                        page.statement("Z* = " + tab3[3, 5, 0] + " , " + tab3[3, 5, 1] + " , " + tab3[3, 5, 2] + " , " + tab3[3, 5, 3] + " | " + tab3[3, 5, 4] + "\n" +
                            side3[0] + "* = " + tab3[0, 5, 0] + " , " + tab3[0, 5, 1] + " , " + tab3[0, 5, 2] + " , " + tab3[0, 5, 3] + " | " + tab3[0, 5, 4] + " , " +
                            side3[1] + "* = " + tab3[1, 5, 0] + " , " + tab3[1, 5, 1] + " , " + tab3[1, 5, 2] + " , " + tab3[1, 5, 3] + " | " + tab3[1, 5, 4] + " , " +
                            side3[2] + "* = " + tab3[2, 5, 0] + " , " + tab3[2, 5, 1] + " , " + tab3[2, 5, 2] + " , " + tab3[2, 5, 3] + " | " + tab3[2, 5, 4]);
                        break;
                    }
                    else
                    {
                        tab3 = tb32.tab;
                        pc = tb32.getPC();
                        pr = tb32.getPR(pc);
                        float pe = tb32.getPE(pc, pr);
                        int pos = getPeNum3(pr, pc);
                        pref.Visibility = Visibility.Collapsed;
                        comm.Visibility = Visibility.Collapsed;
                        side3 = tb32.side;
                        page.draw3(tab3, "Tableau " + (i + 1), "Tableau is not Optimal", pos, side3);
                        tb32 = fuzzy3(tb32, type, cons, vars, tab3);
                        optimal = false;
                        offset = page.off;
                    }
                }
            }
        }

        private void eq33go_Click(object sender, RoutedEventArgs e)
        {
            cons = 3; vars = 3;
            string[,,] text = new string[4, 4, 4]
            {
                { //first row
                    { eq33000.Text, eq33001.Text, eq33002.Text, eq33003.Text },
                    { eq33010.Text, eq33011.Text, eq33012.Text, eq33013.Text },
                    { eq33020.Text, eq33021.Text, eq33022.Text, eq33023.Text },
                    { eq33030.Text, eq33031.Text, eq33032.Text, eq33033.Text }
                },
                { //second row
                    { eq33100.Text, eq33101.Text, eq33102.Text, eq33103.Text},
                    { eq33110.Text, eq33111.Text, eq33112.Text, eq33113.Text},
                    { eq33120.Text, eq33121.Text, eq33122.Text, eq33123.Text},
                    { eq33130.Text, eq33131.Text, eq33132.Text, eq33133.Text}
                },
                { //third row
                    { eq33200.Text, eq33201.Text, eq33202.Text, eq33203.Text},
                    { eq33210.Text, eq33211.Text, eq33212.Text, eq33213.Text},
                    { eq33220.Text, eq33221.Text, eq33222.Text, eq33223.Text},
                    { eq33230.Text, eq33231.Text, eq33232.Text, eq33233.Text}
                },
                { //z-row
                    { eq33z00.Text, eq33z01.Text, eq33z02.Text, eq33z03.Text},
                    { eq33z10.Text, eq33z11.Text, eq33z12.Text, eq33z13.Text},
                    { eq33z20.Text, eq33z21.Text, eq33z22.Text, eq33z23.Text},
                    { "0","0","0","0"}
                }
            };

            // Validation
            string[] tiers = new string[16];
            string[] tier = new string[16];
            int n = 0;bool ans; bool status = false;

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    for (int z = 0; z < 4; z++)
                    {
                        eqn33[x, y, z] = isValid(text[x, y, z]) ? float.Parse(text[x, y, z]) : 0;
                    }
                    tiers[n] = eqn33[x, y, 0] + "-" + eqn33[x, y, 1] + "-" + eqn33[x, y, 2] + "-" + eqn33[x, y, 3];
                    List<float> temp = new List<float> { eqn33[x, y, 0], eqn33[x, y, 1], eqn33[x, y, 2], eqn33[x, y, 3] };
                    temp.Sort();
                    tier[n] = temp[0] + "-" + temp[1] + "-" + temp[2] + "-" + temp[3];
                    n = n + 1;
                }
            }

            for (int i = 0; i < 16; i++)
            {
                ans = isArranged(tiers[i], tier[i]);
                if (ans == true)
                {
                    status = true;
                    err4.Visibility = Visibility.Visible;
                    err4.Foreground = Brushes.Green;
                    err4.Content = "Inputs are Ok.";
                }
                else if (ans == false)
                {
                    status = false;
                    err4.Visibility = Visibility.Visible;
                    err4.Foreground = Brushes.Red;
                    err4.Content = "Inputs are not Ok.";
                    break;
                }
            }

            if (status == true)
            {
                // Assigning the 
                float[,,] eqn_33 = {
                        //row 1
                        { {eqn33[0,0,0],eqn33[0,0,1],eqn33[0,0,2],eqn33[0,0,3],0},
                         {eqn33[0,1,0],eqn33[0,1,1],eqn33[0,1,2],eqn33[0,1,3],0},
                         {eqn33[0,2,0],eqn33[0,2,1],eqn33[0,2,2],eqn33[0,2,3],0},
                         {0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},
                         {eqn33[0,3,0],eqn33[0,3,1],eqn33[0,3,2],eqn33[0,3,3],0} },
                        //row 2
                        { {eqn33[1,0,0],eqn33[1,0,1],eqn33[1,0,2],eqn33[1,0,3],0},
                         {eqn33[1,1,0],eqn33[1,1,1],eqn33[1,1,2],eqn33[1,1,3],0},
                         {eqn33[1,2,0],eqn33[1,2,1],eqn33[1,2,2],eqn33[1,2,3],0},
                         {0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},
                         {eqn33[1,3,0],eqn33[1,3,1],eqn33[1,3,2],eqn33[1,3,3],0} },
                        //row 3
                        { {eqn33[2,0,0],eqn33[2,0,1],eqn33[2,0,2],eqn33[2,0,3],0},
                         {eqn33[2,1,0],eqn33[2,1,1],eqn33[2,1,2],eqn33[2,1,3],0},
                         {eqn33[2,2,0],eqn33[2,2,1],eqn33[2,2,2],eqn33[2,2,3],0},
                         {0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},
                         {eqn33[2,3,0],eqn33[2,3,1],eqn33[2,3,2],eqn33[2,3,3],0} },
                        //z-row
                        { {eqn33[3,0,0],eqn33[3,0,1],eqn33[3,0,2],eqn33[3,0,3],0},
                         {eqn33[3,1,0],eqn33[3,1,1],eqn33[3,1,2],eqn33[3,1,3],0},
                         {eqn33[3,2,0],eqn33[3,2,1],eqn33[3,2,2],eqn33[3,2,3],0},
                         {0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0},{0,0,0,0,0} }
                    };

                //Major
                //initialize the draw segment
                int offset = 20;
                tableGrid page = new tableGrid(stacky, offset);
                page.clear();
                tableau4 tb33 = new tableau4(eqn_33, type, cons, vars, side4);
                tb33.toCompForm();
                tb33.rank();
                //gives optimal the value of the isOptimal method of the current tableau
                optimal = tb33.isOptimal();
                for (int i = 0; optimal == false;i++)
                {
                    if (tb33.isOptimal())
                    {
                        //stop
                        tab4 = tb33.tab;
                        pref.Visibility = Visibility.Collapsed;
                        comm.Visibility = Visibility.Collapsed;
                        page.draw4(tab4, "Tableau " + (i + 1), "Tableau is Optimal", 0, side4);
                        optimal = true;
                        page.statement("Z* = " + tab4[3, 6, 0] + " , "  + tab4[3, 6, 1] + " , " + tab4[3, 6, 2] + " , " + tab4[3, 6, 3] + " | " + tab4[3,6,4] + "\n" + 
                            side4[0] + "* = " + tab4[0, 6, 0] + " , " + tab4[0, 6, 1] + " , " + tab4[0, 6, 2] + " , " + tab4[0, 6, 3] + " | " + tab4[0, 6, 4] + " , " +
                            side4[1] + "* = " + tab4[1, 6, 0] + " , " + tab4[1, 6, 1] + " , " + tab4[1, 6, 2] + " , " + tab4[1, 6, 3] + " | " + tab4[1, 6, 4] + " , " + 
                            side4[2] + "* = " + tab4[2, 6, 0] + " , " + tab4[2, 6, 1] + " , " + tab4[2, 6, 2] + " , " + tab4[2, 6, 3] + " | " + tab4[2, 6, 4]);
                        break;
                    }
                    else
                    {
                        tab4 = tb33.tab;
                        pc = tb33.getPC();
                        pr = tb33.getPR(pc);
                        float pe = tb33.getPE(pc, pr);
                        int pos = getPeNum4(pr, pc);
                        pref.Visibility = Visibility.Collapsed;
                        comm.Visibility = Visibility.Collapsed;
                        side4 = tb33.side;
                        page.draw4(tab4, "Tableau " + (i + 1), "Tableau is not Optimal", pos, side4);
                        tb33 = fuzzy4(tb33, type, cons, vars, tab4);
                        optimal = false;
                        offset = page.off;
                    }
                }
            }
        }

        // This set the equation type to Arranged 
        private void arr_Checked(object sender, RoutedEventArgs e)
        {
            type = 1;
        }

        // This set the equation type to Unarranged 
        private void unarr_Checked(object sender, RoutedEventArgs e)
        {
            type = 2;
        }

        // This handles the event click of the Start button
        private void start_Click(object sender, RoutedEventArgs e)
        {
            pref.Visibility = Visibility.Visible;
            comm.Visibility = Visibility.Visible;
        }

        // This handles the event click of the Help button
        private void info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("5 Simple Steps to Guide you" +
                "\n\n\n 1. Select the type of calculation by checking either the Arranged or Unarranged button in the MenuBar." +
                "\n\n 2. Click the Start button in the MenuBar." +
                "\n\n 3. Select the number of Variables and Constraints for the equation." +
                "\n\n 4. Fill in the boxes with the values of the fuzzy set and Press Go." +
                "\n      ( Use the Tabs key for quick navigation. )" +
                "\n\n 5. Repeat Step 1 and 2 to carry out another Calculation." +
                "\n\n\n\n Creators Studio" +
                "\n - 09093590559",
                "Fully Fuzzy LPP Software", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // This is the main function
        public MainWindow()
        {
            InitializeComponent();
            // Hide Error Msg
            err1.Visibility = Visibility.Hidden;
            err2.Visibility = Visibility.Hidden;
            err3.Visibility = Visibility.Hidden;
            err4.Visibility = Visibility.Hidden;
            pref.Visibility = Visibility.Collapsed;
            comm.Visibility = Visibility.Collapsed;
        }

        // These set of functions helps to generate new tableaus
        private tableau1 fuzzy1(tableau1 tab, int type, int cons, int vars, float[,,] tabb)
        {
            int pc = tab.getPC();
            int pr = tab.getPR(pc);
            float pe = tab.getPE(pc, pr);
            tab.setSide();
            //creating a new tableau instance
            tableau1 _tb = new tableau1(tabb, type, cons, vars, side1);

            //then the instance is used to generate a new table, i.e tableau 2
            _tb.getNewTableau(tabb, pc, pr, pe);
            _tb.rank();
            return _tb;
        }

        private tableau2 fuzzy2(tableau2 tab, int type, int cons, int vars, float[,,] tabb)
        {
            int pc = tab.getPC();
            int pr = tab.getPR(pc);
            float pe = tab.getPE(pc, pr);
            tab.setSide();
            //creating a new tableau instance
            tableau2 _tb = new tableau2(tabb, type, cons, vars, side2);

            //then the instance is used to generate a new table, i.e tableau 2
            // and is assigned to the public tab1
            _tb.getNewTableau(tabb, pc, pr, pe);
            _tb.rank();
            return _tb;
        }

        private tableau3 fuzzy3(tableau3 tab, int type, int cons, int vars, float[,,] tabb)
        {
            int pc = tab.getPC();
            int pr = tab.getPR(pc);
            float pe = tab.getPE(pc, pr);
            tab.setSide();
            //creating a new tableau instance
            tableau3 _tb = new tableau3(tabb, type, cons, vars, side3);

            //then the instance is used to generate a new table, i.e tableau 2
            // and is assigned to the public tab1
            _tb.getNewTableau(tabb, pc, pr, pe);
            _tb.rank();
            return _tb;
        }

        private tableau4 fuzzy4(tableau4 tab, int type, int cons, int vars, float[,,] tabb)
        {
            int pc = tab.getPC();
            int pr = tab.getPR(pc);
            float pe = tab.getPE(pc, pr);
            tab.setSide();
            //creating a new tableau instance
            tableau4 _tb = new tableau4(tabb, type, cons, vars, side4);

            //then the instance is used to generate a new table, i.e tableau 2
            // and is assigned to the public tab1
            _tb.getNewTableau(tabb, pc, pr, pe);
            _tb.rank();
            return _tb;
        }

        // this function helps to validate the values inputted by the user
        // It returns false if the value is not valid
        private bool isValid(string input)
        {
            float outt;
            if (input != "")
            {
                if (float.TryParse(input, out outt))
                    return true;
                else return false;
            }
            else return false;
        }

        // This function checks if a set of fuzzy values are arranged
        private bool isArranged(string x, string y)
        {
            if (type == 2)
            {
                return true;
            }
            else if (type == 1)
            {
                if (x == y) return true;
                else return false;
            }
            else return false;
        }

        // These set of functions returns the a number to identify the cell of a value 
        // It is sent to the tableGrid class to know when a value is the pivot element
        private int getPeNum1(int pr,int pc)
        {
            switch (pr)
            {
                case 0:
                    switch (pc)
                    {
                        case 0:
                            return 1;
                        case 1:
                            return 2;
                        case 2:
                            return 3;
                        case 3:
                            return 4;
                    }
                    break;
                case 1:
                    switch (pc)
                    {
                        case 0:
                            return 5;
                        case 1:
                            return 6;
                        case 2:
                            return 7;
                        case 3:
                            return 8;
                    }
                    break;
            }
            return 0;
        }

        private int getPeNum2(int pr, int pc)
        {
            switch (pr)
            {
                case 0:
                    switch (pc)
                    {
                        case 0:
                            return 1;
                        case 1:
                            return 2;
                        case 2:
                            return 3;
                        case 3:
                            return 4;
                        case 4:
                            return 5;
                    }
                    break;
                case 1:
                    switch (pc)
                    {
                        case 0:
                            return 6;
                        case 1:
                            return 7;
                        case 2:
                            return 8;
                        case 3:
                            return 9;
                        case 4:
                            return 10;
                    }
                    break;
            }
            return 0;
        }

        private int getPeNum3(int pr, int pc)
        {
            switch (pr)
            {
                case 0:
                    switch (pc)
                    {
                        case 0:
                            return 1;
                        case 1:
                            return 2;
                        case 2:
                            return 3;
                        case 3:
                            return 4;
                        case 4:
                            return 5;
                    }
                    break;
                case 1:
                    switch (pc)
                    {
                        case 0:
                            return 6;
                        case 1:
                            return 7;
                        case 2:
                            return 8;
                        case 3:
                            return 9;
                        case 4:
                            return 10;
                    }
                    break;
                case 2:
                    switch (pc)
                    {
                        case 0:
                            return 11;
                        case 1:
                            return 12;
                        case 2:
                            return 13;
                        case 3:
                            return 14;
                        case 4:
                            return 15;
                    }
                    break;
            }
            return 0;
        }

        private int getPeNum4(int pr, int pc)
        {
            switch (pr)
            {
                case 0:
                    switch (pc)
                    {
                        case 0:
                            return 1;
                        case 1:
                            return 2;
                        case 2:
                            return 3;
                        case 3:
                            return 4;
                        case 4:
                            return 5;
                        case 5:
                            return 6;
                    }
                    break;
                case 1:
                    switch (pc)
                    {
                        case 0:
                            return 7;
                        case 1:
                            return 8;
                        case 2:
                            return 9;
                        case 3:
                            return 10;
                        case 4:
                            return 11;
                        case 5:
                            return 12;
                    }
                    break;
                case 2:
                    switch (pc)
                    {
                        case 0:
                            return 13;
                        case 1:
                            return 14;
                        case 2:
                            return 15;
                        case 3:
                            return 16;
                        case 4:
                            return 17;
                        case 5:
                            return 18;
                    }
                    break;
            }
            return 0;
        }
    }
}